using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
namespace IceWebAutomation
{
    /// <summary>  
    /// A thread-safe control invoker helper class.  
    /// </summary>  
    public class InvokeHelper
    {

        #region How to use
        /*
         
         Thread t;  
            private void button1_Click(object sender, EventArgs e)  
            {  
                if (t == null)  
                {  
                    t = new Thread(multithread);  
                    t.Start();  
                    label4.Text = string.Format(  
                        "Thread state:\n{0}",  
                        t.ThreadState.ToString()  
                        );  
                }  
            }  
              
            public void DoWork(string msg)  
            {  
                this.label3.Text = string.Format("Invoke method: {0}", msg);  
            }  
              
            int count = 0;  
            void multithread()  
            {  
                while (true)  
                {  
                    InvokeHelper.Set(this.label1, "Text", string.Format("Set value: {0}", count));  
                    InvokeHelper.Set(this.label1, "Tag", count);  
                    string value = InvokeHelper.Get(this.label1, "Tag").ToString();  
                    InvokeHelper.Set(this.label2, "Text",  
                        string.Format("Get value: {0}", value));  
              
                    InvokeHelper.Invoke(this, "DoWork", value);  
              
                    Thread.Sleep(500);  
                    count++;  
                }  
            }
         
         */
        #endregion


        #region delegates
        private delegate object MethodInvoker(Control control, string methodName, params object[] args);

        private delegate object PropertyGetInvoker(Control control, object noncontrol, string propertyName);
        private delegate void PropertySetInvoker(Control control, object noncontrol, string propertyName, object value);
        #endregion

        #region static methods
        // helpers  

        private static PropertyInfo GetPropertyInfo(Control control, object noncontrol, string propertyName)
        {
            if (control != null && !string.IsNullOrEmpty(propertyName))
            {
                PropertyInfo pi = null;
                Type t = null;

                if (noncontrol != null)
                    t = noncontrol.GetType();
                else
                    t = control.GetType();

                pi = t.GetProperty(propertyName);

                if (pi == null)
                    throw new InvalidOperationException(
                        string.Format(
                        "Can't find property {0} in {1}.",
                        propertyName,
                        t.ToString()
                        ));

                return pi;
            }
            else
                throw new ArgumentNullException("Invalid argument.");
        }

        // outlines  
        /// <summary>
        /// InvokeHelper.Invoke(<控件>, "<方法名称>", <参数>);  
        /// </summary>
        /// <param name="control"></param>
        /// <param name="methodName"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static object Invoke(Control control, string methodName, params object[] args)
        {
            if (control != null && !string.IsNullOrEmpty(methodName))
                if (control.InvokeRequired)
                    return control.Invoke(
                        new MethodInvoker(Invoke),
                        control,
                        methodName,
                        args
                        );
                else
                {
                    MethodInfo mi = null;

                    if (args != null && args.Length > 0)
                    {
                        Type[] types = new Type[args.Length];
                        for (int i = 0; i < args.Length; i++)
                        {
                            if (args[i] != null)
                                types[i] = args[i].GetType();
                        }

                        mi = control.GetType().GetMethod(methodName, types);
                    }
                    else
                        mi = control.GetType().GetMethod(methodName);

                    // check method info you get  
                    if (mi != null)
                        return mi.Invoke(control, args);
                    else
                        throw new InvalidOperationException("Invalid method.");
                }
            else
                throw new ArgumentNullException("Invalid argument.");
        }

        /// <summary>
        /// InvokeHelper.Get(<控件>, "<属性名称>");  
        /// </summary>
        /// <param name="control"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static object Get(Control control, string propertyName)
        {
            return Get(control, null, propertyName);
        }
        public static object Get(Control control, object noncontrol, string propertyName)
        {
            if (control != null && !string.IsNullOrEmpty(propertyName))
                if (control.InvokeRequired)
                    return control.Invoke(new PropertyGetInvoker(Get),
                        control,
                        noncontrol,
                        propertyName
                        );
                else
                {
                    PropertyInfo pi = GetPropertyInfo(control, noncontrol, propertyName);
                    object invokee = (noncontrol == null) ? control : noncontrol;

                    if (pi != null)
                        if (pi.CanRead)
                            return pi.GetValue(invokee, null);
                        else
                            throw new FieldAccessException(
                                string.Format(
                                "{0}.{1} is a write-only property.",
                                invokee.GetType().ToString(),
                                propertyName
                                ));

                    return null;
                }
            else
                throw new ArgumentNullException("Invalid argument.");
        }

        /// <summary>
        /// InvokeHelper.Set(<控件>, "<属性名称>", <属性值>);  
        /// </summary>
        /// <param name="control"></param>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        public static void Set(Control control, string propertyName, object value)
        {
            Set(control, null, propertyName, value);
        }
        public static void Set(Control control, object noncontrol, string propertyName, object value)
        {
            if (control != null && !string.IsNullOrEmpty(propertyName))
                if (control.InvokeRequired)
                    control.Invoke(new PropertySetInvoker(Set),
                        control,
                        noncontrol,
                        propertyName,
                        value
                        );
                else
                {
                    PropertyInfo pi = GetPropertyInfo(control, noncontrol, propertyName);
                    object invokee = (noncontrol == null) ? control : noncontrol;

                    if (pi != null)
                        if (pi.CanWrite)
                            pi.SetValue(invokee, value, null);
                        else
                            throw new FieldAccessException(
                                string.Format(
                                "{0}.{1} is a read-only property.",
                                invokee.GetType().ToString(),
                                propertyName
                                ));
                }
            else
                throw new ArgumentNullException("Invalid argument.");
        }
        #endregion
    }
}
