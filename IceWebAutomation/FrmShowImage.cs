using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IceWebAutomation
{
    public partial class FrmShowImage : Form
    {
        public FrmShowImage()
        {
            InitializeComponent();
        }

        //public Image ImageSource = null;

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Owner.Show();
            this.Owner.Activate();
        }

        private void FrmShowImage_Load(object sender, EventArgs e)
        {
            //if (ImageSource != null)
            //{
            //   // picbSource.Image = ImageSource;
            //    cbbViewMode.SelectedIndex = 3;
            //}
            cbbViewMode.SelectedIndex = 3;
        }

        private void cbbViewMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            string mode = ((ComboBox)sender).Text;
            picbSource.SizeMode =(PictureBoxSizeMode)Enum.Parse(typeof(PictureBoxSizeMode), mode);

        }

        private void FrmShowImage_VisibleChanged(object sender, EventArgs e)
        {
            //
        }

    }
}