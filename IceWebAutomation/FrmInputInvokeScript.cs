using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IceWebAutomation
{
    public partial class FrmInputInvokeScript : Form
    {
        public string ReturnMethodValue = string.Empty;
        public string ReturnParamsValue = string.Empty;
        public string InitValue = string.Empty;
        public FrmInputInvokeScript()
        {
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            ReturnMethodValue = txtMethod.Text;
            ReturnParamsValue = txtParams.Text;
            InitValue = "";
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void FrmInputInvokeScript_Load(object sender, EventArgs e)
        {
            txtSource.Text = InitValue;
        }

        private void FrmInputInvokeScript_Activated(object sender, EventArgs e)
        {
            txtMethod.Focus();
        }




    }
}