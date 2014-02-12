using System;
using System.Collections.Generic;
using System.Text;
using IceWebAutomation.WebAutomationTasks;

namespace IceWebAutomation
{

    public abstract class IHandle
    {
        //public IHandle SetNextHandle(IHandle next)
        //{
        //    nextHandle = next;
        //    return next;
        //}
        public IHandle()
        {
            
        }
        //轮循加入事件
        //static IHandle()
        //{
        //    StartNode = new StartHandle();
        //    StartNode.SetNextHandle(new ClickHandle()).
        //              SetNextHandle(new ClickByIdHandle()).
        //              SetNextHandle(new ClickByNameHandle()).
        //              SetNextHandle(new FillHandle()).
        //              SetNextHandle(new FillByIdHandle()).
        //              SetNextHandle(new FillByNameHandle()).
        //              SetNextHandle(new GoHandle()).
        //              SetNextHandle(new GoForwardHandle()).
        //              SetNextHandle(new GoBackHandle()).
        //              SetNextHandle(new RefreshHandle()).SetNextHandle(null);

        //}
        //public static IHandle StartNode;
        //IHandle nextHandle;
        //public IHandle NextHandle
        //{
        //    get
        //    {
        //        return nextHandle;
        //    }
        //    set
        //    {
        //        nextHandle = value;
        //    }
        //}
        public void DoEvent(IEvent e)
        {
            if (CanDo(e))
            {
                Do(e);
            }
            else
            {
                //if (NextHandle != null)
                //{
                //    NextHandle.DoEvent(e);
                //}
            }
        }
        protected abstract bool CanDo(IEvent e);
        protected abstract void Do(IEvent e);
       

    }

    //Any Handle Do own thing


    public class StartHandle : IHandle
    {
        protected override bool CanDo(IEvent e)
        {
            return false;

        }
        protected override void Do(IEvent e)
        {
        }
    }
    public class GoHandle : IHandle
    {

        protected override bool CanDo(IEvent e)
        {
            if (e.Command == Command.Go)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected override void Do(IEvent e)
        {
            if (e.Data.Count < 1)
            {
                return;
            }
            NavigateTask.Execute(e.Webbrowser, e.Data[0]);
        }
    }

    public class SleepHandle : IHandle
    {

        protected override bool CanDo(IEvent e)
        {
            if (e.Command == Command.Sleep)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected override void Do(IEvent e)
        {
            if (e.Data.Count < 1)
            {
                return;
            }

            SleepTask.Execute( Convert.ToInt32( e.Data[0]));
        }
    }
    public class ClickHandle : IHandle
    {

        protected override bool CanDo(IEvent e)
        {
            if (e.Command == Command.Click)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected override void Do(IEvent e)
        {
            if (e.Data.Count < 1)
            {
                return;
            }

            ClickButtonTask.Execute(e.Webbrowser, WebAutomationHelper.ParseElementByXPath(e.Webbrowser.Document.Body, e.Data[0]));
        }
    }

    public class ClickByNameHandle : IHandle
    {

        protected override bool CanDo(IEvent e)
        {
            if (e.Command == Command.ClickByName)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected override void Do(IEvent e)
        {
            if (e.Data.Count < 1)
            {
                return;
            }

            ClickButtonTask.Execute(e.Webbrowser, WebAutomationHelper.FindControlByName(e.Webbrowser, e.Data[0]));
        }
    }

    public class ClickByIdHandle : IHandle
    {

        protected override bool CanDo(IEvent e)
        {
            if (e.Command == Command.ClickById)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected override void Do(IEvent e)
        {
            if (e.Data.Count < 1)
            {
                return;
            }
            ClickButtonTask.Execute(e.Webbrowser, WebAutomationHelper.FindControlByID(e.Webbrowser, e.Data[0]));
        }
    }
    public class FillHandle : IHandle
    {
        protected override bool CanDo(IEvent e)
        {
            if (e.Command == Command.Fill)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected override void Do(IEvent e)
        {
            if (e.Data.Count < 2)
            {
                return;
            }
            FillDataTask.Execute(WebAutomationHelper.ParseElementByXPath(e.Webbrowser.Document.Body, e.Data[0]), e.Data[1]);
        }
    }
    public class FillByIdHandle : IHandle
    {
        protected override bool CanDo(IEvent e)
        {
            if (e.Command == Command.FillById)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected override void Do(IEvent e)
        {
            if (e.Data.Count < 2)
            {
                return;
            }
            FillDataTask.Execute(WebAutomationHelper.FindControlByID(e.Webbrowser, e.Data[0]), e.Data[1]);
        }
    }
    public class FillByNameHandle : IHandle
    {

