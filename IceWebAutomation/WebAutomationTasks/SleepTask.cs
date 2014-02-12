using System;
using System.Collections.Generic;
using System.Text;

namespace IceWebAutomation.WebAutomationTasks
{
    public class SleepTask
    {
        public static string Execute(int ms)
        {
            System.Threading.Thread.Sleep(ms);
            return string.Format("Sleep for {0} ms", ms.ToString());
        }

    }
}
