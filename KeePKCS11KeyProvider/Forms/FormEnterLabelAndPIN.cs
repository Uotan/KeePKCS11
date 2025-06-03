using KeePass.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace KeePKCS11KeyProvider.Forms
{
    public partial class FormEnterLabelAndPIN : Form
    {

        public string enteredPIN { get; private set; }
        public string enteredObjectLabel { get; private set; }

        public FormEnterLabelAndPIN()
        {
            InitializeComponent();
        }

        private void OnFormLoad(object sender, EventArgs e)
        {
            GlobalWindowManager.AddWindow(this);
        }

        private void OnFormClose(object sender, FormClosingEventArgs e)
        {
            GlobalWindowManager.RemoveWindow(this);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //if (String.IsNullOrEmpty(tbxObjectLabel.Text))
            //{
            //    //DateTime currentTime = DateTime.UtcNow;
            //    //long unixTime = ((DateTimeOffset)currentTime).ToUnixTimeSeconds();
            //    //string unixTimeStr = unixTime.ToString();
            //    DateTime currentTime = DateTime.UtcNow;
            //    DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            //    TimeSpan timeSpan = currentTime - unixEpoch;
            //    long unixTime = (long)timeSpan.TotalSeconds;
            //    string unixTimeStr = unixTime.ToString();
            //    Debug.WriteLine(unixTimeStr);
                
            //    byte[] data = Encoding.ASCII.GetBytes(unixTimeStr);
            //    uint crc32 = Crc32.Compute(data);
            //    Debug.WriteLine(crc32);
            //    enteredObjectLabel = crc32.ToString("X8");
            //}
            //else
            //{
            //    enteredObjectLabel = tbxObjectLabel.Text;
            //}

            enteredObjectLabel = tbxObjectLabel.Text;
            enteredPIN = tbxPinCode.Text;
            DialogResult = DialogResult.OK; // Закрываем с результатом OK
            Close();
        }

        private void checkBoxDisplayPIN_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDisplayPIN.Checked)
            {
                tbxPinCode.UseSystemPasswordChar = false;
            }
            else if (!checkBoxDisplayPIN.Checked)
            {
                tbxPinCode.UseSystemPasswordChar = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void tbxPinCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOk.PerformClick(); // Нажатие кнопки "ОК"
            }
        }
    }
}
