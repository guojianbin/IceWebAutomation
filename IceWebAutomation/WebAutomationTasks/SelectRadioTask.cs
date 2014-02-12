using System;
using System.Windows.Forms;
using mshtml;

namespace IceWebAutomation.WebAutomationTasks
{
    public class SelectRadioTask
    {
        public static string Execute(HtmlElement radioToSelect)
        {
            try
            {
                HTMLInputElementClass iElement = (HTMLInputElementClass)radioToSelect.DomElement;
                iElement.@checked = true;
            }
            catch (Exception ex)
            {
                return String.Format("Unable to check radio button: {0}", ex.Message);
            }

            return "Radio button was select.";
        }
    }
}