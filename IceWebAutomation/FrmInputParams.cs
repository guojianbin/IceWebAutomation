using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IceWebAutomation
{
    public partial class FrmInputParams : Form
    {
        public FrmInputParams()
        {
            InitializeComponent();
        }

        public string ReturnValue = string.Empty;
        public string InitValue = string.Empty;

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            ReturnValue = txtInputValue.Text;
            InitValue = "";
            DialogResult = DialogResult.OK;
        }

        private void FrmInputParams_Activated(object sender, EventArgs e)
        {
            txtInputValue.Focus();
        }

        private void FrmInputParams_Load(object sender, EventArgs e)
        {
            txtInputValue.Text = InitValue;
        }
    }
}