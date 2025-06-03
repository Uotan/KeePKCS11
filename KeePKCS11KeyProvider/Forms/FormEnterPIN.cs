using System;
using System.Windows.Forms;
using KeePass.UI;

namespace KeePKCS11KeyProvider.Forms
{
    public partial class FormEnterPIN : Form
    {
        public String enteredPIN;
        public FormEnterPIN()
        {
            InitializeComponent();
        }

        

        private void btnOk_Click(object sender, EventArgs e)
        {
            enteredPIN = tbxPinCode.Text; // Сохраняем текст
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void OnFormLoad(object sender, EventArgs e)
        {
            GlobalWindowManager.AddWindow(this);
        }

        private void OnFormClose(object sender, FormClosingEventArgs e)
        {
            GlobalWindowManager.RemoveWindow(this);
        }

        private void FormEnterPIN_Load(object sender, EventArgs e)
        {
            //tbxPinCode.PasswordChar = '*';
        }

        private void checkBoxDisplayPIN_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDisplayPIN.Checked)
            {
                tbxPinCode.UseSystemPasswordChar = false;
            }
            else if(!checkBoxDisplayPIN.Checked)
            {
                tbxPinCode.UseSystemPasswordChar = true;
            }
            
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
