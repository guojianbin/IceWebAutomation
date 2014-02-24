using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using mshtml;
using System.Drawing;
namespace IceWebAutomation
{
    public class WebAutomationHelper
    {
       
        #region ��ȡԪ��

        #region ��ȡ����е����ӵ�ַ
        /// <summary>
        /// ��ȡ����е����ӵ�ַ
        /// </summary>
        /// <param name="wb"></param>
        /// <returns></returns>
        public static Uri GetHref(WebBrowser wb)
        {
            Uri a = new Uri(wb.Document.ActiveElement.GetAttribute("href"));
            return a;
        }
        #endregion

        public string GetStyle(HtmlElement e)
        {
            return e.Style;
        }


       
        //����Name��ȡԪ��
        public HtmlElement GetElementByName(WebBrowser wb, string Name)
        {
            HtmlElement e = wb.Document.All[Name];
            return e;
        }

        //����Id��ȡԪ��
        public HtmlElement GetElementById(WebBrowser wb, string id)
        {
            HtmlElement e = wb.Document.GetElementById(id);
            return e;
        }

        //����Index��ȡԪ��
        public HtmlElement GetElementByIndex(WebBrowser wb, int index)
        {
            HtmlElement e = wb.Document.All[index];
            return e;
        }

        //��ȡform����name,���ر�
        public HtmlElement GetElementByFormName(WebBrowser wb, string form_name)
        {
            HtmlElement e = wb.Document.Forms[form_name];
            return e;
        }
        /// <summary>
        /// ��ȡ����HTML��ǵ�Ԫ�ؼ���
        /// </summary>
        /// <param name="wb"></param>
        /// <param name="tagName"></param>
        /// <returns></returns>
        public HtmlElementCollection GetElementsByTagName(WebBrowser wb, string tagName)
        {
            HtmlElementCollection e = wb.Document.GetElementsByTagName(tagName);
            return e;
        }

        /// <summary>
        /// ���ݹ����������ȡԪ��
        /// </summary>
        /// <param name="wb"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        public HtmlElement GetElementFromPoint(WebBrowser wb, System.Drawing.Point point)
        {
            HtmlElement e = wb.Document.GetElementFromPoint(point);
            return e;
        }

        #endregion

        #region ����Ԫ��

        #region �رմ�����ʾ
        /// <summary>
        /// �رմ�����ʾ
        /// </summary>
        /// <param name="wb"></param>
        public static void SetScriptErrorsSuppressed(WebBrowser wb)
        {
            wb.ScriptErrorsSuppressed = true; //�رմ�����ʾ
        }
         #endregion

        //����Ԫ��value���Ե�ֵ
        public void SetValue(HtmlElement e, string value)
        {
            e.SetAttribute("value", value);
        }

        public void SetInnerText(HtmlElement e, string innerText)
        {
            e.InnerText = innerText;
        }

        public void SetInnerHtml(HtmlElement e, string innerHtml)
        {
            e.InnerHtml = innerHtml;
        }


        public void SetChecked(HtmlElement e, string checkedValue)
        {
            e.SetAttribute("Checked", checkedValue);//checkedValue = "True"
        }
        #endregion

        #region ����

        //ִ��Ԫ�صķ������磺click��submit(��Form����)��
        public static void InvokeMember(HtmlElement e, string method)
        {

            e.InvokeMember(method);
        }

        public static void InvokeMember(HtmlElement e, string method, object[] paras)
        {

            e.InvokeMember(method, paras);
        }

        public static HtmlDocument GetFrameDocument(WebBrowser wb, string frameName)
        {
            HtmlDocument docFrame = wb.Document.Window.Frames[frameName].Document;
            //HtmlDocument docFrame = webBrowser1.Document.All.Frames["mainFrame"].Document;
            return docFrame;
        }

        public static void NavigateNewURL(WebBrowser web, ref string address)
        {
            if (address.Equals("about:blank")) return;
            if (!address.StartsWith("http://")) address = "http://" + address;
            try
            {
                web.Navigate(new Uri(address));
            }
            catch (System.UriFormatException)
            {
                return;
            }
        }

