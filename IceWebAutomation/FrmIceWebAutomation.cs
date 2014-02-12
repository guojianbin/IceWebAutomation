using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using mshtml;
using System.IO;
using System.Xml;
namespace IceWebAutomation
{
    public partial class FrmIceWebAutomation : Form
    {
        public FrmIceWebAutomation()
        {
            InitializeComponent();
            objFrmInputParams = new FrmInputParams();
            objFrmInputParams.Owner = this;

            objFrmInputInvokeScript = new FrmInputInvokeScript();
            objFrmInputInvokeScript.Owner = this;

            objFrmInputImgInfo = new FrmInputImgInfo();
            objFrmInputImgInfo.Owner = this;

            objFrmShowImage = new FrmShowImage();
            objFrmShowImage.Owner = this;
        }

        string strCache = string.Empty;
        IntPtr m_hwnd;
        Pen m_browserPen;
        Rectangle elemRect;
        HtmlElement currentElement;
        string FilePath = string.Empty;
        bool canDrawSelected = false;
        FrmInputParams objFrmInputParams = null;
        FrmInputInvokeScript objFrmInputInvokeScript = null;
        FrmInputImgInfo objFrmInputImgInfo = null;
        FrmShowImage objFrmShowImage = null;
        string currentElementXPath = string.Empty;
        string imgIdName, imgSrc, imgAlt;

        //浏览历史文件，记录
        public string HisXml = Application.StartupPath + "\\History.xml";


        private void FrmIceWebAutomation_Load(object sender, EventArgs e)
        {
            LoadUrl();
            tsbSelectElement.Enabled = false;
            //webBrowser1.Url = new Uri("http://www.baidu.com");

            webBrowser1.Navigate(cbbUrl.Text);
            webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);

