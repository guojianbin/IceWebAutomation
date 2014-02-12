namespace IceWebAutomation
{
    partial class FrmIceWebAutomation
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmIceWebAutomation));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbSelectElement = new System.Windows.Forms.ToolStripButton();
            this.tsbShowDevelop = new System.Windows.Forms.ToolStripButton();
            this.tsbAbout = new System.Windows.Forms.ToolStripButton();
            this.tsbExit = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.ctmsTaskOperation = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiTaskGO = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTaskFill = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFillById = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFillByName = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTaskClick = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiClickById = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiClickByName = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiClickLink = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTaskSleep = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSelectDropDown = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSelectRadio = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExecuteJs = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGetImg = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGetImage = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExecScript = new System.Windows.Forms.ToolStripMenuItem();
            this.pnWBTool = new System.Windows.Forms.Panel();
            this.btnGoToPage = new System.Windows.Forms.Button();
            this.cbbUrl = new System.Windows.Forms.ComboBox();
            this.tsWBTool = new System.Windows.Forms.ToolStrip();
            this.tsWbGoBack = new System.Windows.Forms.ToolStripButton();
            this.tsWbGoForward = new System.Windows.Forms.ToolStripButton();
            this.tsWbRefresh = new System.Windows.Forms.ToolStripButton();
            this.tsWbStop = new System.Windows.Forms.ToolStripButton();
            this.tsWbHomePage = new System.Windows.Forms.ToolStripButton();
            this.tsWbShowSource = new System.Windows.Forms.ToolStripButton();
            this.tsWbSaveDialog = new System.Windows.Forms.ToolStripButton();
            this.tbcIceAutomation = new System.Windows.Forms.TabControl();
            this.tpAutoTask = new System.Windows.Forms.TabPage();
            this.rtxtTaskScript = new System.Windows.Forms.RichTextBox();
            this.tsTaskTool = new System.Windows.Forms.ToolStrip();
            this.tsbTaskScriptExcute = new System.Windows.Forms.ToolStripButton();
            this.tsbTaskScriptStop = new System.Windows.Forms.ToolStripButton();
            this.tsbTaskScriptNew = new System.Windows.Forms.ToolStripButton();
            this.tsbTaskScriptOpen = new System.Windows.Forms.ToolStripButton();
            this.tsbTaskScriptSave = new System.Windows.Forms.ToolStripButton();
            this.tsbTaskScriptClear = new System.Windows.Forms.ToolStripButton();
            this.tsbTaskScriptGetPic = new System.Windows.Forms.ToolStripButton();
            this.tpElements = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.txtElementCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtElementXPath = new System.Windows.Forms.TextBox();
            this.tpHtmlSource = new System.Windows.Forms.TabPage();
            this.rtxtSourceCode = new System.Windows.Forms.RichTextBox();
            this.tpConsole = new System.Windows.Forms.TabPage();
            this.rtxtConsoleText = new System.Windows.Forms.RichTextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsbpStatus = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.ctmsTaskOperation.SuspendLayout();
            this.pnWBTool.SuspendLayout();
            this.tsWBTool.SuspendLayout();
            this.tbcIceAutomation.SuspendLayout();
            this.tpAutoTask.SuspendLayout();
            this.tsTaskTool.SuspendLayout();
            this.tpElements.SuspendLayout();
            this.tpHtmlSource.SuspendLayout();
            this.tpConsole.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSelectElement,
            this.tsbShowDevelop,
            this.tsbAbout,
            this.tsbExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(686, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbSelectElement
            // 
            this.tsbSelectElement.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbSelectElement.Image = ((System.Drawing.Image)(resources.GetObject("tsbSelectElement.Image")));
            this.tsbSelectElement.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSelectElement.Name = "tsbSelectElement";
            this.tsbSelectElement.Size = new System.Drawing.Size(75, 22);
            this.tsbSelectElement.Text = "选取元素(&E)";
            this.tsbSelectElement.Click += new System.EventHandler(this.tsbSelectElement_Click);
            // 
            // tsbShowDevelop
            // 
            this.tsbShowDevelop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbShowDevelop.Image = ((System.Drawing.Image)(resources.GetObject("tsbShowDevelop.Image")));
            this.tsbShowDevelop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbShowDevelop.Name = "tsbShowDevelop";
            this.tsbShowDevelop.Size = new System.Drawing.Size(77, 22);
            this.tsbShowDevelop.Text = "开发工具(&D)";
            this.tsbShowDevelop.Click += new System.EventHandler(this.tsbShowDevelop_Click);
            // 
            // tsbAbout
            // 
            this.tsbAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbAbout.Image = ((System.Drawing.Image)(resources.GetObject("tsbAbout.Image")));
            this.tsbAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAbout.Name = "tsbAbout";
            this.tsbAbout.Size = new System.Drawing.Size(36, 22);
            this.tsbAbout.Text = "关于";
            this.tsbAbout.Click += new System.EventHandler(this.tsbAbout_Click);
            // 
            // tsbExit
            // 
            this.tsbExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbExit.Image = ((System.Drawing.Image)(resources.GetObject("tsbExit.Image")));
            this.tsbExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExit.Name = "tsbExit";
            this.tsbExit.Size = new System.Drawing.Size(52, 22);
            this.tsbExit.Text = "退出(&X)";
            this.tsbExit.Click += new System.EventHandler(this.tsbExit_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.webBrowser1);
            this.splitContainer1.Panel1.Controls.Add(this.pnWBTool);
            this.splitContainer1.Panel1.Controls.Add(this.tsWBTool);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tbcIceAutomation);
            this.splitContainer1.Size = new System.Drawing.Size(686, 466);
            this.splitContainer1.SplitterDistance = 315;
            this.splitContainer1.TabIndex = 3;
            // 
            // webBrowser1
            // 
            this.webBrowser1.ContextMenuStrip = this.ctmsTaskOperation;
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.IsWebBrowserContextMenuEnabled = false;
            this.webBrowser1.Location = new System.Drawing.Point(0, 60);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(686, 255);
            this.webBrowser1.TabIndex = 4;
            // 
            // ctmsTaskOperation
            // 
            this.ctmsTaskOperation.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiTaskGO,
            this.tsmiTaskFill,
            this.tsmiFillById,
            this.tsmiFillByName,
            this.tsmiTaskClick,
            this.tsmiClickById,
            this.tsmiClickByName,
            this.tsmiClickLink,
            this.tsmiTaskSleep,
            this.tsmiSelectDropDown,
            this.tsmiSelectRadio,
            this.tsmiExecuteJs,
            this.tsmiGetImg,
            this.tsmiGetImage,
            this.tsmiExecScript});
            this.ctmsTaskOperation.Name = "ctmsTaskOperation";
            this.ctmsTaskOperation.Size = new System.Drawing.Size(174, 334);
            // 
            // tsmiTaskGO
            // 
            this.tsmiTaskGO.Name = "tsmiTaskGO";
            this.tsmiTaskGO.Size = new System.Drawing.Size(173, 22);
            this.tsmiTaskGO.Text = "Go";
            this.tsmiTaskGO.Click += new System.EventHandler(this.tsmiTaskGO_Click);
            // 
            // tsmiTaskFill
            // 
            this.tsmiTaskFill.Name = "tsmiTaskFill";
            this.tsmiTaskFill.Size = new System.Drawing.Size(173, 22);
            this.tsmiTaskFill.Text = "Fill";
            this.tsmiTaskFill.Click += new System.EventHandler(this.tsmiTaskFill_Click);
            // 
            // tsmiFillById
            // 
            this.tsmiFillById.Name = "tsmiFillById";
            this.tsmiFillById.Size = new System.Drawing.Size(173, 22);
            this.tsmiFillById.Text = "FillById";
            this.tsmiFillById.Click += new System.EventHandler(this.tsmiFillById_Click);
            // 
            // tsmiFillByName
            // 
            this.tsmiFillByName.Name = "tsmiFillByName";
            this.tsmiFillByName.Size = new System.Drawing.Size(173, 22);
            this.tsmiFillByName.Text = "FillByName";
            this.tsmiFillByName.Click += new System.EventHandler(this.tsmiFillByName_Click);
            // 
            // tsmiTaskClick
            // 
            this.tsmiTaskClick.Name = "tsmiTaskClick";
            this.tsmiTaskClick.Size = new System.Drawing.Size(173, 22);
            this.tsmiTaskClick.Text = "Click";
            this.tsmiTaskClick.Click += new System.EventHandler(this.tsmiTaskClick_Click);
            // 
            // tsmiClickById
            // 
            this.tsmiClickById.Name = "tsmiClickById";
            this.tsmiClickById.Size = new System.Drawing.Size(173, 22);
            this.tsmiClickById.Text = "ClickById";
            this.tsmiClickById.Click += new System.EventHandler(this.tsmiClickById_Click);
            // 
            // tsmiClickByName
            // 
            this.tsmiClickByName.Name = "tsmiClickByName";
            this.tsmiClickByName.Size = new System.Drawing.Size(173, 22);
            this.tsmiClickByName.Text = "ClickByName";
            this.tsmiClickByName.Click += new System.EventHandler(this.tsmiClickByName_Click);
            // 
            // tsmiClickLink
            // 
            this.tsmiClickLink.Name = "tsmiClickLink";
            this.tsmiClickLink.Size = new System.Drawing.Size(173, 22);
            this.tsmiClickLink.Text = "ClickLink";
            this.tsmiClickLink.Click += new System.EventHandler(this.tsmiClickLink_Click);
            // 
            // tsmiTaskSleep
            // 
            this.tsmiTaskSleep.Name = "tsmiTaskSleep";
            this.tsmiTaskSleep.Size = new System.Drawing.Size(173, 22);
            this.tsmiTaskSleep.Text = "Sleep";
            this.tsmiTaskSleep.Click += new System.EventHandler(this.tsmiTaskSleep_Click);
            // 
            // tsmiSelectDropDown
            // 
            this.tsmiSelectDropDown.Name = "tsmiSelectDropDown";
            this.tsmiSelectDropDown.Size = new System.Drawing.Size(173, 22);
            this.tsmiSelectDropDown.Text = "SelectDropDown";
            this.tsmiSelectDropDown.Click += new System.EventHandler(this.tsmiSelectDropDown_Click);
            // 
            // tsmiSelectRadio
            // 
            this.tsmiSelectRadio.Name = "tsmiSelectRadio";
            this.tsmiSelectRadio.Size = new System.Drawing.Size(173, 22);
            this.tsmiSelectRadio.Text = "SelectRadio";
            this.tsmiSelectRadio.Click += new System.EventHandler(this.tsmiSelectRadio_Click);
            // 
            // tsmiExecuteJs
            // 
            this.tsmiExecuteJs.Name = "tsmiExecuteJs";
            this.tsmiExecuteJs.Size = new System.Drawing.Size(173, 22);
            this.tsmiExecuteJs.Text = "ExecuteJs";
            this.tsmiExecuteJs.Click += new System.EventHandler(this.tsmiExecuteJs_Click);
            // 
            // tsmiGetImg
            // 
            this.tsmiGetImg.Name = "tsmiGetImg";
            this.tsmiGetImg.Size = new System.Drawing.Size(173, 22);
            this.tsmiGetImg.Text = "GetImg";
            this.tsmiGetImg.Click += new System.EventHandler(this.tsmiGetImg_Click);
            // 
            // tsmiGetImage
            // 
            this.tsmiGetImage.Name = "tsmiGetImage";
            this.tsmiGetImage.Size = new System.Drawing.Size(173, 22);
            this.tsmiGetImage.Text = "GetImage";
            this.tsmiGetImage.Click += new System.EventHandler(this.tsmiGetImage_Click);
            // 
            // tsmiExecScript
            // 
            this.tsmiExecScript.Name = "tsmiExecScript";
            this.tsmiExecScript.Size = new System.Drawing.Size(173, 22);
            this.tsmiExecScript.Text = "ExecScript";
            this.tsmiExecScript.Click += new System.EventHandler(this.tsmiExecScript_Click);
            // 
            // pnWBTool
            // 
            this.pnWBTool.Controls.Add(this.btnGoToPage);
            this.pnWBTool.Controls.Add(this.cbbUrl);
            this.pnWBTool.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnWBTool.Location = new System.Drawing.Point(0, 25);
            this.pnWBTool.Name = "pnWBTool";
            this.pnWBTool.Size = new System.Drawing.Size(686, 35);
            this.pnWBTool.TabIndex = 7;
            // 
            // btnGoToPage
            // 
            this.btnGoToPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGoToPage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGoToPage.Location = new System.Drawing.Point(610, 9);
            this.btnGoToPage.Name = "btnGoToPage";
            this.btnGoToPage.Size = new System.Drawing.Size(72, 20);
            this.btnGoToPage.TabIndex = 1;
            this.btnGoToPage.Text = "Go";
            this.btnGoToPage.UseVisualStyleBackColor = true;
            this.btnGoToPage.Click += new System.EventHandler(this.btnGoToPage_Click);
            // 
            // cbbUrl
            // 
            this.cbbUrl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbUrl.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbbUrl.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbbUrl.FormattingEnabled = true;
            this.cbbUrl.Location = new System.Drawing.Point(4, 9);
            this.cbbUrl.Name = "cbbUrl";
            this.cbbUrl.Size = new System.Drawing.Size(600, 20);
            this.cbbUrl.TabIndex = 0;
            this.cbbUrl.Text = "http://www.baidu.com";
            this.cbbUrl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbbUrl_KeyDown);
            this.cbbUrl.Click += new System.EventHandler(this.cbbUrl_Click);
            // 
            // tsWBTool
            // 
            this.tsWBTool.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsWbGoBack,
            this.tsWbGoForward,
            this.tsWbRefresh,
            this.tsWbStop,
            this.tsWbHomePage,
            this.tsWbShowSource,
            this.tsWbSaveDialog});
            this.tsWBTool.Location = new System.Drawing.Point(0, 0);
            this.tsWBTool.Name = "tsWBTool";
            this.tsWBTool.Size = new System.Drawing.Size(686, 25);
            this.tsWBTool.TabIndex = 6;
            // 
            // tsWbGoBack
            // 
            this.tsWbGoBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsWbGoBack.Image = ((System.Drawing.Image)(resources.GetObject("tsWbGoBack.Image")));
            this.tsWbGoBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsWbGoBack.Name = "tsWbGoBack";
            this.tsWbGoBack.Size = new System.Drawing.Size(36, 22);
            this.tsWbGoBack.Text = "后退";
            this.tsWbGoBack.Click += new System.EventHandler(this.tsWbGoBack_Click);
            // 
            // tsWbGoForward
            // 
            this.tsWbGoForward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsWbGoForward.Image = ((System.Drawing.Image)(resources.GetObject("tsWbGoForward.Image")));
            this.tsWbGoForward.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsWbGoForward.Name = "tsWbGoForward";
            this.tsWbGoForward.Size = new System.Drawing.Size(36, 22);
            this.tsWbGoForward.Text = "前进";
            this.tsWbGoForward.Click += new System.EventHandler(this.tsWbGoForward_Click);
            // 
            // tsWbRefresh
            // 
            this.tsWbRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsWbRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tsWbRefresh.Image")));
            this.tsWbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsWbRefresh.Name = "tsWbRefresh";
            this.tsWbRefresh.Size = new System.Drawing.Size(36, 22);
            this.tsWbRefresh.Text = "刷新";
            this.tsWbRefresh.Click += new System.EventHandler(this.tsWbRefresh_Click);
            // 
            // tsWbStop
            // 
            this.tsWbStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsWbStop.Image = ((System.Drawing.Image)(resources.GetObject("tsWbStop.Image")));
            this.tsWbStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsWbStop.Name = "tsWbStop";
            this.tsWbStop.Size = new System.Drawing.Size(36, 22);
            this.tsWbStop.Text = "停止";
            this.tsWbStop.Click += new System.EventHandler(this.tsWbStop_Click);
            // 
            // tsWbHomePage
            // 
            this.tsWbHomePage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsWbHomePage.Image = ((System.Drawing.Image)(resources.GetObject("tsWbHomePage.Image")));
            this.tsWbHomePage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsWbHomePage.Name = "tsWbHomePage";
            this.tsWbHomePage.Size = new System.Drawing.Size(36, 22);
            this.tsWbHomePage.Text = "主页";
            this.tsWbHomePage.Click += new System.EventHandler(this.tsWbHomePage_Click);
            // 
            // tsWbShowSource
            // 
            this.tsWbShowSource.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsWbShowSource.Image = ((System.Drawing.Image)(resources.GetObject("tsWbShowSource.Image")));
            this.tsWbShowSource.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsWbShowSource.Name = "tsWbShowSource";
            this.tsWbShowSource.Size = new System.Drawing.Size(60, 22);
            this.tsWbShowSource.Text = "查看源码";
            this.tsWbShowSource.Click += new System.EventHandler(this.tsWbShowSource_Click);
            // 
            // tsWbSaveDialog
            // 
            this.tsWbSaveDialog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsWbSaveDialog.Image = ((System.Drawing.Image)(resources.GetObject("tsWbSaveDialog.Image")));
            this.tsWbSaveDialog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsWbSaveDialog.Name = "tsWbSaveDialog";
            this.tsWbSaveDialog.Size = new System.Drawing.Size(60, 22);
            this.tsWbSaveDialog.Text = "保存网页";
            this.tsWbSaveDialog.Click += new System.EventHandler(this.tsWbSaveDialog_Click);
            // 
            // tbcIceAutomation
            // 
            this.tbcIceAutomation.Controls.Add(this.tpAutoTask);
            this.tbcIceAutomation.Controls.Add(this.tpElements);
            this.tbcIceAutomation.Controls.Add(this.tpHtmlSource);
            this.tbcIceAutomation.Controls.Add(this.tpConsole);
            this.tbcIceAutomation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcIceAutomation.Location = new System.Drawing.Point(0, 0);
            this.tbcIceAutomation.Name = "tbcIceAutomation";
            this.tbcIceAutomation.SelectedIndex = 0;
            this.tbcIceAutomation.Size = new System.Drawing.Size(686, 147);
            this.tbcIceAutomation.TabIndex = 2;
            // 
            // tpAutoTask
            // 
            this.tpAutoTask.Controls.Add(this.rtxtTaskScript);
            this.tpAutoTask.Controls.Add(this.tsTaskTool);
            this.tpAutoTask.Location = new System.Drawing.Point(4, 22);
            this.tpAutoTask.Name = "tpAutoTask";
            this.tpAutoTask.Size = new System.Drawing.Size(678, 121);
            this.tpAutoTask.TabIndex = 2;
            this.tpAutoTask.Text = "作业";
            this.tpAutoTask.UseVisualStyleBackColor = true;
            // 
            // rtxtTaskScript
            // 
            this.rtxtTaskScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtTaskScript.Location = new System.Drawing.Point(0, 25);
            this.rtxtTaskScript.Name = "rtxtTaskScript";
            this.rtxtTaskScript.Size = new System.Drawing.Size(678, 96);
            this.rtxtTaskScript.TabIndex = 1;
            this.rtxtTaskScript.Text = "Go(http://www.baidu.com/);\nFill(HTML/BODY/DIV/DIV/DIV[2]/DIV/FORM/SPAN/INPUT,nba)" +
                ";\nClick(HTML/BODY/DIV/DIV/DIV[2]/DIV/FORM/SPAN[2]/INPUT);";
            // 
            // tsTaskTool
            // 
            this.tsTaskTool.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbTaskScriptExcute,
            this.tsbTaskScriptStop,
            this.tsbTaskScriptNew,
            this.tsbTaskScriptOpen,
            this.tsbTaskScriptSave,
            this.tsbTaskScriptClear,
            this.tsbTaskScriptGetPic});
            this.tsTaskTool.Location = new System.Drawing.Point(0, 0);
            this.tsTaskTool.Name = "tsTaskTool";
            this.tsTaskTool.Size = new System.Drawing.Size(678, 25);
            this.tsTaskTool.TabIndex = 2;
            this.tsTaskTool.Text = "作业工具栏";
            // 
            // tsbTaskScriptExcute
            // 
            this.tsbTaskScriptExcute.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbTaskScriptExcute.Image = ((System.Drawing.Image)(resources.GetObject("tsbTaskScriptExcute.Image")));
            this.tsbTaskScriptExcute.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbTaskScriptExcute.Name = "tsbTaskScriptExcute";
            this.tsbTaskScriptExcute.Size = new System.Drawing.Size(36, 22);
            this.tsbTaskScriptExcute.Text = "执行";
            this.tsbTaskScriptExcute.Click += new System.EventHandler(this.tsbTaskScriptExcute_Click);
            // 
            // tsbTaskScriptStop
            // 
            this.tsbTaskScriptStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbTaskScriptStop.Image = ((System.Drawing.Image)(resources.GetObject("tsbTaskScriptStop.Image")));
            this.tsbTaskScriptStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbTaskScriptStop.Name = "tsbTaskScriptStop";
            this.tsbTaskScriptStop.Size = new System.Drawing.Size(36, 22);
            this.tsbTaskScriptStop.Text = "停止";
            this.tsbTaskScriptStop.Click += new System.EventHandler(this.tsbTaskScriptStop_Click);
            // 
            // tsbTaskScriptNew
            // 
            this.tsbTaskScriptNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbTaskScriptNew.Image = ((System.Drawing.Image)(resources.GetObject("tsbTaskScriptNew.Image")));
            this.tsbTaskScriptNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbTaskScriptNew.Name = "tsbTaskScriptNew";
            this.tsbTaskScriptNew.Size = new System.Drawing.Size(36, 22);
            this.tsbTaskScriptNew.Text = "新建";
            this.tsbTaskScriptNew.Click += new System.EventHandler(this.tsbTaskScriptNew_Click);
            // 
            // tsbTaskScriptOpen
            // 
            this.tsbTaskScriptOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbTaskScriptOpen.Image = ((System.Drawing.Image)(resources.GetObject("tsbTaskScriptOpen.Image")));
            this.tsbTaskScriptOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbTaskScriptOpen.Name = "tsbTaskScriptOpen";
            this.tsbTaskScriptOpen.Size = new System.Drawing.Size(36, 22);
            this.tsbTaskScriptOpen.Text = "加载";
            this.tsbTaskScriptOpen.Click += new System.EventHandler(this.tsbTaskScriptOpen_Click);
            // 
            // tsbTaskScriptSave
            // 
            this.tsbTaskScriptSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbTaskScriptSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbTaskScriptSave.Image")));
            this.tsbTaskScriptSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbTaskScriptSave.Name = "tsbTaskScriptSave";
            this.tsbTaskScriptSave.Size = new System.Drawing.Size(36, 22);
            this.tsbTaskScriptSave.Text = "保存";
            this.tsbTaskScriptSave.Click += new System.EventHandler(this.tsbTaskScriptSave_Click);
            // 
            // tsbTaskScriptClear
            // 
            this.tsbTaskScriptClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbTaskScriptClear.Image = ((System.Drawing.Image)(resources.GetObject("tsbTaskScriptClear.Image")));
            this.tsbTaskScriptClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbTaskScriptClear.Name = "tsbTaskScriptClear";
            this.tsbTaskScriptClear.Size = new System.Drawing.Size(36, 22);
            this.tsbTaskScriptClear.Text = "清空";
            this.tsbTaskScriptClear.Click += new System.EventHandler(this.tsbTaskScriptClear_Click);
            // 
            // tsbTaskScriptGetPic
            // 
            this.tsbTaskScriptGetPic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbTaskScriptGetPic.Image = ((System.Drawing.Image)(resources.GetObject("tsbTaskScriptGetPic.Image")));
            this.tsbTaskScriptGetPic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbTaskScriptGetPic.Name = "tsbTaskScriptGetPic";
            this.tsbTaskScriptGetPic.Size = new System.Drawing.Size(48, 22);
            this.tsbTaskScriptGetPic.Text = "GetPic";
            this.tsbTaskScriptGetPic.Click += new System.EventHandler(this.tsbTaskScriptGetPic_Click);
            // 
            // tpElements
            // 
            this.tpElements.Controls.Add(this.label2);
            this.tpElements.Controls.Add(this.txtElementCode);
            this.tpElements.Controls.Add(this.label1);
            this.tpElements.Controls.Add(this.txtElementXPath);
            this.tpElements.Location = new System.Drawing.Point(4, 22);
            this.tpElements.Name = "tpElements";
            this.tpElements.Padding = new System.Windows.Forms.Padding(3);
            this.tpElements.Size = new System.Drawing.Size(678, 121);
            this.tpElements.TabIndex = 1;
            this.tpElements.Text = "元素";
            this.tpElements.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Code";
            // 
            // txtElementCode
            // 
            this.txtElementCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtElementCode.Location = new System.Drawing.Point(62, 44);
            this.txtElementCode.Multiline = true;
            this.txtElementCode.Name = "txtElementCode";
            this.txtElementCode.ReadOnly = true;
            this.txtElementCode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtElementCode.Size = new System.Drawing.Size(591, 56);
            this.txtElementCode.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "XPath";
            // 
            // txtElementXPath
            // 
            this.txtElementXPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtElementXPath.Location = new System.Drawing.Point(62, 7);
            this.txtElementXPath.Name = "txtElementXPath";
            this.txtElementXPath.ReadOnly = true;
            this.txtElementXPath.Size = new System.Drawing.Size(591, 21);
            this.txtElementXPath.TabIndex = 0;
            // 
            // tpHtmlSource
            // 
            this.tpHtmlSource.Controls.Add(this.rtxtSourceCode);
            this.tpHtmlSource.Location = new System.Drawing.Point(4, 22);
            this.tpHtmlSource.Name = "tpHtmlSource";
            this.tpHtmlSource.Padding = new System.Windows.Forms.Padding(3);
            this.tpHtmlSource.Size = new System.Drawing.Size(678, 121);
            this.tpHtmlSource.TabIndex = 0;
            this.tpHtmlSource.Text = "源代码";
            this.tpHtmlSource.UseVisualStyleBackColor = true;
            // 
            // rtxtSourceCode
            // 
            this.rtxtSourceCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtSourceCode.Location = new System.Drawing.Point(3, 3);
            this.rtxtSourceCode.Name = "rtxtSourceCode";
            this.rtxtSourceCode.Size = new System.Drawing.Size(672, 115);
            this.rtxtSourceCode.TabIndex = 0;
            this.rtxtSourceCode.Text = "";
            // 
            // tpConsole
            // 
            this.tpConsole.Controls.Add(this.rtxtConsoleText);
            this.tpConsole.Location = new System.Drawing.Point(4, 22);
            this.tpConsole.Name = "tpConsole";
            this.tpConsole.Size = new System.Drawing.Size(678, 121);
            this.tpConsole.TabIndex = 3;
            this.tpConsole.Text = "控制台";
            this.tpConsole.UseVisualStyleBackColor = true;
            // 
            // rtxtConsoleText
            // 
            this.rtxtConsoleText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtConsoleText.Location = new System.Drawing.Point(0, 0);
            this.rtxtConsoleText.Name = "rtxtConsoleText";
            this.rtxtConsoleText.Size = new System.Drawing.Size(678, 121);
            this.rtxtConsoleText.TabIndex = 1;
            this.rtxtConsoleText.Text = "";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbpStatus,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3});
            this.statusStrip1.Location = new System.Drawing.Point(0, 465);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(686, 26);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsbpStatus
            // 
            this.tsbpStatus.Name = "tsbpStatus";
            this.tsbpStatus.Size = new System.Drawing.Size(200, 20);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel2.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(234, 21);
            this.toolStripStatusLabel2.Spring = true;
            this.toolStripStatusLabel2.Text = "  版本 1.2.1  ";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel3.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.toolStripStatusLabel3.ForeColor = System.Drawing.Color.Blue;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(234, 21);
            this.toolStripStatusLabel3.Spring = true;
            this.toolStripStatusLabel3.Text = "ice.Kwok";
            this.toolStripStatusLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FrmIceWebAutomation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 491);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.KeyPreview = true;
            this.Name = "FrmIceWebAutomation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "自动化脚本工具";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmIceWebAutomation_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmIceWebAutomation_KeyDown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ctmsTaskOperation.ResumeLayout(false);
            this.pnWBTool.ResumeLayout(false);
            this.tsWBTool.ResumeLayout(false);
            this.tsWBTool.PerformLayout();
            this.tbcIceAutomation.ResumeLayout(false);
            this.tpAutoTask.ResumeLayout(false);
            this.tpAutoTask.PerformLayout();
            this.tsTaskTool.ResumeLayout(false);
            this.tsTaskTool.PerformLayout();
            this.tpElements.ResumeLayout(false);
            this.tpElements.PerformLayout();
            this.tpHtmlSource.ResumeLayout(false);
            this.tpConsole.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbSelectElement;
        private System.Windows.Forms.ToolStripButton tsbShowDevelop;
        private System.Windows.Forms.ToolStripButton tsbExit;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tbcIceAutomation;
        private System.Windows.Forms.TabPage tpHtmlSource;
        private System.Windows.Forms.RichTextBox rtxtSourceCode;
        private System.Windows.Forms.TabPage tpElements;
        private System.Windows.Forms.TabPage tpAutoTask;
        private System.Windows.Forms.TabPage tpConsole;
        private System.Windows.Forms.RichTextBox rtxtConsoleText;
        private System.Windows.Forms.TextBox txtElementXPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtElementCode;
        private System.Windows.Forms.ContextMenuStrip ctmsTaskOperation;
        private System.Windows.Forms.ToolStripMenuItem tsmiTaskGO;
        private System.Windows.Forms.ToolStripMenuItem tsmiTaskFill;
        private System.Windows.Forms.ToolStripMenuItem tsmiTaskClick;
        private System.Windows.Forms.ToolStripMenuItem tsmiTaskSleep;
        private System.Windows.Forms.ToolStripMenuItem tsmiSelectDropDown;
        private System.Windows.Forms.RichTextBox rtxtTaskScript;
        private System.Windows.Forms.ToolStrip tsTaskTool;
        private System.Windows.Forms.ToolStripButton tsbTaskScriptExcute;
        private System.Windows.Forms.ToolStripButton tsbTaskScriptSave;
        private System.Windows.Forms.ToolStripButton tsbTaskScriptClear;
        private System.Windows.Forms.ToolStripButton tsbTaskScriptStop;
        private System.Windows.Forms.ToolStripButton tsbTaskScriptNew;
        private System.Windows.Forms.ToolStripButton tsbTaskScriptOpen;
        private System.Windows.Forms.ToolStripMenuItem tsmiClickLink;
        private System.Windows.Forms.ToolStripMenuItem tsmiFillById;
        private System.Windows.Forms.ToolStripMenuItem tsmiFillByName;
        private System.Windows.Forms.ToolStripMenuItem tsmiClickById;
        private System.Windows.Forms.ToolStripMenuItem tsmiClickByName;
        private System.Windows.Forms.ToolStripMenuItem tsmiSelectRadio;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.ToolStrip tsWBTool;
        private System.Windows.Forms.Panel pnWBTool;
        private System.Windows.Forms.ToolStripButton tsWbGoBack;
        private System.Windows.Forms.ToolStripButton tsWbGoForward;
        private System.Windows.Forms.ToolStripButton tsWbRefresh;
        private System.Windows.Forms.ToolStripButton tsWbStop;
        private System.Windows.Forms.ToolStripButton tsWbHomePage;
        private System.Windows.Forms.Button btnGoToPage;
        private System.Windows.Forms.ComboBox cbbUrl;
        private System.Windows.Forms.ToolStripButton tsWbShowSource;
        private System.Windows.Forms.ToolStripButton tsWbSaveDialog;
        private System.Windows.Forms.ToolStripButton tsbAbout;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar tsbpStatus;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripButton tsbTaskScriptGetPic;
        private System.Windows.Forms.ToolStripMenuItem tsmiExecuteJs;
        private System.Windows.Forms.ToolStripMenuItem tsmiGetImg;
        private System.Windows.Forms.ToolStripMenuItem tsmiExecScript;
        private System.Windows.Forms.ToolStripMenuItem tsmiGetImage;
    }
}

