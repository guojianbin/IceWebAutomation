using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace IceWebAutomation
{
    public abstract class IEvent
    {
        public WebBrowser Webbrowser;
        public FrmShowImage ShowImageForm;
        public Command Command;
        public string Detail;
        public List<string> Data = new List<string>();
    }

    public class Event : IEvent
    {

    }

}
