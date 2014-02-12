using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using System.IO;
using System.Net;
using System.Drawing;
using System.Windows.Forms;

namespace IceWebAutomation
{
    class WebAPI
    {

        [DllImport("User32.DLL")]

        public static extern int SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);



        [DllImport("User32.DLL")]

        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        public static int IDM_VIEWSOURCE = 2139;

        public static uint WM_COMMAND = 0x0111;

        public static void ShowSource(IntPtr webIntPtr, IntPtr formIntPtr)
        {
            IntPtr vHandle = webIntPtr;

            vHandle = FindWindowEx(vHandle, IntPtr.Zero, "Shell Embedding", null);

            vHandle = FindWindowEx(vHandle, IntPtr.Zero, "Shell DocObject View", null);

            vHandle = FindWindowEx(vHandle, IntPtr.Zero, "Internet Explorer_Server", null);

            SendMessage(vHandle, WM_COMMAND, IDM_VIEWSOURCE, (int)formIntPtr);
        }


        #region 获取源码
        public static WebResponse DoGet(string url)
        {
            try
            {
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
                webRequest.Method = "get";
                //webRequest.CookieContainer = this.cookies;
                return webRequest.GetResponse();
            }
            catch (Exception)
            {

                throw;
            }

        }

        //根据响应返回字符串
        public static string GetHtml(WebResponse response, string encoding)
        {
            try
            {
                StreamReader stream = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(encoding));
                string strHtml = stream.ReadToEnd();
                stream.Close();
                return strHtml;
            }
            catch (Exception)
            {

                throw;
            }

        }

        #endregion


        #region 框选

        [ComVisible(true), StructLayout(LayoutKind.Sequential)]
        public struct tagRECT
        {
            [MarshalAs(UnmanagedType.I4)]
            public int Left;
            [MarshalAs(UnmanagedType.I4)]
            public int Top;
            [MarshalAs(UnmanagedType.I4)]
            public int Right;
            [MarshalAs(UnmanagedType.I4)]
            public int Bottom;
            public tagRECT(int left_, int top_, int right_, int bottom_)
            {
                Left = left_;
                Top = top_;
                Right = right_;
                Bottom = bottom_;
            }
        }


        struct HRESULT
        {
            public const int S_OK = 0;
            public const int S_FALSE = 1;
            public const int E_NOTIMPL = unchecked((int)0x80004001);
            public const int E_INVALIDARG = unchecked((int)0x80070057);
            public const int E_NOINTERFACE = unchecked((int)0x80004002);
            public const int E_FAIL = unchecked((int)0x80004005);
            public const int E_UNEXPECTED = unchecked((int)0x8000FFFF);
        }
        public enum BEHAVIOR_EVENT : int
        {
            BEHAVIOREVENT_CONTENTREADY = 0,
            BEHAVIOREVENT_DOCUMENTREADY = 1,
            BEHAVIOREVENT_APPLYSTYLE = 2,
            BEHAVIOREVENT_DOCUMENTCONTEXTCHANGE = 3,
            BEHAVIOREVENT_CONTENTSAVE = 4
        }

        [ComImport(), Guid("3050F6A6-98B5-11CF-BB82-00AA00BDCE0B"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IHTMLPainter
        {
            void Draw([In, MarshalAs(UnmanagedType.I4)]	int leftBounds, [In, MarshalAs(UnmanagedType.I4)] int topBounds,
                [In, MarshalAs(UnmanagedType.I4)] int rightBounds, [In, MarshalAs(UnmanagedType.I4)] int bottomBounds,
                [In, MarshalAs(UnmanagedType.I4)] int leftUpdate, [In, MarshalAs(UnmanagedType.I4)] int topUpdate,
                [In, MarshalAs(UnmanagedType.I4)] int rightUpdate, [In, MarshalAs(UnmanagedType.I4)]	int bottomUpdate,
                 [In, MarshalAs(UnmanagedType.U4)] int lDrawFlags, [In] IntPtr hdc, [In]	IntPtr pvDrawObject);
            void _OnResize([In, MarshalAs(UnmanagedType.I4)] int cx, [In, MarshalAs(UnmanagedType.I4)]int cy);
            void GetPainterInfo([Out] out HTML_PAINTER_INFO htmlPainterInfo);
            void HitTestPoint([In, MarshalAs(UnmanagedType.I4)]	int ptx, [In, MarshalAs(UnmanagedType.I4)] int pty,
                 [Out, MarshalAs(UnmanagedType.I4)] out int pbHit, [Out, MarshalAs(UnmanagedType.I4)]	out int plPartID);
        }

        [ComImport(), Guid("3050f6a7-98b5-11cf-bb82-00aa00bdce0b"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IHTMLPaintSite
        {
            void InvalidatePainterInfo();
            void InvalidateRect([In] IntPtr pRect);
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct HTML_PAINTER_INFO
        {
            [MarshalAs(UnmanagedType.I4)]
            public int lFlags;
            [MarshalAs(UnmanagedType.I4)]
            public int lZOrder;
            [MarshalAs(UnmanagedType.Struct)]
            public Guid iidDrawObject;
            [MarshalAs(UnmanagedType.Struct)]
            public RECT rcBounds;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;

            public RECT(int left, int top, int right, int bottom)
            {
                this.left = left;
                this.top = top;
                this.right = right;
                this.bottom = bottom;
            }

            public static RECT FromXYWH(int x, int y, int width, int height)
            {
                return new RECT(x, y, x + width, y + height);
            }
        }
        [ComImport(), Guid("3050F427-98B5-11CF-BB82-00AA00BDCE0B"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IElementBehaviorSite
        {
            [return: MarshalAs(UnmanagedType.Interface)]
            mshtml.IHTMLElement GetElement();
            void RegisterNotification([In, MarshalAs(UnmanagedType.I4)]BEHAVIOR_EVENT lEvent);
        }

        private static IElementBehaviorSite _behaviorSite;
        public static IHTMLPaintSite PaintSite
        {
            get
            {
                return (IHTMLPaintSite)_behaviorSite;
            }
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern IntPtr GetWindow(IntPtr hWnd, uint uCmd);
        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
        public static extern bool InvalidateRect(IntPtr hwnd, ref tagRECT lpRect, bool bErase);


        /// <summary>
        /// 通过已有元素和事件信息计算节点的位置
        /// 已知BUG: www.paipai.com, 有些地方计算的结果不准确
        /// </summary>
        /// <param name="doc">document对象</param>
        /// <param name="elem">当前元素</param>
        /// <param name="e">鼠标事件</param>
        /// <returns></returns>
        public static Rectangle getElementPosFromPoint(HtmlDocument doc, HtmlElement elem, HtmlElementEventArgs e)
        {
            Rectangle ret = new Rectangle();
            // 为A 或者只有文本的节点，判断边界（TODO: 最好用二分法判断）
            if (/*elem.TagName.Equals("A") || */(elem.Children.Count == 0 && elem.InnerText != null && elem.InnerText.Length > 0))
            {
                int lowX = e.ClientMousePosition.X - elem.OffsetRectangle.Width;
                if (lowX < 0)
                    lowX = 0;
                int highX = e.ClientMousePosition.X + elem.OffsetRectangle.Width;

                int lowY = e.ClientMousePosition.Y - elem.OffsetRectangle.Height;
                if (lowY < 0)
                    lowY = 0;
                int highY = e.ClientMousePosition.Y + elem.OffsetRectangle.Height;
                Point p = new Point();
                for (int i = e.ClientMousePosition.X; i >= lowX; i--)
                {
                    p.X = i;
                    p.Y = e.ClientMousePosition.Y;
                    if (elem != doc.GetElementFromPoint(p))
                        break;
                }
                int realLowX = p.X;
                for (int i = e.ClientMousePosition.X; i < highX; i++)
                {
                    p.X = i;
                    p.Y = e.ClientMousePosition.Y;
                    if (elem != doc.GetElementFromPoint(p))
                        break;
                }
                int realHighX = p.X;
                for (int j = e.ClientMousePosition.Y; j >= lowY; j--)
                {
                    p.X = e.ClientMousePosition.X;
                    p.Y = j;
                    if (elem != doc.GetElementFromPoint(p))
                        break;
                }
                int realLowY = p.Y;
                for (int j = e.ClientMousePosition.Y; j <= highY; j++)
                {
                    p.X = e.ClientMousePosition.X;
                    p.Y = j;
                    if (elem != doc.GetElementFromPoint(p))
                        break;
                }
                int realHighY = p.Y;
                ret.X = realLowX;
                ret.Y = realLowY;
                ret.Width = realHighX - realLowX;
                ret.Height = realHighY - realLowY;
            }
            else
            {
                // 采用mouse off set判断边界
                int x = e.ClientMousePosition.X - e.OffsetMousePosition.X - elem.ClientRectangle.Left;
                int y = e.ClientMousePosition.Y - e.OffsetMousePosition.Y - elem.ClientRectangle.Top;
                int w = elem.OffsetRectangle.Width; // notice：w可能比上面计算出来的ret.Width小；
                int h = elem.OffsetRectangle.Height; //notice：h可能比上面计算出来的ret.Height小；
                // 计算出错（即不包含鼠标点击的位置），则采用标准的排版计算方式
                // TODO: 如果可以最好计算上面已经计算的ret结果是否包含在新范围内
                //if (x > ret.X + 2 || y > ret.Y + 2 || x + w < ret.X + ret.Width - 2 || y + h < ret.Y + ret.Height - 2)
                if (x + w < e.ClientMousePosition.X ||
                    y + h < e.ClientMousePosition.Y)
                {
                    HtmlElement cur = elem;
                    x = 0;
                    y = 0;
                    while (cur != null)
                    {
                        x += cur.OffsetRectangle.Left - cur.ScrollLeft; // TODO: 需要加上style.borderLeftWidth
                        y += cur.OffsetRectangle.Top - cur.ScrollTop;
                        cur = cur.OffsetParent;
                    }
                    // 把坐标映射到当前窗口
                    //mshtml.IHTMLDocument3 doc3 = doc.DomDocument as mshtml.IHTMLDocument3;
                    //mshtml.IHTMLElement2 docElem2 = doc3.documentElement as mshtml.IHTMLElement2;
                    //x -= docElem2.scrollLeft;
                    //y -= docElem2.scrollTop;
                    x -= doc.Body.Parent.ScrollLeft;
                    y -= doc.Body.Parent.ScrollTop;
                }
                // 计算出错（即不包含鼠标点击的位置），采用已经计算的结果
                // TODO: 如果可以最好计算上面已经计算的ret结果是否包含在新范围内
                //if (x > ret.X + 2 || y > ret.Y + 2 || x + w < ret.X + ret.Width - 2 || y + h < ret.Y + ret.Height - 2)
                if (x + w < e.ClientMousePosition.X ||
                    y + h < e.ClientMousePosition.Y)
                {
                }
                else
                {
                    ret.X = x;
                    ret.Y = y;
                    ret.Width = w;
                    ret.Height = h;
                }
            }
            return ret;
        }

       
        #endregion


    }
}
