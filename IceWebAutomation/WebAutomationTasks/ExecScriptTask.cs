using System;
using System.Collections.Generic;
using System.Text;
using mshtml;
using System.Windows.Forms;
namespace IceWebAutomation.WebAutomationTasks
{
    public class ExecScriptTask : Task
    {
        public static string Execute(WebBrowser wb, string strScript)
        {
            try
            {
   
                IHTMLWindow2 win = (IHTMLWindow2)wb.Document.Window.DomWindow;
                win.execScript(strScript, "Javascript");
               

            }
            catch (Exception ex)
            {
                return String.Format("Excute Js: {0}", ex.Message);
            }

            return String.Format("Excute Js {0} Success ", strScript);
        }

    }
}