        protected override bool CanDo(IEvent e)
        {
            if (e.Command == Command.FillByName)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected override void Do(IEvent e)
        {
            if (e.Data.Count < 2)
            {
                return;
            }

            FillDataTask.Execute(WebAutomationHelper.FindControlByName(e.Webbrowser, e.Data[0]), e.Data[1]);
        }
    }
    public class GoForwardHandle : IHandle
    {

        protected override bool CanDo(IEvent e)
        {
            if (e.Command == Command.GoForward)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected override void Do(IEvent e)
        {
            e.Webbrowser.GoForward();
        }
    }
    public class GoBackHandle : IHandle
    {

        protected override bool CanDo(IEvent e)
        {
            if (e.Command == Command.GoBack)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected override void Do(IEvent e)
        {
            e.Webbrowser.GoBack();
        }
    }
    public class RefreshHandle : IHandle
    {

        protected override bool CanDo(IEvent e)
        {
            if (e.Command == Command.Refresh)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected override void Do(IEvent e)
        {
            e.Webbrowser.Refresh();
        }
    }
    
    public class SelectDropDownHandle : IHandle
    {

        protected override bool CanDo(IEvent e)
        {
            if (e.Command == Command.Go)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected override void Do(IEvent e)
        {
            if (e.Data.Count < 2)
            {
                return;
            }
            SelectDropDownTask.Execute(WebAutomationHelper.ParseElementByXPath(e.Webbrowser.Document.Body, e.Data[0]), e.Data[1]);
        }
    }

    public class ClickLinkHandle : IHandle
    {

        protected override bool CanDo(IEvent e)
        {
            if (e.Command == Command.ClickLink)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected override void Do(IEvent e)
        {
            if (e.Data.Count < 1)
            {
                return;
            }
            ClickLinkTask.Execute(WebAutomationHelper.ParseElementByXPath(e.Webbrowser.Document.Body, e.Data[0]));
        }
    }
    public class SelectRadioHandle : IHandle
    {

        protected override bool CanDo(IEvent e)
        {
            if (e.Command == Command.SelectRadio)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected override void Do(IEvent e)
        {
            if (e.Data.Count < 1)
            {
                return;
            }
            SelectRadioTask.Execute(WebAutomationHelper.ParseElementByXPath(e.Webbrowser.Document.Body, e.Data[0]));
        }
    }
    public class ExcuteJsHandle : IHandle
    {

        protected override bool CanDo(IEvent e)
        {
            if (e.Command == Command.ExcuteJs)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected override void Do(IEvent e)
        {
            if (e.Data.Count < 2)
            {
                return;
            }
            object[] pars = new object[e.Data.Count - 1];
            int j = 0;
            for (int i = 1; i < e.Data.Count; i++)
            {
                pars[j++] = e.Data[i];
            }
            ExcuteJsTask.Execute(e.Webbrowser, e.Data[0], pars);
        }
    }

    public class GetImgHandle : IHandle
    {

        protected override bool CanDo(IEvent e)
        {
            if (e.Command == Command.GetImg)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected override void Do(IEvent e)
        {
            if (e.Data.Count < 3)
            {
                return;
            }

            e.ShowImageForm.picbSource.Image = GetImgTask.Execute(e.Webbrowser, e.Data[0], e.Data[1], e.Data[2]);
            e.ShowImageForm.Show();
        }
    }
    public class ExecScriptHandle : IHandle
    {

        protected override bool CanDo(IEvent e)
        {
            if (e.Command == Command.ExecScript)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected override void Do(IEvent e)
        {
            if (e.Data.Count < 1)
            {
                return;
            }

            ExecScriptTask.Execute(e.Webbrowser, e.Data[0]);
            
        }
    }
}
