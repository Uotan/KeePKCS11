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
using KeePass;
using KeePassLib.Cryptography.PasswordGenerator;
using KeePass.Util;
using KeePass.Resources;
using KeePass.Forms;
using Net.Pkcs11Interop.Common;
using Net.Pkcs11Interop.HighLevelAPI;

namespace KeePKCS11KeyProvider.Forms
{
    public partial class CkpCreationForm : Form
    {
        private List<pkcs11.keyfile> keyfiles;
        public byte[] selected_key;
        private IPluginHost m_host = null;
        private string database;
        private DynamicMenu m_dynGenProfiles;

        public CkpCreationForm()
        {
            InitializeComponent();
            
        }

        public CkpCreationForm(IPluginHost m_host)
        {
            this.m_host = m_host;
            InitializeComponent();
        }

        public CkpCreationForm(IPluginHost m_host, string p)
        {
            this.m_host = m_host;
            this.database = p;
            InitializeComponent();
        }

        private void OnFormLoad(object sender, EventArgs e)
        {
            GlobalWindowManager.AddWindow(this);

            string strTitle = "Configure PKCS#11";
            string strDesc = "Protect the database using a smartcard or token.";

            this.Text = strTitle;
            BannerFactory.CreateBannerEx(this, banner,
                Resource.chip, strTitle, strDesc);

            m_dynGenProfiles = new DynamicMenu(generateUsingProfileToolStripMenuItem.DropDownItems);
            m_dynGenProfiles.MenuClick += this.OnProfilesDynamicMenuClick;

            if (KeePKCS11KeyProvider.pkcs11_conf_lib != null)
            {
                textBox1.Text = KeePKCS11KeyProvider.pkcs11_conf_lib;
                try
                {
                //    keyfiles = pkcs11.read_allkeyfiles(CryptokiKeyProvider.pkcs11_conf_lib, null, true);
                //    addKeyfiles2listview();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void OnProfilesDynamicMenuClick(object sender, DynamicMenuEventArgs e)
        {
            PwProfile pwp = null;

            foreach (PwProfile pwgo in PwGeneratorUtil.GetAllProfiles(false))
            {
                if (pwgo.Name == e.ItemName)
                {
                    pwp = pwgo;
                    break;
                }
            }

            if (pwp != null)
            {
                ProtectedString psNew;
                PwGenerator.Generate(out psNew, pwp, null, Program.PwGeneratorPool);
                byte[] pbNew = psNew.ReadUtf8();

                CkpPromtLabelForm plf = new CkpPromtLabelForm();
                if (plf.ShowDialog() == DialogResult.OK)
                {
                    pkcs11.createKeyfile(plf.label, pbNew);

                    keyfiles = pkcs11.read_allkeyfiles(this.textBox1.Text);
                    addKeyfiles2listview();
                }

                MemUtil.ZeroByteArray(pbNew);
            }
        }

        private void OnFormClose(Object sender, FormClosingEventArgs e)
        {
            deinit_pkcs11();
            GlobalWindowManager.RemoveWindow(this);
        }

        private void deinit_pkcs11()
        {
            try
            {
                pkcs11.Logout();
                pkcs11.CloseSession();

            } catch (Exception) 
            {}
        }


        private void addKeyfiles2listview()
        {
            listView1.Items.Clear();

            listView1.Enabled = true;
            foreach (pkcs11.keyfile keyfile in keyfiles)
            {
                this.listView1.Items.Add(new ListViewItem(new[] { Convert.ToString(keyfile.slotid), keyfile.token_name, keyfile.label }));
            }
            
        }



        private void selectLibrary_Click(object sender, EventArgs e)
        {
 
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "dll files (*.dll)|*.dll|All files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
                this.textBox1.Text = ofd.FileName;
            Pkcs11InteropFactories factories = new Pkcs11InteropFactories();
            IPkcs11Library pkcs11Library = factories.Pkcs11LibraryFactory.LoadPkcs11Library(factories, textBox1.Text, AppType.MultiThreaded);
            ILibraryInfo libraryInfo = pkcs11Library.GetInfo();
            MessageBox.Show(libraryInfo.LibraryVersion);

        }

        private void listView_SelectedIndexChange(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count == 1)
            {
                this.buttonExportKey.Enabled = true;
                this.buttonDeleteKey.Enabled = true;
            }
            else
            {
                this.buttonExportKey.Enabled = false;
                this.buttonDeleteKey.Enabled = false;
            }
        }

        private void buttonDeleteKey_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("No key selected");              
                return;
            }
            DialogResult dialogResult = MessageBox.Show("Do you really want delete the key \""+
                this.listView1.SelectedItems[0].SubItems[2].Text + "\"?", "Delete Key", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                pkcs11.keyfile key = keyfiles[this.listView1.SelectedItems[0].Index];

                try
                {
                    pkcs11.DestroyObject(key.handle);
                    keyfiles = pkcs11.read_allkeyfiles(this.textBox1.Text);
                    addKeyfiles2listview();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("No key selected");
                DialogResult = DialogResult.None;
                return;
            }

            string selected_label = this.listView1.SelectedItems[0].SubItems[2].Text;
            pkcs11.keyfile key = keyfiles[this.listView1.SelectedItems[0].Index];
           
//            try {
//               selected_key = pkcs11.GetAttributeValue(key.handle, pkcs11.CKA_VALUE);                          }
//            catch (Exception ex)
//            {
//                MessageBox.Show(ex.Message);
//            }
//            System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
            
            //saveSettings(this.textBox1.Text, this.listView1.SelectedItems[0].SubItems[0].Text, selected_label);
            KeePKCS11KeyProvider.saveSettings(this.textBox1.Text, this.listView1.SelectedItems[0].SubItems[0].Text, selected_label);

            //deinit_pkcs11();
        }

        private void buttonExportKey_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("No key selected");
                return;
            }