        #endregion

        public static HtmlElement FindControlByName(WebBrowser wb, string name)
        {
            HtmlElementCollection listOfHtmlControls = wb.Document.All;
            foreach (HtmlElement element in listOfHtmlControls)
            {
                if (!string.IsNullOrEmpty(element.OuterHtml))
                {
                    if (element.Name == name.Trim())
                    {
                        return element;
                    }
                }
            }
            return null;
        }
        public static HtmlElement FindControlByID(WebBrowser wb, string name)
        {
            HtmlElementCollection listOfHtmlControls = wb.Document.All;
            foreach (HtmlElement element in listOfHtmlControls)
            {
                if (!string.IsNullOrEmpty(element.OuterHtml))
                {
                    if (element.Id == name.Trim())
                    {
                        return element;
                    }
                }
            }
            return null;
        }

        #region Get XPath
        /// <summary>
        /// ��ȡԪ��XPath
        /// </summary>
        /// <param name="element"></param>
        public static string GetElementXPath(HtmlElement element)
        {
            string path = string.Empty;
            int index = 1;
            for (; element != null; element = element.Parent)
            {
                if (element.TagName != "HEAD" && element.TagName != "HTML")
                {
                    index = GetIndexInParentChildren(element);
                    //HTML/BODY/DIV/DIV/DIV/P/IMG
                    if (index > 1)
                    {
                        path = element.TagName + "[" + index.ToString() + "]" + (path == "" ? "" : "/") + path;
                    }
                    else
                    {
                        path = element.TagName + (path == "" ? "" : "/") + path;
                    }
                }
                else
                {
                    path = element.TagName + (path == "" ? "" : "/") + path;
                }
                
            }
            return path;
        }

        private static int GetIndexInParentChildren(HtmlElement element)
        {
            int index = 1;
            if (element != null)
            {
                if (element.Parent.Children.Count > 0)
                {
                    foreach (HtmlElement child in element.Parent.Children)
                    {
                        if (child.TagName == element.TagName)
                        {
                            if (child == element)
                            {
                                return index;
                            }
                            index++;
                        }
                    }
                }
            }
            return index;
        }
        /// <summary>
        /// ����XPATHΪHtmlElement
        /// </summary>
        /// <param name="RootElement"></param>
        /// <param name="xPath"></param>
        /// <returns></returns>
        public static HtmlElement ParseElementByXPath(HtmlElement RootElement, string xPath)
        {
            HtmlElement element = RootElement;
            if (element != null)
            {
                if (xPath.Length > 0)
                {
                    //HTML/BODY/DIV/DIV/DIV[2]/P/IMG
                    string[] eles = xPath.Split('/');
                    
                    foreach (string ele in eles)
                    {
                        element = GetChildElementInPath(element, ele);
                    }
                }
            }
            return element;
        }

        private static HtmlElement GetChildElementInPath(HtmlElement Element, string tagIndex)
        {
            if (Element.CanHaveChildren == false)
            {
                return Element;
            }
            if (Element.Children.Count > 0)
            {
                string tagName;
                int index;
                int indexOfPre = tagIndex.IndexOf("[");
                 int indexOfSub = tagIndex.IndexOf("]");
                 if (indexOfPre > -1)
                 {
                     tagName = tagIndex.Substring(0, indexOfPre);
                     //div[2]
                     index = Convert.ToInt32( tagIndex.Substring(indexOfPre + 1, indexOfSub - indexOfPre - 1));
                 }
                 else
                 {
                     tagName = tagIndex;
                     index = 1;
                 }
                 int i = 1;
                foreach (HtmlElement element in Element.Children)
                {
                    if (element.TagName == tagName)
                    {
                        if (index == i)
                        {
                            return element;
                        }
                        i++;
                    }
                }
            }
            return Element;
        }

        #endregion

