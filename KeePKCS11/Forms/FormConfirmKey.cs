using KeePass.UI;
using Net.Pkcs11Interop.Common;
using Net.Pkcs11Interop.HighLevelAPI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace KeePKCS11.Forms
{
    public partial class FormConfirmKey : Form
    {
        List<ISlot> slots = null;
        ISlot selectedSlot = null;
        Pkcs11InteropFactories factories;
        string libPath = null;
        string tokenSN = null;
        string objectLabel = null;
        string tokenModel = null;

        public byte[] keyByteArray { get; private set; }

        public FormConfirmKey(string _libPath, string _tokenSN, string _objectLabel, string _tokenModel)
        {
            libPath = _libPath;
            tokenSN = _tokenSN;
            objectLabel = _objectLabel;
            tokenModel = _tokenModel;
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
            try
            {
                keyByteArray = GetExistingKey(tbxPinCode.Text, libPath, tokenSN, objectLabel, tokenModel);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            // return DialogResult.OK
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // return DialogResult.Cancel
            Close();
        }

        /// <summary>
        /// Отображение/скрытие введенного пин-кода пользователя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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


        /// <summary>
        /// Получение значения существующего ключа
        /// </summary>
        /// <param name="userPIN">Пароль пользователя</param>
        /// <param name="libPath">Путь к pkcs11 библиотеке</param>
        /// <param name="tokenSN">Серийный номер токена</param>
        /// <param name="objectLablel">Имя объекта CKO_DATA</param>
        /// <returns></returns>
        public byte[] GetExistingKey(string userPIN, string libPath, string tokenSN, string objectLablel, string tokenModel)
        {
            try
            {
                Pkcs11InteropFactories factories = new Pkcs11InteropFactories();
                IPkcs11Library pkcs11Library = factories.Pkcs11LibraryFactory.LoadPkcs11Library(factories, libPath, AppType.MultiThreaded);
                List<ISlot> slots = pkcs11Library.GetSlotList(SlotsType.WithTokenPresent);
                ISlot selectedSlot = null;
                foreach (ISlot slot in slots)
                {
                    var token = slot.GetTokenInfo();
                    if (token.SerialNumber.Contains(tokenSN)&&token.Model.Contains(tokenModel))
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }


        /// <summary>
        /// Выбор другого ключа для открытия базы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChangeKey_Click(object sender, EventArgs e)
        {
            FormCreateOrSelect dialog = new FormCreateOrSelect();

            if (UIUtil.ShowDialogAndDestroy(dialog) == DialogResult.OK)
            {
                keyByteArray = dialog.keyByteArray;
            }
            // return DialogResult.OK
            Close();
        }

        private void FormConfirmKey_Load(object sender, EventArgs e)
        {
            lblTokeSerialNumber.Text = "Token S/N: " + tokenSN;
            lblTokeModel.Text = "Token Model: " + tokenModel;
        }
    }
}
