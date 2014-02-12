using System;
using System.Collections.Generic;
using System.Text;

namespace IceWebAutomation
{
    //class Command
    //{
    //    public static string ClickButtonByID = "ClickButtonByID";
    //    public static string ClickButtonByName = "ClickButtonByName";
    //    public static string EntryDataByID = "EntryDataByID";
    //    public static string EntryDataByName = "EntryDataByName";
    //    public static string ForWard = "ForWard";
    //    public static string BackWard = "BackWard";
    //    public static string Refresh = "Refresh";
    //    public static string Open = "Open";

    //}

    public enum Command
    {
        Go,
        Click,
        ClickById,
        ClickByName,
        Fill,
        FillById,
        FillByName,
        Refresh,
        Sleep,
        GoForward,
        GoBack,
        SelectDropDown,
        ClickLink,
        SelectRadio,
        ExcuteJs,
        ExecScript,
        GetImg
    }

    public class CommandHelper
    {
        public static Command GetCommandByName(string sName)
        {
            return (Command)Enum.Parse(typeof(Command), sName);
        }

        public static IHandle GetHandleByCommand(Command cmd)
        {
            switch (cmd)
            {
                case Command.Go:
                    return new GoHandle();
                case Command.Sleep:
                    return new SleepHandle();
                case Command.Click:
                    return new ClickHandle();
                case Command.ClickById:
                    return new ClickByIdHandle();
                case Command.ClickByName:
                    return new ClickByNameHandle();
                case Command.Fill:
                    return new FillHandle();
                case Command.FillById:
                    return new FillByIdHandle();
                case Command.FillByName:
                    return new FillByNameHandle();
                case Command.Refresh:
                    return new RefreshHandle();
                case Command.GoForward:
                    return new GoForwardHandle();
                case Command.GoBack:
                    return new GoBackHandle();
                case Command.SelectDropDown:
                    return new SelectDropDownHandle();
                case Command.ClickLink:
                    return new ClickLinkHandle();
                case Command.SelectRadio:
                    return new SelectRadioHandle();
                case Command.ExcuteJs:
                    return new ExcuteJsHandle();
                case Command.GetImg:
                    return new GetImgHandle();
                case Command.ExecScript:
                    return new ExecScriptHandle();
                    
                default: return null;

            }
        }
    }

}
