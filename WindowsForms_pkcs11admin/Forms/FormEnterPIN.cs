using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsForms_pkcs11admin.Forms
{
    public partial class FormEnterPIN : Form
    {
        public string EnteredText { get; private set; }
        public FormEnterPIN()
        {
            InitializeComponent();
        }

        

        private void btnOk_Click(object sender, EventArgs e)
        {
            EnteredText = tbxPinCode.Text; // Сохраняем текст
            DialogResult = DialogResult.OK; // Закрываем с результатом OK
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void FormEnterPIN_Load(object sender, EventArgs e)
        {
            //tbxPinCode.PasswordChar = '*';
        }
    }
}
