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
       
        #region 读取元素

        #region 获取点击中的链接地址
        /// <summary>
        /// 获取点击中的链接地址
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


       
        //根据Name获取元素
        public HtmlElement GetElementByName(WebBrowser wb, string Name)
        {
            HtmlElement e = wb.Document.All[Name];
            return e;
        }

        //根据Id获取元素
        public HtmlElement GetElementById(WebBrowser wb, string id)
        {
            HtmlElement e = wb.Document.GetElementById(id);
            return e;
        }

        //根据Index获取元素
        public HtmlElement GetElementByIndex(WebBrowser wb, int index)
        {
            HtmlElement e = wb.Document.All[index];
            return e;
        }

        //获取form表单名name,返回表单
        public HtmlElement GetElementByFormName(WebBrowser wb, string form_name)
        {
            HtmlElement e = wb.Document.Forms[form_name];
            return e;
        }
        /// <summary>
        /// 获取具有HTML标记的元素集合
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
        /// 根据工作区坐标获取元素
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

        #region 设置元素

        #region 关闭错误显示
        /// <summary>
        /// 关闭错误显示
        /// </summary>
        /// <param name="wb"></param>
        public static void SetScriptErrorsSuppressed(WebBrowser wb)
        {
            wb.ScriptErrorsSuppressed = true; //关闭错误显示
        }
         #endregion

        //设置元素value属性的值
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

        #region 操作

        //执行元素的方法，如：click，submit(需Form表单名)等
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
        /// 获取元素XPath
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
        /// 解析XPATH为HtmlElement
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
        /// 获得webbrowser网页里某元素所占用的位置坐标
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

        #region 获取验证码


        #region How to use
        /*
         
            示例1:
            下面是某个站的注册码图片的HTML部分源代码
            <IMG height=80 alt="Registration Verification Code" src="......" width=290 border=0>
            picturebox1.Image =GetRegCodePic(wbMail, "", "", "Registration Verification Code")

            示例2:
            下面是某个站的注册码图片的HTML部分源代码
            <IMG id=CAPTCHAImage src="......." name=CAPTCHAImage>
            picturebox1.Image =GetRegCodePic(wbMail, "CAPTCHAImage", "", "")  //通过验证码Html元素的名字来
         
         */
        #endregion

        /// <summary>
        /// 获取验证码图片
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
            if (ImgName == "") //如果没有图片的名字,通过Src或Alt中的关键字来取
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
            IHTMLControlElement Img = (IHTMLControlElement)ImgeTag.DomElement; //图片地址

            Image oldImage = Clipboard.GetImage();
            rang.add(Img);
            rang.execCommand("Copy", false, null);  //拷贝到内存
            Image numImage = Clipboard.GetImage();
            Clipboard.Clear();
            return numImage;

        }

        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <param name="wbMail"></param>
        /// <param name="Src"></param>
        /// <param name="Alt"></param>
        /// <returns></returns>
        public static int GetPicIndex(WebBrowser wbMail, string Src, string Alt)
        {
            int imgnum = -1;
            for (int i = 0; i < wbMail.Document.Images.Count; i++)　//获取所有的Image元素
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
