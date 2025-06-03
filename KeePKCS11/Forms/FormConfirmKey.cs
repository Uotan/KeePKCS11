using Net.Pkcs11Interop.Common;
using Net.Pkcs11Interop.HighLevelAPI;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KeePKCS11KeyProvider.Forms
{
    public partial class FormConfirmKey : Form
    {
        List<ISlot> slots = null;
        ISlot selectedSlot = null;
        Pkcs11InteropFactories factories;
        string libPath = null;
        string tokenSN = null;
        string objectLabel = null;

        public byte[] keyByteArray { get; private set; }

        public FormConfirmKey(string libPath, string tokenSN, string objectLabel)
        {
            this.libPath = libPath;
            this.tokenSN = tokenSN;
            this.objectLabel = objectLabel;
            InitializeComponent();
            
        }

        

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                keyByteArray = GetExistingKey(tbxPinCode.Text, libPath, tokenSN, objectLabel);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
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

        public byte[] GetExistingKey(string userPIN, string libPath, string tokenSN, string objectLablel)
        {
            Pkcs11InteropFactories factories = new Pkcs11InteropFactories();
            IPkcs11Library pkcs11Library = factories.Pkcs11LibraryFactory.LoadPkcs11Library(factories, libPath, AppType.MultiThreaded);
            List<ISlot> slots = pkcs11Library.GetSlotList(SlotsType.WithTokenPresent);
            ISlot selectedSlot = null;
            foreach (ISlot slot in slots)
            {
                var token = slot.GetTokenInfo();
                if (token.SerialNumber.Contains(tokenSN))
                {
                    selectedSlot = slot;
                    break;
                }

            }
            using (ISession session = selectedSlot.OpenSession(SessionType.ReadOnly))
            {
                // Login as normal user
                session.Login(CKU.CKU_USER, userPIN);

                List<IObjectAttribute> searchTemplate = new List<IObjectAttribute>();
                searchTemplate.Add(session.Factories.ObjectAttributeFactory.Create(CKA.CKA_CLASS, CKO.CKO_DATA));

                List<ulong> attributes = new List<ulong>();
                attributes.Add((ulong)CKA.CKA_LABEL);
                attributes.Add((ulong)CKA.CKA_VALUE);

                List<IObjectHandle> foundObjects = session.FindAllObjects(searchTemplate);
                foreach (var foundObject in foundObjects)
                {
                    List<IObjectAttribute> requiredAttributes = session.GetAttributeValue(foundObject, attributes);
                    if (requiredAttributes[0].GetValueAsString() == objectLabel.Trim())
                    {
                        return requiredAttributes[1].GetValueAsByteArray();
                    }
                }
                session.Logout();
            }
            return null;

        }
    }
}