            pkcs11.keyfile key = keyfiles[this.listView1.SelectedItems[0].Index];

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "key files (*.key)|*.key|All files (*.*)|*.*";
            sfd.FilterIndex = 2;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FileStream fs = File.Create(sfd.FileName);
                    BinaryWriter bw = new BinaryWriter(fs);
                    byte[] key_data = pkcs11.GetAttributeValue(key.handle, pkcs11.CKA_VALUE);
                    bw.Write(key_data);
                    bw.Close();
                    fs.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Export Key failed.");
                }

                MessageBox.Show("Export Key successful.");
            }
        }

        private void buttonImportKey_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "All files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("try import file: " + ofd.FileName);
                byte[] file_data = File.ReadAllBytes(ofd.FileName);

                pkcs11.createKeyfile(ofd.SafeFileName, file_data);

                keyfiles = pkcs11.read_allkeyfiles(this.textBox1.Text);
                addKeyfiles2listview();
            }

            
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            //deinit_pkcs11();
        }

        private void buttonReadKey_Click(object sender, EventArgs e)
        {

            if (textBox1.Text.Trim() == "")
            {
                MessageBox.Show("Please select a PKCS11 Library.");
            }
            else
            {
                try
                {
                    this.keyfiles = pkcs11.read_allkeyfiles(this.textBox1.Text, null, true);
                    addKeyfiles2listview();
                    this.buttonImportKey.Enabled = true;
                    this.buttonCreateKey.Enabled = true;
                }
                catch (Exception ex)
                {
                    this.buttonImportKey.Enabled = false;
                    this.buttonCreateKey.Enabled = false;
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProtectedString test;

            PwProfile pwp = new PwProfile(); //Program.Config.PasswordGenerator.AutoGeneratedPasswordsProfile
            pwp.Length = 10;

            PwGenerator.Generate(out test, pwp, null, Program.PwGeneratorPool);
            MessageBox.Show("pwgen: " + test.ReadString());
        }

        private void buttonCreateKey_Click(object sender, EventArgs e)
        {  
            m_dynGenProfiles.Clear();

            foreach (PwProfile pwgo in PwGeneratorUtil.GetAllProfiles(true))
            {
                    m_dynGenProfiles.AddItem(pwgo.Name, null);
            }

            contextMenuStrip1.Show(buttonCreateKey, new Point(0, buttonCreateKey.Height));
        }

        private void test2ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void test1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PwGeneratorForm pgf = new PwGeneratorForm();

            if (pgf.ShowDialog() == DialogResult.OK)
            {
                byte[] pbEntropy = EntropyForm.CollectEntropyIfEnabled(pgf.SelectedProfile);
                ProtectedString psNew;
                PwGenerator.Generate(out psNew, pgf.SelectedProfile, pbEntropy,
                    Program.PwGeneratorPool);

                byte[] pbNew = psNew.ReadUtf8();

                CkpPromtLabelForm plf = new CkpPromtLabelForm();
                if (plf.ShowDialog() == DialogResult.OK)
                {
                    pkcs11.createKeyfile(plf.label, pbNew);

                    keyfiles = pkcs11.read_allkeyfiles(this.textBox1.Text);
                    addKeyfiles2listview();
                }

            }
            UIUtil.DestroyForm(pgf);


        }
    }
}
