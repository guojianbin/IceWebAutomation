using System;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace IceWebAutomation
{
    public class HotKeyHelper
    {
        static bool ctrl, shift, alt = false;
        static string key;

        /// <summary>
        /// 修改键。
        /// </summary>
        public Keys Modifiers = Keys.None;

        /// <summary>
        /// 按键值。
        /// </summary>
        public Keys KeyCode = Keys.None;

        /// <summary>
        /// 初始化类 <see cref="HotKeyHelper"/> 的新实例。
        /// </summary>
        /// <param name="modifiers">The modifiers.</param>
        /// <param name="keyCode">The key code.</param>
        public HotKeyHelper(Keys modifiers, Keys keyCode)
        {
            this.Modifiers = modifiers;
            this.KeyCode = keyCode;
        }

        /// <summary>
        /// 已重载，返回“Ctrl+Alt+A”格式的字符串。
        /// </summary>
        /// <returns>类似“Ctrl+Alt+A”格式的字符串</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if ((this.Modifiers & Keys.Control) != 0)
                sb.Append("Ctrl+");
            if ((this.Modifiers & Keys.Shift) != 0)
                sb.Append("Shift+");
            if ((this.Modifiers & Keys.Alt) != 0)
                sb.Append("Alt+");

            if (this.KeyCode != Keys.None)
                sb.Append((char) this.KeyCode);

            return sb.ToString();

        }

        //如果函数执行成功，返回值不为0。  
        //如果函数执行失败，返回值为0。要得到扩展错误信息，调用GetLastError。  
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool RegisterHotKey(
            IntPtr hWnd,                //要定义热键的窗口的句柄  
            int id,                     //定义热键ID（不能与其它ID重复）             
            KeyModifiers fsModifiers,   //标识热键是否在按Alt、Ctrl、Shift、Windows等键时才会生效  
            Keys vk                     //定义热键的内容  
            );

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool UnregisterHotKey(
            IntPtr hWnd,                //要取消热键的窗口的句柄  
            int id                      //要取消热键的ID  
            );

        //定义了辅助键的名称（将数字转变为字符以便于记忆，也可去除此枚举而直接使用数值）  
        [Flags()]
        public enum KeyModifiers
        {
            None = 0,
            Alt = 1,
            Ctrl = 2,
            Shift = 4,
            WindowsKey = 8
        }



        /// <summary>
        /// 注册textbox快捷键输入
        /// </summary>
        /// <param name="txtbox"></param>
        /// <param name="e"></param>
        public static void RegisterToShortCutTextBox(TextBox txtbox, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                txtbox.Text = "";
                return;
            }
            if (e.Modifiers == 0) //没有修改键
            {
                e.Handled = true;
                txtbox.Clear();
                return;
            }

            HotKeyHelper value = null;
            if (e.KeyCode == Keys.ShiftKey || e.KeyCode == Keys.ControlKey || e.KeyCode == Keys.Menu || e.KeyCode == Keys.None)
            {//除修改键外，没有按键
                value = new HotKeyHelper(e.Modifiers, Keys.None);
            }
            else
            {
                value = new HotKeyHelper(e.Modifiers, e.KeyCode);
            }

            txtbox.Text = value.ToString();//赋值
            e.Handled = true;
            //base.OnKeyDown(e);

        }

        /// <summary>
        /// 读取快捷键
        /// </summary>
        private static void ReadFastString(string fastShortCut)
        {
            if (fastShortCut == "")
            {
                return;
            }
            ctrl = false;
            shift = false;
            alt = false;
            if (fastShortCut.Contains("Ctrl"))
            {
                ctrl = true;
            }
            if (fastShortCut.Contains("Shift"))
            {
                shift = true;
            }
            if (fastShortCut.Contains("Alt"))
            {
                alt = true;
            }
            if (fastShortCut.Substring(fastShortCut.Length - 1, 1) != "+")
            {
                key = fastShortCut.Substring(fastShortCut.Length - 1, 1);
            }
        }

        /// <summary>
        /// 注册快捷键命令
        /// </summary>
        /// <param name="frmIntPtrHandle"></param>
        /// <param name="type"></param>
        private static void RegFastShortCut(IntPtr frmIntPtrHandle, int type)
        {
            Keys k = (Keys)Enum.Parse(typeof(Keys), key);
            if (ctrl && alt && shift)
            {
                HotKeyHelper.RegisterHotKey(frmIntPtrHandle, type, HotKeyHelper.KeyModifiers.Ctrl | HotKeyHelper.KeyModifiers.Alt | HotKeyHelper.KeyModifiers.Shift, k);
            }
            else if (ctrl && alt)
            {
                HotKeyHelper.RegisterHotKey(frmIntPtrHandle, type, HotKeyHelper.KeyModifiers.Ctrl | HotKeyHelper.KeyModifiers.Alt, k);
            }
            else if (ctrl && shift)
            {
                HotKeyHelper.RegisterHotKey(frmIntPtrHandle, type, HotKeyHelper.KeyModifiers.Ctrl | HotKeyHelper.KeyModifiers.Shift, k);
            }
            else if (shift && alt)
            {
                HotKeyHelper.RegisterHotKey(frmIntPtrHandle, type, HotKeyHelper.KeyModifiers.Shift | HotKeyHelper.KeyModifiers.Alt, k);
            }
            else if (ctrl)
            {
                HotKeyHelper.RegisterHotKey(frmIntPtrHandle, type, HotKeyHelper.KeyModifiers.Ctrl, k);
            }
            else if (shift)
            {
                HotKeyHelper.RegisterHotKey(frmIntPtrHandle, type, HotKeyHelper.KeyModifiers.Shift, k);
            }
            else if (alt)
            {
                HotKeyHelper.RegisterHotKey(frmIntPtrHandle, type, HotKeyHelper.KeyModifiers.Alt, k);
            }
        }

        /// <summary>
        /// 注册快捷键到指定处理方法
        /// </summary>
        /// <param name="frmIntPtrHandle">句柄生效窗体</param>
        /// <param name="shortCut">快捷键</param>
        /// <param name="exeHandleType">指定处理方法句柄</param>
        public static void RegShortcutToHandle(IntPtr frmIntPtrHandle, string shortCut, int exeHandleType)
        {
            ReadFastString(shortCut);

            RegFastShortCut(frmIntPtrHandle, exeHandleType);
        }


        /*
        /// <summary>
        /// 执行对于快捷键操作
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;//生成该消息的热键ID
            //按快捷键   
            switch (m.Msg)
            {
                case WM_HOTKEY:
                    switch (m.WParam.ToInt32())
                    {
                        case 100:
                            this.Hide();
                            break;
                        case 101:
                            this.Show();
                            break;
                        case 102:
                            toolStripMenuItemAdd_Click(null, null);
                            break;
                        case 103:
                            toolStripMenuItemDel_Click(null, null);
                            break;
                        case 104:
                            toolStripMenuItemRefresh_Click(null, null);
                            break;
                    }
                    break;
            }
            base.WndProc(ref m);
        }
        */

    }
}
