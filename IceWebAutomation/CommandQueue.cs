using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
namespace IceWebAutomation
{
    public class CommandQueue
    {

        public bool Stop = false;
        public bool TaskOver = true;
        //public static List<IEvent> Commands=new List<IEvent>();
        public static Dictionary<IEvent, IHandle> ProceQueue = new Dictionary<IEvent, IHandle>();
        public Control control;
        public CommandQueue(string TaskScript, WebBrowser wb, FrmShowImage objShowImg, Control ctrl)
        {
            control = ctrl;
            //Commands.Clear();
            ProceQueue.Clear();
            string BodyText = TaskScript;
            string[] CL=BodyText.Split(';');             
            foreach( string LineText in CL)
            {                 
                IEvent e = new Event();
                Regex r = new Regex(@"[a-z]*\(", RegexOptions.IgnoreCase);
                Match m = r.Match(LineText.Trim());
                if (m.Success)
                {
                    e.Webbrowser = wb;
                    e.Detail = LineText.Trim();
                    e.ShowImageForm = objShowImg;
                    e.Command = CommandHelper.GetCommandByName(m.Value.Remove(m.Value.Length - 1, 1));
                    r = new Regex(@"\([\s\S]*\)", RegexOptions.IgnoreCase);
                    m = r.Match(LineText.Trim());
                    if (m.Success)
                    {
                        string ts = m.Value.Remove(m.Value.Length - 1, 1);
                        ts = ts.Remove(0, 1);
                        string[] sl = ts.Split(',');
                        foreach (string s in sl)
                        {
                            e.Data.Add(s);
                        }
                        //Commands.Add(e);
                        ProceQueue.Add(e, CommandHelper.GetHandleByCommand(e.Command));
                    }
                }
            }
        }
        public void Execute()
        {
            //TaskOver = false;
            //foreach (IEvent e in Commands)
            //{            
            //    IHandle.StartNode.DoEvent(e);
            //    //Thread.Sleep(5000);
            //}

            foreach (KeyValuePair<IEvent, IHandle> kv in ProceQueue)
            {
                if (kv.Key.Command == Command.GetImg)
                {
                    //Application.DoEvents();
                    //InvokeHelper.Invoke(control, "tsbTaskScriptGetPic_Click", new object[] { new object(), new EventArgs() });
                    InvokeHelper.Set(kv.Key.ShowImageForm.picbSource, "Image", WebAutomationTasks.GetImgTask.Execute(kv.Key.Webbrowser, kv.Key.Data[0], kv.Key.Data[1], kv.Key.Data[2]));
                    
                    //InvokeHelper.Set(kv.Key.ShowImageForm.picbSource, "Image", WebAutomationTasks.GetImgTask.Execute(kv.Key.Webbrowser, kv.Key.Data[0], kv.Key.Data[1], kv.Key.Data[2]));
                    //kv.Key.ShowImageForm.picbSource.Image = WebAutomationTasks.GetImgTask.Execute(kv.Key.Webbrowser, kv.Key.Data[0], kv.Key.Data[1], kv.Key.Data[2]);
                    kv.Key.ShowImageForm.Show();
                }
                else
                    kv.Value.DoEvent(kv.Key);
            }
            
        }

        

    }
}
