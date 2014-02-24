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
        /// �޸ļ���
        /// </summary>
        public Keys Modifiers = Keys.None;

        /// <summary>
        /// ����ֵ��
        /// </summary>
        public Keys KeyCode = Keys.None;

        /// <summary>
        /// ��ʼ���� <see cref="HotKeyHelper"/> ����ʵ����
        /// </summary>
        /// <param name="modifiers">The modifiers.</param>
        /// <param name="keyCode">The key code.</param>
        public HotKeyHelper(Keys modifiers, Keys keyCode)
        {
            this.Modifiers = modifiers;
            this.KeyCode = keyCode;
        }

        /// <summary>
        /// �����أ����ء�Ctrl+Alt+A����ʽ���ַ�����
        /// </summary>
        /// <returns>���ơ�Ctrl+Alt+A����ʽ���ַ���</returns>
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

        //�������ִ�гɹ�������ֵ��Ϊ0��  
        //�������ִ��ʧ�ܣ�����ֵΪ0��Ҫ�õ���չ������Ϣ������GetLastError��  
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool RegisterHotKey(
            IntPtr hWnd,                //Ҫ�����ȼ��Ĵ��ڵľ��  
            int id,                     //�����ȼ�ID������������ID�ظ���             
            KeyModifiers fsModifiers,   //��ʶ�ȼ��Ƿ��ڰ�Alt��Ctrl��Shift��Windows�ȼ�ʱ�Ż���Ч  
            Keys vk                     //�����ȼ�������  
            );

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool UnregisterHotKey(
            IntPtr hWnd,                //Ҫȡ���ȼ��Ĵ��ڵľ��  
            int id                      //Ҫȡ���ȼ���ID  
            );

        //�����˸����������ƣ�������ת��Ϊ�ַ��Ա��ڼ��䣬Ҳ��ȥ����ö�ٶ�ֱ��ʹ����ֵ��  
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
        /// ע��textbox��ݼ�����
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
            if (e.Modifiers == 0) //û���޸ļ�
            {
                e.Handled = true;
                txtbox.Clear();
                return;
            }

            HotKeyHelper value = null;
            if (e.KeyCode == Keys.ShiftKey || e.KeyCode == Keys.ControlKey || e.KeyCode == Keys.Menu || e.KeyCode == Keys.None)
            {//���޸ļ��⣬û�а���
                value = new HotKeyHelper(e.Modifiers, Keys.None);
            }
            else
            {
                value = new HotKeyHelper(e.Modifiers, e.KeyCode);
            }

            txtbox.Text = value.ToString();//��ֵ
            e.Handled = true;
            //base.OnKeyDown(e);

        }

        /// <summary>
        /// ��ȡ��ݼ�
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
        /// ע���ݼ�����
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
        /// ע���ݼ���ָ��������
        /// </summary>
        /// <param name="frmIntPtrHandle">�����Ч����</param>
        /// <param name="shortCut">��ݼ�</param>
        /// <param name="exeHandleType">ָ�����������</param>
        public static void RegShortcutToHandle(IntPtr frmIntPtrHandle, string shortCut, int exeHandleType)
        {
            ReadFastString(shortCut);

            RegFastShortCut(frmIntPtrHandle, exeHandleType);
        }


        /*
        /// <summary>
        /// ִ�ж��ڿ�ݼ�����
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;//���ɸ���Ϣ���ȼ�ID
            //����ݼ�   
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
