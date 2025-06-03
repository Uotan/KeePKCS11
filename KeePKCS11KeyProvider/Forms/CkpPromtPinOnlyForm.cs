using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using cryptotest;

using KeePass.UI;

using KeePassLib.Keys;
using KeePassLib.Utility;
using KeePass.Plugins;
using KeePassLib.Security;
using System.IO;

namespace KeePKCS11KeyProvider.Forms
{
    public partial class CkpPromtPinOnlyForm : Form
    {
        public ProtectedString pin;

        public CkpPromtPinOnlyForm()
        {
            InitializeComponent();
        }


        private void OnFormLoad(object sender, EventArgs e)
        {
            GlobalWindowManager.AddWindow(this);

            string strTitle = "PKCS#11";
            string strDesc = "Enter your pin.";

            this.Text = strTitle;
            BannerFactory.CreateBannerEx(this, banner,
                Resource.chip, strTitle, strDesc);
            this.textBox1.PasswordChar = '*';
            this.textBox1.Select();
        }

        private void OnFormClose(object sender, FormClosingEventArgs e)
        {
            GlobalWindowManager.RemoveWindow(this);
        }


        private void buttonOk_Click(object sender, EventArgs e)
        {
            pin = new ProtectedString(true, this.textBox1.Text);
        }
    }
}