            //注册快捷键
            HotKeyHelper.RegShortcutToHandle(this.Handle, "Ctrl+Alt+E", 1001);
            HotKeyHelper.RegShortcutToHandle(this.Handle, "Ctrl+Alt+D", 1002);

        }

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
                        case 1001:
                            tsbSelectElement.PerformClick();
                            break;
                        case 1002:
                            tsbShowDevelop.PerformClick();
                            break;


                    }
                    break;
            }
            base.WndProc(ref m);
        }

        private void WebBrowser_NewWindow(object sender, CancelEventArgs e)
        {
            // WebBrowser webb = new WebBrowser();

            //// WebBrowser = WebBrowserArr[tbcMultiWebBrowser.SelectedIndex];

            // webb.Name = "webb" + tbcMultiWebBrowser.TabCount;

            // Uri a = new Uri(WebBrowserArr[tbcMultiWebBrowser.SelectedIndex].Document.ActiveElement.GetAttribute("href"));

            // webb.Url = a;

            // webb.Dock = DockStyle.Fill;

            // TabPage p = new TabPage();

            // p.Controls.Add(webb);

            // tbcMultiWebBrowser.TabPages.Add(p);

            // tbcMultiWebBrowser.SelectedTab = p;

            // webb.NewWindow += new CancelEventHandler(WebBrowser_NewWindow);


            // e.Cancel = true;//取消在默认浏览器中打开  


        }

        void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

            // webBrowser1.Document.Encoding = "gb2312";
            // strCache = webBrowser1.DocumentText ;
            tsbSelectElement.Enabled = true;
            //webBrowser1.Document.Click += Document_Click;
            webBrowser1.Document.MouseOver += new HtmlElementEventHandler(Document_MouseOver);
            webBrowser1.Document.MouseMove += new HtmlElementEventHandler(Document_MouseMove);

            //webBrowser1.Document.MouseLeave += new HtmlElementEventHandler(Document_MouseLeave);
            m_hwnd = webBrowser1.Handle;
            m_hwnd = WebAPI.GetWindow(m_hwnd, (uint)5); // shell
            m_hwnd = WebAPI.GetWindow(m_hwnd, (uint)5); // doc obj
            m_hwnd = WebAPI.GetWindow(m_hwnd, (uint)5); // window
            m_browserPen = new Pen(Color.Red, 2);


            InvokeHelper.Set(rtxtSourceCode, "Text", HtmlCodeFormat.Format(webBrowser1.DocumentText));


        }

        void Document_MouseUp(object sender, HtmlElementEventArgs e)
        {
        }

        void Document_Click(object sender, HtmlElementEventArgs e)
        {
            tsbSelectElement.PerformClick();
        }

        void Document_MouseOver(object sender, HtmlElementEventArgs e)
        {
            currentElement = webBrowser1.Document.GetElementFromPoint(e.ClientMousePosition);
            if (canDrawSelected == true)
            {

                Point p = WebAutomationHelper.GetOffset(currentElement);
                Point pClient = currentElement.OffsetRectangle.Location;
                int width = currentElement.OffsetRectangle.Width;
                int height = currentElement.OffsetRectangle.Height;
                // 画框
                Graphics g = Graphics.FromHwnd(m_hwnd);
                // g.DrawRectangle(m_browserPen, m_elemRect);
                elemRect = new Rectangle(pClient.X, pClient.Y, width, height);
                g.DrawRectangle(m_browserPen, p.X, p.Y, width, height);
                g.Dispose();
                rtxtConsoleText.Text += (pClient.X + "," + pClient.Y + "," + width + "," + height) + "\n";
                rtxtConsoleText.Select(rtxtSourceCode.TextLength, 0);
                rtxtConsoleText.ScrollToCaret();
            }



            string path = "";
            HtmlElement elem = webBrowser1.Document.GetElementFromPoint(e.ClientMousePosition);
            path = WebAutomationHelper.GetElementXPath(elem);
            txtElementXPath.Text = path;
            currentElementXPath = path;
            InvokeHelper.Set(txtElementXPath, "Text", path);

            System.Threading.Thread.Sleep(200);
            //IHTMLDocument2 document = (IHTMLDocument2)webBrowser1.Document.DomDocument;
            //IHTMLControlElement htmlElem = (IHTMLControlElement)document.onmousemove;
            //txtElementCode.Text = IceFormater.ConvertToXml(elem.OuterHtml, true);
            InvokeHelper.Set(txtElementCode, "Text", HtmlCodeFormat.Format(elem.OuterHtml));
        }

        void Document_MouseLeave(object sender, HtmlElementEventArgs e)
        {

        }


        void Document_MouseMove(object sender, HtmlElementEventArgs e)
        {
            if (canDrawSelected == true)
            {
                HtmlElement element = webBrowser1.Document.GetElementFromPoint(e.ClientMousePosition);
                Point pClient = element.OffsetRectangle.Location;

                if (elemRect.Contains(pClient))
                {
                    //
                    rtxtConsoleText.Text += (pClient.X + "," + pClient.Y) + "\n";
                    rtxtConsoleText.Select(rtxtSourceCode.TextLength, 0);
                    rtxtConsoleText.ScrollToCaret();
                }
                else
                {
                    WebAPI.tagRECT rect = new WebAPI.tagRECT(0, 0, webBrowser1.Width, webBrowser1.Height);
                    WebAPI.InvalidateRect(m_hwnd, ref rect, false);
                }


            }

        }



        private void tsbExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmIceWebAutomation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                if (this.splitContainer1.Panel2Collapsed)
                {
                    this.splitContainer1.Panel2Collapsed = false;
                }
                else
                {
                    this.splitContainer1.Panel2Collapsed = true;
                }
            }
        }


        private void tsbSelectElement_Click(object sender, EventArgs e)
        {
            if (canDrawSelected == false)
            {
                //webBrowser1.Document.Click += Document_Click;
                //webBrowser1.Document.MouseOver += new HtmlElementEventHandler(Document_MouseOver);
                //webBrowser1.Document.MouseMove += new HtmlElementEventHandler(Document_MouseMove);
                canDrawSelected = true;
            }
            else
            {
                //webBrowser1.Document.Click -= Document_Click;
                //webBrowser1.Document.MouseOver -= new HtmlElementEventHandler(Document_MouseOver);
                //webBrowser1.Document.MouseMove -= new HtmlElementEventHandler(Document_MouseMove);
                canDrawSelected = false;
            }
        }

        private void tsbTaskScriptClear_Click(object sender, EventArgs e)
        {
            rtxtTaskScript.Clear();
        }

        private void tsbTaskScriptNew_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "IceWebAutomation文件|*.txt";
            saveFileDialog1.Title = "新建IceWebAutomation命令文件";
            //saveFileDialog1.InitialDirectory = Environment.CurrentDirectory;
            saveFileDialog1.FileName = "";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FilePath = saveFileDialog1.FileName;
                try
                {
                    StreamWriter sw = new StreamWriter(FilePath);
                    rtxtTaskScript.Text = "";
                    sw.Close();
                }
                catch (Exception ee)
                {
                    FilePath = "";
                    MessageBox.Show(ee.Message);
                }

            }
        }

        private void tsbTaskScriptOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "IceWebAutomation文件|*.txt";
            openFileDialog1.Title = "打开IceWebAutomation命令文件";
            //openFileDialog1.InitialDirectory = Environment.CurrentDirectory;
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FilePath = openFileDialog1.FileName;
                try
                {
                    StreamReader sr = new StreamReader(FilePath);
                    //Browser.TV.Nodes.Clear();
                    string BodyText = sr.ReadToEnd();
                    sr.Close();
                    //Browser.TC.Text = BodyText;
                    rtxtTaskScript.Text = BodyText;
                }
                catch (Exception ee)
                {
                    FilePath = "";
                    MessageBox.Show(ee.Message);
                }
            }
        }

        private void tsbTaskScriptSave_Click(object sender, EventArgs e)
        {
            if (FilePath != "")
            {
                try
                {
                    StreamWriter sw = new StreamWriter(FilePath);
                    sw.Write(rtxtTaskScript.Text);
                    sw.Close();
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                }
            }
        }

        private void tsbTaskScriptExcute_Click(object sender, EventArgs e)
        {
            tsbTaskScriptNew.Enabled = false;
            tsbTaskScriptOpen.Enabled = false;
            tsbTaskScriptClear.Enabled = false;
            tsbTaskScriptSave.Enabled = false;
            this.rtxtTaskScript.ReadOnly = true;
            tbcIceAutomation.SelectedTab = tpAutoTask;

            //WebAutomationTasks.ExecScriptTask.Execute(webBrowser1, "GetRandImg()");


            CommandQueue EC = new CommandQueue(rtxtTaskScript.Text, webBrowser1, objFrmShowImage, this);
            EC.Execute();         

        }

        private void tsbTaskScriptStop_Click(object sender, EventArgs e)
        {
            tsbTaskScriptNew.Enabled = true;
            tsbTaskScriptOpen.Enabled = true;
            tsbTaskScriptClear.Enabled = true;
            tsbTaskScriptSave.Enabled = true;
            tbcIceAutomation.SelectedTab = tpAutoTask;
            //EC.Stop = true;
            this.rtxtTaskScript.ReadOnly = false;
            //this.numericUpDown1.ReadOnly = false;
            //this.txtCode.BackColor = Color.AntiqueWhite;
            //tabControl1.SelectedTab = tabControl1.TabPages[0];
        }

        /// <summary>
        /// 解析当前Xpath元素
        /// </summary>
        /// <returns></returns>
        private HtmlElement ParseCurrentXPath()
        {
            // GetHtmlNodeByXPath
            string path = "";
            path = WebAutomationHelper.GetElementXPath(currentElement);
            // MessageBox.Show(path);

            HtmlElement elem = WebAutomationHelper.ParseElementByXPath(webBrowser1.Document.Body, path);
            // MessageBox.Show(elem.OuterHtml);
            return elem;
        }


        #region 填写命令

        private void tsmiTaskGO_Click(object sender, EventArgs e)
        {
            objFrmInputParams.InitValue = webBrowser1.Url.AbsoluteUri;
            objFrmInputParams.ReturnValue = "";
            objFrmInputParams.StartPosition = FormStartPosition.CenterScreen;
            objFrmInputParams.lblTips.Text = "输入跳转Url";
            if (objFrmInputParams.ShowDialog() == DialogResult.OK)
            {
                rtxtTaskScript.Text += "Go(" + objFrmInputParams.ReturnValue + ");" + System.Environment.NewLine;
                objFrmInputParams.Hide();
            }

        }

        private void tsmiTaskFill_Click(object sender, EventArgs e)
        {
            objFrmInputParams.InitValue = "";
            objFrmInputParams.ReturnValue = "";
            objFrmInputParams.StartPosition = FormStartPosition.CenterScreen;
            objFrmInputParams.lblTips.Text = "输入参数";
            if (objFrmInputParams.ShowDialog() == DialogResult.OK)
            {
                rtxtTaskScript.Text += "Fill(" + currentElementXPath + "," + objFrmInputParams.ReturnValue + ");" + System.Environment.NewLine;
                objFrmInputParams.Hide();
            }
        }

        private void tsmiTaskClick_Click(object sender, EventArgs e)
        {
            rtxtTaskScript.Text += "Click(" + currentElementXPath + ");" + System.Environment.NewLine;
        }

        private void tsmiTaskSleep_Click(object sender, EventArgs e)
        {
            objFrmInputParams.InitValue = "2000";
            objFrmInputParams.ReturnValue = "";
            objFrmInputParams.StartPosition = FormStartPosition.CenterScreen;
            objFrmInputParams.lblTips.Text = "输入等待时间（单位毫秒）";
            if (objFrmInputParams.ShowDialog() == DialogResult.OK)
            {
                rtxtTaskScript.Text += "Sleep(" + objFrmInputParams.ReturnValue + ");" + System.Environment.NewLine;
                objFrmInputParams.Hide();
            }
        }

        private void tsmiSelectDropDown_Click(object sender, EventArgs e)
        {
            objFrmInputParams.InitValue = "";
            objFrmInputParams.ReturnValue = "";
            objFrmInputParams.StartPosition = FormStartPosition.CenterScreen;
            objFrmInputParams.lblTips.Text = "输入选项值";
            if (objFrmInputParams.ShowDialog() == DialogResult.OK)
            {
                rtxtTaskScript.Text += "SelectDropDown(" + currentElementXPath + "," + objFrmInputParams.ReturnValue + ");" + System.Environment.NewLine;
                objFrmInputParams.Hide();
            }
        }
        private void tsmiClickLink_Click(object sender, EventArgs e)
        {
            rtxtTaskScript.Text += "ClickLink(" + currentElementXPath + ");" + System.Environment.NewLine;
        }
        private void tsmiFillById_Click(object sender, EventArgs e)
        {
            objFrmInputParams.InitValue = "";
            objFrmInputParams.ReturnValue = "";
            objFrmInputParams.StartPosition = FormStartPosition.CenterScreen;
            objFrmInputParams.lblTips.Text = "输入参数";
            if (objFrmInputParams.ShowDialog() == DialogResult.OK)
            {
                rtxtTaskScript.Text += "FillById(" + currentElement.Id + "," + objFrmInputParams.ReturnValue + ");" + System.Environment.NewLine;
                objFrmInputParams.Hide();
            }
        }

        private void tsmiClickById_Click(object sender, EventArgs e)
        {
            rtxtTaskScript.Text += "ClickById(" + currentElement.Id + ");" + System.Environment.NewLine;
        }

        private void tsmiClickByName_Click(object sender, EventArgs e)
        {
            rtxtTaskScript.Text += "ClickByName(" + currentElement.Name + ");" + System.Environment.NewLine;
        }

        private void tsmiFillByName_Click(object sender, EventArgs e)
        {
            objFrmInputParams.InitValue = "";
            objFrmInputParams.ReturnValue = "";
            objFrmInputParams.StartPosition = FormStartPosition.CenterScreen;
            objFrmInputParams.lblTips.Text = "输入参数";
            if (objFrmInputParams.ShowDialog() == DialogResult.OK)
            {
                rtxtTaskScript.Text += "FillByName(" + currentElement.Id + "," + objFrmInputParams.ReturnValue + ");" + System.Environment.NewLine;
                objFrmInputParams.Hide();
            }
        }

        private void tsmiSelectRadio_Click(object sender, EventArgs e)
        {
            rtxtTaskScript.Text += "SelectRadio(" + currentElementXPath + ");" + System.Environment.NewLine;
        }


        private void tsmiExecuteJs_Click(object sender, EventArgs e)
        {
            objFrmInputInvokeScript.InitValue = HtmlCodeFormat.Format(currentElement.OuterHtml);
            objFrmInputInvokeScript.ReturnMethodValue = "";
            objFrmInputInvokeScript.ReturnParamsValue = "";
            objFrmInputInvokeScript.StartPosition = FormStartPosition.CenterScreen;
            if (objFrmInputInvokeScript.ShowDialog() == DialogResult.OK)
            {
                rtxtTaskScript.Text += "ExcuteJs(" + objFrmInputInvokeScript.ReturnMethodValue + "," + objFrmInputInvokeScript.ReturnParamsValue + ");" + System.Environment.NewLine;
                objFrmInputInvokeScript.Hide();
            }

        }

        private void tsmiGetImg_Click(object sender, EventArgs e)
        {
            objFrmInputImgInfo.InitValue = HtmlCodeFormat.Format(currentElement.OuterHtml);
            objFrmInputImgInfo.ReturnIdNameValue = "";
            objFrmInputImgInfo.ReturnSrcValue = "";
            objFrmInputImgInfo.ReturnAltValue = "";
            objFrmInputImgInfo.StartPosition = FormStartPosition.CenterScreen;
            if (objFrmInputImgInfo.ShowDialog() == DialogResult.OK)
            {
                imgIdName = objFrmInputImgInfo.ReturnIdNameValue;
                imgSrc = objFrmInputImgInfo.ReturnSrcValue;
                imgAlt = objFrmInputImgInfo.ReturnAltValue;
                //rtxtTaskScript.Text += "GetImg(" + objFrmInputImgInfo.ReturnIdNameValue + "," + objFrmInputImgInfo.ReturnSrcValue + "," + objFrmInputImgInfo.ReturnAltValue + ");" + System.Environment.NewLine;
                //Image img = WebAutomationHelper.GetRegCodePic(webBrowser1, objFrmInputImgInfo.ReturnIdNameValue, objFrmInputImgInfo.ReturnSrcValue, objFrmInputImgInfo.ReturnAltValue);
                //objFrmShowImage.ImageSource = img;
                //objFrmShowImage.ShowDialog();
                objFrmInputImgInfo.Hide();

            }
        }
        private void tsmiExecScript_Click(object sender, EventArgs e)
        {
            rtxtTaskScript.Text += "ExecScript(" + "GetRandImg()" + ");" + System.Environment.NewLine;
        }

        private void tsmiGetImage_Click(object sender, EventArgs e)
        {
            Image img = WebAutomationHelper.GetRegCodePic(webBrowser1, currentElement);
            objFrmShowImage.picbSource.Image = img;
            objFrmShowImage.Show();
        }


        #endregion



        #region 浏览器操作
        private void LoadUrl()
        {

            //加载浏览历史
            if (!File.Exists(HisXml))
            {
                CreateConfigXml(HisXml);
            }
            else
            {
                string[] urls = ReadConfigXml(HisXml);

                if (urls.Length > 0)
                {
                    for (int i = 0; i < urls.Length; i++)
                    {
                        cbbUrl.AutoCompleteCustomSource.Add(urls[i]);

                        cbbUrl.Items.Add(urls[i]);
                    }

                    // cmbUrl.AutoCompleteMode = AutoCompleteMode.Suggest;

                    // cmbUrl.AutoCompleteSource = AutoCompleteSource.ListItems;
                }
            }
        }

        //创建xml文件
        void CreateConfigXml(string xmlFile)
        {
            XmlTextWriter xmlW = new XmlTextWriter(xmlFile, Encoding.UTF8);

            xmlW.WriteStartDocument();

            xmlW.WriteStartElement("Histories");

            xmlW.WriteEndElement();

            xmlW.Close();
        }

        //读历史文件
        string[] ReadConfigXml(string xmlFile)
        {
            if (File.Exists(xmlFile))
            {
                XmlDocument doc = new XmlDocument();

                doc.Load(xmlFile);

                XmlElement root = doc.DocumentElement;

                if (root.HasChildNodes)
                {
                    string[] xmlHis = new string[root.ChildNodes.Count];

                    for (int i = 0; i < root.ChildNodes.Count; i++)
                    {
                        xmlHis[i] = root.ChildNodes[i].ChildNodes[0].InnerText;
                    }
                    return xmlHis;
                }
                else
                {
                    return new string[] { };
                }
            }
            else
            {
                return new string[] { };
            }

        }


        private void cbbUrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                NavToUrl(this.cbbUrl.Text.Trim().ToString());
            }
        }

        //转换为url格式
        void NavToUrl(string strUrl)
        {
            if (!strUrl.StartsWith("http://") && strUrl.Trim().Substring(1, 1) != ":")
            {
                strUrl = "http://" + strUrl;

                this.cbbUrl.Text = strUrl;
            }
            webBrowser1.Navigate(strUrl);
        }

        private void btnGoToPage_Click(object sender, EventArgs e)
        {
            if (this.cbbUrl.Text.Trim().Length > 0)
            {
                NavToUrl(this.cbbUrl.Text.ToString().Trim());
            }
        }

        private void tsWbGoBack_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void tsWbGoForward_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void tsWbRefresh_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }

        private void tsWbStop_Click(object sender, EventArgs e)
        {
            webBrowser1.Stop();
        }

        private void tsWbHomePage_Click(object sender, EventArgs e)
        {
            webBrowser1.GoHome();
        }
        private void tsWbSaveDialog_Click(object sender, EventArgs e)
        {
            webBrowser1.ShowSaveAsDialog();
        }

        private void tsWbShowSource_Click(object sender, EventArgs e)
        {
            WebAPI.ShowSource(webBrowser1.Handle, this.Handle);

        }
        #endregion



        private void tsbShowDevelop_Click(object sender, EventArgs e)
        {
            if (this.splitContainer1.Panel2Collapsed)
            {
                this.splitContainer1.Panel2Collapsed = false;
            }
            else
            {
                this.splitContainer1.Panel2Collapsed = true;
            }
        }

        private void tsbAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("自动化脚本工具\n作者:郭建斌\n联系:632628489", "关于...");
        }

        private void tsbTaskScriptGetPic_Click(object sender, EventArgs e)
        {
            //ExcuteJs(GetRandImg,);

            //Image img = WebAutomationHelper.GetRegCodePic(webBrowser1, objFrmInputImgInfo.ReturnIdNameValue, objFrmInputImgInfo.ReturnSrcValue, objFrmInputImgInfo.ReturnAltValue);
            //objFrmShowImage.picbSource.Image = img;
            //objFrmShowImage.Show();

            HtmlElement elem = WebAutomationHelper.ParseElementByXPath(webBrowser1.Document.Body, "HTML/BODY/FORM/DIV[3]/DIV[2]/DIV/DIV/DIV[2]/TABLE/TBODY/TR[7]/TD[2]/IMG");

            Image img = WebAutomationHelper.GetRegCodePic(webBrowser1, elem);
            objFrmShowImage.picbSource.Image = img;
            objFrmShowImage.Show();

        }

        private void cbbUrl_Click(object sender, EventArgs e)
        {
            cbbUrl.Show();
        }

       
    







    }




}