        /// <summary>
        /// ���webbrowser��ҳ��ĳԪ����ռ�õ�λ������
        /// </summary>
        /// <param name="el"></param>
        /// <returns></returns>
        public static Point GetOffset(HtmlElement el)
        {
            //get element pos
            Point pos = new Point(el.OffsetRectangle.Left, el.OffsetRectangle.Top);

            //get the parents pos
            HtmlElement tempEl = el.OffsetParent;
            while (tempEl != null)
            {
                pos.X += tempEl.OffsetRectangle.Left;
                pos.Y += tempEl.OffsetRectangle.Top;
                tempEl = tempEl.OffsetParent;
            }

            return pos;
        }

        #region ��ȡ��֤��


        #region How to use
        /*
         
            ʾ��1:
            ������ĳ��վ��ע����ͼƬ��HTML����Դ����
            <IMG height=80 alt="Registration Verification Code" src="......" width=290 border=0>
            picturebox1.Image =GetRegCodePic(wbMail, "", "", "Registration Verification Code")

            ʾ��2:
            ������ĳ��վ��ע����ͼƬ��HTML����Դ����
            <IMG id=CAPTCHAImage src="......." name=CAPTCHAImage>
            picturebox1.Image =GetRegCodePic(wbMail, "CAPTCHAImage", "", "")  //ͨ����֤��HtmlԪ�ص�������
         
         */
        #endregion

        /// <summary>
        /// ��ȡ��֤��ͼƬ
        /// </summary>
        /// <param name="wbMail"></param>
        /// <param name="ImgName"></param>
        /// <param name="Src"></param>
        /// <param name="Alt"></param>
        /// <returns></returns>
        public static Image GetRegCodePic(WebBrowser wbMail, string ImgName, string Src, string Alt)
        {
            HTMLDocument doc = (HTMLDocument)wbMail.Document.DomDocument;
            HTMLBody body = (HTMLBody)doc.body;
            IHTMLControlRange rang = (IHTMLControlRange)body.createControlRange();
            IHTMLControlElement Img;
            if (ImgName == "") //���û��ͼƬ������,ͨ��Src��Alt�еĹؼ�����ȡ
            {
                int ImgNum = GetPicIndex(wbMail, Src, Alt);
                if (ImgNum == -1) return null;
                Img = (IHTMLControlElement)wbMail.Document.Images[ImgNum].DomElement;
            }
            else
                Img = (IHTMLControlElement)wbMail.Document.All[ImgName].DomElement;
            rang.add(Img);
            rang.execCommand("Copy", false, null);
            Image RegImg = Clipboard.GetImage();
            Clipboard.Clear();
            return RegImg;
        }

        public static Image GetRegCodePic(WebBrowser wb, HtmlElement ImgeTag)
        {
            if (ImgeTag.TagName.ToUpper() != "IMG")
            {
                return null;
            }
            HTMLDocument doc = (HTMLDocument)wb.Document.DomDocument;
            HTMLBody body = (HTMLBody)doc.body;
            IHTMLControlRange rang = (IHTMLControlRange)body.createControlRange();
            IHTMLControlElement Img = (IHTMLControlElement)ImgeTag.DomElement; //ͼƬ��ַ

            Image oldImage = Clipboard.GetImage();
            rang.add(Img);
            rang.execCommand("Copy", false, null);  //�������ڴ�
            Image numImage = Clipboard.GetImage();
            Clipboard.Clear();
            return numImage;

        }

        /// <summary>
        /// ��ȡ��֤��
        /// </summary>
        /// <param name="wbMail"></param>
        /// <param name="Src"></param>
        /// <param name="Alt"></param>
        /// <returns></returns>
        public static int GetPicIndex(WebBrowser wbMail, string Src, string Alt)
        {
            int imgnum = -1;
            for (int i = 0; i < wbMail.Document.Images.Count; i++)��//��ȡ���е�ImageԪ��
            {
                IHTMLImgElement img = (IHTMLImgElement)wbMail.Document.Images[i].DomElement;
                if (Alt == "")
                {
                    if (img.src.Contains(Src)) return i;
                }
                else
                {
                    if (!string.IsNullOrEmpty(img.alt))
                    {
                        if (img.alt.Contains(Alt)) return i;
                    }
                }
            }
            return imgnum;
        }
        #endregion



    }
}
