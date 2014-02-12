using System;
using System.Windows.Forms;
using mshtml;

namespace IceWebAutomation.WebAutomationTasks
{
    public class ClickLinkTask : Task
    {
        public static string Execute(HtmlElement linkToClick)
        {
            try
            {
                //HTMLAnchorElementClass linkElement = (HTMLAnchorElementClass) linkToClick.DomElement;
                //linkElement.click();
                HTMLImgClass linkElement = (HTMLImgClass)linkToClick.DomElement;
                linkElement.click();
            }
            catch (Exception ex)
            {
                return String.Format("Unable to click link: {0}", ex.Message);
            }

            return "Link was clicked, new page opened...";
        }
    }
}