using System;
using System.Windows.Forms;
using mshtml;

namespace IceWebAutomation.WebAutomationTasks
{
    public class SelectDropDownTask
    {
        public static string Execute(HtmlElement dropdown, string value)
        {
            try
            {
                HTMLSelectElementClass iElement = (HTMLSelectElementClass) dropdown.DomElement;
                iElement.value = value;
            }

            catch (Exception ex)
            {
                return String.Format("Unable to select value in drop down list: {0}", ex.Message);
            }

            return "A value from list was selected.";
        }
    }
}