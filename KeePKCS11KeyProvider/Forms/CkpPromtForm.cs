/*
  CryptokiKeyPrivder - A PKCS#11 Plugin for Keepass
  Copyright (C) 2013 Daniel Pieper <daniel.pieper@implogy.de>

  This program is free software: you can redistribute it and/or modify
  it under the terms of the GNU General Public License as published by
  the Free Software Foundation, either version 3 of the License, or
  (at your option) any later version.

  This program is distributed in the hope that it will be useful,
  but WITHOUT ANY WARRANTY; without even the implied warranty of
  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
  GNU General Public License for more details.

  You should have received a copy of the GNU General Public License
  along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

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
using System.IO;
using KeePassLib.Security;

namespace KeePKCS11KeyProvider.Forms
{
    public partial class CkpPromtForm : Form
    {
        public ProtectedString pin;
        public bool pin_input;
        public string key_label = null;
        private KeyProviderQueryContext ctx;
        public bool key_changed;


        public CkpPromtForm()
        {
            InitializeComponent();
        }

        public  CkpPromtForm(string label, bool pin_input = false)
        {
            if (label != null)
                this.key_label = label;
            this.pin_input = pin_input;
            InitializeComponent();
        }

        public CkpPromtForm(KeyProviderQueryContext ctx)
        {

            this.ctx = ctx;
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


            if (pin_input)
            {
                this.textBox1.Visible = true;
                this.buttonOk.Visible = true;
                this.label1.Visible = true;
                this.groupBox1.Visible = false;
                this.label3.Visible = false;
                this.buttonChange.Visible = false;
            }
            else
            {

                if (key_label != null)
                {
                    this.label3.Text = key_label;
                }
                else
                {
                    this.label3.Text = "No settings found.";
                    this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
                    this.textBox1.Visible = false;
                    this.buttonOk.Visible = false;
                    this.label1.Visible = false;
                }

                this.groupBox1.Visible = true;
                this.label3.Visible = true;
                this.buttonChange.Visible = true;
            }
        }

        private void OnFormClose(Object sender, FormClosingEventArgs e)
        {
            GlobalWindowManager.RemoveWindow(this);
        }


        private void buttonOk_Click(object sender, EventArgs e)
        {
            pin = new ProtectedString(true, this.textBox1.Text);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            CkpCreationForm cf = new CkpCreationForm(KeePKCS11KeyProvider.m_host, KeePKCS11KeyProvider.database_name);

            //this.keyfiles = cf.keyfiles;

            if (UIUtil.ShowDialogAndDestroy(cf) == DialogResult.OK)
            {

                KeePKCS11KeyProvider.getSettings();
                this.label3.Text = KeePKCS11KeyProvider.pkcs11_conf_label;
                this.textBox1.Visible = true;
                this.buttonOk.Visible = true;
                this.label1.Visible = true;
                this.key_changed = true;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
