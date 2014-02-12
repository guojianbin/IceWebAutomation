using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
namespace IceWebAutomation.WebAutomationTasks
{
    public class GetImgTask : Task
    {

        public static Image Execute(WebBrowser wb, string IdName, string Src, string Alt)
        {
            try
            {
                Image img = WebAutomationHelper.GetRegCodePic(wb, IdName, Src, Alt);
                return img;
            }
            catch (Exception ex)
            {
               /// return String.Format("Get Img Exists Error: {0}", ex.Message);
            }
            return null;
            //return String.Format("Get Img {0} Success ", Src);



        }


    }
}
