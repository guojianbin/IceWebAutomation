using System;
using System.Threading;
using System.Windows.Forms;
using mshtml;

namespace IceWebAutomation.WebAutomationTasks
{
    public class ClickButtonTask:Task
    {
        public static  string Execute(WebBrowser browser, HtmlElement btn)
        {
            //if (btn.GetAttribute("type") == "submit")
            //{
                 
            //}
            int counterTimeOut = 500;
            string message;
            //State.IsBusy = true;
            try
            {
                browser.DocumentCompleted += delegate { loadFinished = true; };

                HTMLInputElementClass iElement = (HTMLInputElementClass)btn.DomElement;
                iElement.click();

                while (!loadFinished && counterTimeOut > 0)
                {
                    Thread.Sleep(100);
                    Application.DoEvents();
                    counterTimeOut--;
                }
                message = string.Format("Button {0} clicked", btn.InnerHtml.ToString());
               // State.IsBusy = false;
            }
            catch (Exception ex)
            {
                //State.IsBusy = false;
                message = ex.ToString();
            }

            return message;
        }
    }
}
