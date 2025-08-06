using KeePass.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace KeePKCS11.Forms
{
    public partial class FormEnterLabelAndPIN : Form
    {

        public String enteredPIN;
        public String enteredObjectLabel;

        public FormEnterLabelAndPIN()
        {
            InitializeComponent();
        }

        private void OnFormLoad(object sender, EventArgs e)
        {
            GlobalWindowManager.AddWindow(this);
            tbxPinCode.Focus();
        }

        private void OnFormClose(object sender, FormClosingEventArgs e)
        {
            GlobalWindowManager.RemoveWindow(this);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //Если имя объекта не задано - просто сгенерируем его
            if (string.IsNullOrEmpty(tbxObjectLabel.Text))
            {
                Random rand = new Random();
                int symbolType;
                char[] charArray = new char[12];
                for (int i = 0; i < charArray.Length; i++)
                {
                    symbolType = rand.Next(1, 4);
                    if (symbolType == 1)
                    {
                        //цифры от 0 до 9 по ASKII таблице
                        charArray[i] = (char)rand.Next(48, 58);
                    }
                    if (symbolType == 2)
                    {
                        //Латинские прописные символы A-Z по ASKII таблице
                        charArray[i] = (char)rand.Next(65, 91);
                    }
                    if (symbolType == 3)
                    {
                        //Латинские строчные символы a-z по ASKII таблице
                        charArray[i] = (char)rand.Next(97, 123);
                    }
                }
                enteredObjectLabel = new string(charArray).Trim();
            }
            //Иначе оставим таким, какик его хотел назвать пользователь
            else
            {
                enteredObjectLabel = tbxObjectLabel.Text;
            }

            enteredPIN = tbxPinCode.Text;

            // return DialogResult.OK
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
            // return DialogResult.Cancel
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
