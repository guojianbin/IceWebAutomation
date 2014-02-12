using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace IceWebAutomation.WebAutomationTasks
{
    public class MakeScreenShotTask
    {
        public string Execute(WebBrowser browser, string baseDir, string pictureName)
        {
            Rectangle rec = new Rectangle();
            rec.Offset(0, 0);
            rec.Size = browser.Document.Window.Size;

            Bitmap bmp = new Bitmap(rec.Width, rec.Height);
            browser.DrawToBitmap(bmp, rec);

            bmp.Save(Path.Combine(baseDir, pictureName), ImageFormat.Jpeg);

            return "Picture saved to c:";
        }
    }
}