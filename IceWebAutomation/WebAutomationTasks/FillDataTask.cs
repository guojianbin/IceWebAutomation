using System;
using System.Windows.Forms;

namespace IceWebAutomation.WebAutomationTasks
{
    public class FillDataTask : Task
    {
        public static  string Execute(HtmlElement element, string valueToFill)
        {
            loadFinished = false;
            try
            {
                element.InnerText = valueToFill;
            }
            catch (Exception ex)
            {
                loadFinished = true;
                return String.Format("Unable to fill value in input field: {0}", ex.Message);
            }
            loadFinished = true;
            return "Text box was field with value.";
        }
    }
}