using System;
using System.Threading;
using System.Windows.Forms;

namespace IceWebAutomation.WebAutomationTasks
{
    public class NavigateTask : Task
    {
        public static  string Execute(WebBrowser browser, string urlToLoad)
        {
             
            int counterTimeOut = 500;
            string message;
            
            try
            {
                browser.DocumentCompleted += delegate
                {
                    loadFinished = true;
                };
                 
                loadFinished = false;
                browser.Navigate(urlToLoad);
                
                while (!loadFinished && counterTimeOut > 0)
                {
                    Thread.Sleep(100);
                    Application.DoEvents();
                    counterTimeOut--;
                }
                message = string.Format("Navigated to {0}", urlToLoad);
                 
            }
            catch (Exception ex)
            {
                message = ex.ToString();
                 
            }

            return message;
        }
    }
}