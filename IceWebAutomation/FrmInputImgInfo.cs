using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IceWebAutomation
{
    public partial class FrmInputImgInfo : Form
    {
        public FrmInputImgInfo()
        {
            InitializeComponent();
        }

        public string ReturnIdNameValue = string.Empty;
        public string ReturnSrcValue = string.Empty;
        public string ReturnAltValue = string.Empty;
        public string InitValue = string.Empty;

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            ReturnIdNameValue = txtIdName.Text;
            ReturnSrcValue = txtSrc.Text;
            ReturnAltValue = txtAlt.Text;
            InitValue = "";
            DialogResult = DialogResult.OK;
        }

        private void FrmInputImgInfo_Load(object sender, EventArgs e)
        {
            txtSource.Text = InitValue;
        }

        private void FrmInputImgInfo_Activated(object sender, EventArgs e)
        {
            txtIdName.Focus();
        }
    }
}