using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsForms_pkcs11admin.Forms
{
    public partial class FormEnterLabelAndPIN : Form
    {
        public string enteredPIN { get; private set; }
        public string enteredObjectLabel { get; private set; }

        public FormEnterLabelAndPIN()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            enteredPIN = tbxPinCode.Text;
            enteredObjectLabel = tbxObjectLabel.Text;
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
    }
}
