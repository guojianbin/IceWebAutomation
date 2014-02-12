using System;
using System.Collections.Generic;
using System.Text;
using mshtml;
using System.Windows.Forms;
namespace IceWebAutomation.WebAutomationTasks
{
    public class ExcuteJsTask : Task
    {
        public static string Execute(WebBrowser wb, string methodName, object[] pars)
        {
            try
            {
                wb.DocumentCompleted += delegate { loadFinished = true; };
                wb.Document.InvokeScript(methodName, pars);
                while (!loadFinished)
                {
                    System.Threading.Thread.Sleep(100);
                    Application.DoEvents();

                }

            }
            catch (Exception ex)
            {
                return String.Format("Excute Js: {0}", ex.Message);
            }

            return String.Format("Excute Js {0} Success ", methodName);
        }

    }
}
