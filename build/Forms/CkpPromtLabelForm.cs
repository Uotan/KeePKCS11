using KeePass.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CryptokiKeyProvider.Forms
{
    public partial class CkpPromtLabelForm : Form
    {
        public String label;

        public CkpPromtLabelForm()
        {
            InitializeComponent();
        }

        private void OnFormLoad(object sender, EventArgs e)
        {
            GlobalWindowManager.AddWindow(this);

            string strTitle = "PKCS#11";
            string strDesc = "Enter label for key.";

            this.Text = strTitle;
            BannerFactory.CreateBannerEx(this, banner,
                Resource.chip, strTitle, strDesc);
            this.textBox1.Select();
        }

        private void OnFormClose(object sender, FormClosingEventArgs e)
        {
            GlobalWindowManager.RemoveWindow(this);
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Length < 1)
                MessageBox.Show("Please enter a label.");

            this.label = this.textBox1.Text;
        }
    }
}
