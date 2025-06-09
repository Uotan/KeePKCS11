using KeePass.Plugins;
using KeePass.UI;
using Net.Pkcs11Interop.Common;
using Net.Pkcs11Interop.HighLevelAPI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KeePKCS11.Forms
{
    public partial class FormCreateOrSelect : Form
    {
        List<ISlot> slots = null;
        ISlot selectedSlot = null;
        Pkcs11InteropFactories factories;

        public byte[] keyByteArray { get; private set; }

        private IPluginHost m_host = null;
        private string database;
        private DynamicMenu m_dynGenProfiles;
        public FormCreateOrSelect()
        {
            InitializeComponent();
        }

        public FormCreateOrSelect(IPluginHost m_host)
        {
            this.m_host = m_host;
            InitializeComponent();
        }

        public FormCreateOrSelect(IPluginHost m_host, string p)
        {
            this.m_host = m_host;
            this.database = p;
            InitializeComponent();
        }

        //private void OnFormLoad(object sender, EventArgs e)
        //{
        //    GlobalWindowManager.AddWindow(this);
        //}

        //private void OnFormClose(object sender, FormClosingEventArgs e)
        //{
        //    GlobalWindowManager.RemoveWindow(this);
        //}


        /// <summary>
        /// Получение/обновление данных о библиотеке и о доступных слотах
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetLibraryInfo_Click(object sender, EventArgs e)
        {
            try
            {
                listViewTokens.Items.Clear();
                factories = new Pkcs11InteropFactories();

                IPkcs11Library pkcs11Library = factories.Pkcs11LibraryFactory.LoadPkcs11Library(factories, tbxLibraryPath.Text, AppType.MultiThreaded);

                ILibraryInfo libraryInfo = pkcs11Library.GetInfo();

                lblCryptokiVersion.Text = "pkcs#11 version: " + libraryInfo.CryptokiVersion;
                lblLibraryManufacturer.Text = "Manufacturer: " + libraryInfo.ManufacturerId;
                lblLibraryVersion.Text = "Library version: " + libraryInfo.LibraryVersion;

                slots = pkcs11Library.GetSlotList(SlotsType.WithTokenPresent);

                foreach (ISlot slot in slots)
                {
                    var slotInfo = slot.GetSlotInfo();
                    var token = slot.GetTokenInfo();
                    listViewTokens.Items.Add(new ListViewItem(new[] { Convert.ToString(slotInfo.SlotId), token.SerialNumber, token.Model, token.Label }));
                }
                btnReadTokenData.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            
        }
  

        /// <summary>
        /// Чтение данных с выбранного токена
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadTokenData_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewTokens.SelectedItems == null)
                {
                    MessageBox.Show("No slot is selected");
                    return;
                }
                //Вызываем диалоговое окно, для ввода пин кода для выбранного слота

                string tokenPin = null;
                using (FormEnterPIN formEnterPIN = new FormEnterPIN())
                {
                    if (UIUtil.ShowDialogAndDestroy(formEnterPIN) == DialogResult.OK)
                    {
                        tokenPin = formEnterPIN.enteredPIN;
                    }
                    else
                    {
                        MessageBox.Show("PIN code entry cancelled");
                        return;
                    }
                }

                listViewDataObjects.Items.Clear();
                //создаем объект ISlot, где SlotId совпадает с выбранным

                int intSlotID = Convert.ToInt32(this.listViewTokens.SelectedItems[0].SubItems[0].Text);
                ulong ulongSlotID = (ulong)intSlotID;
                selectedSlot = slots.FirstOrDefault(x => x.SlotId == ulongSlotID);

                List<string> dataObjects = FindAllObjects(tokenPin);

                foreach (var dataObject in dataObjects)
                {
                    listViewDataObjects.Items.Add(new ListViewItem(dataObject));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }


        /// <summary>
        /// Поиск всех доступных обхектов на токене
        /// </summary>
        /// <param name="_userPIN">PIN-код от пользователя</param>
        /// <returns>Список имен объектов</returns>
        List<string> FindAllObjects(string _userPIN)
        {
            try
            {
                List<string> objectsLabels = new List<string>();
                using (ISession session = selectedSlot.OpenSession(SessionType.ReadOnly))
                {
                    // Login as normal user
                    session.Login(CKU.CKU_USER, _userPIN);

                    List<IObjectAttribute> searchTemplate = new List<IObjectAttribute>();
                    searchTemplate.Add(session.Factories.ObjectAttributeFactory.Create(CKA.CKA_CLASS, CKO.CKO_DATA));

                    List<IObjectHandle> foundObjects = session.FindAllObjects(searchTemplate);
                    foreach (var foundObject in foundObjects)
                    {
                        List<ulong> attributes = new List<ulong>();
                        attributes.Add((ulong)CKA.CKA_LABEL);
                        List<IObjectAttribute> requiredAttributes = session.GetAttributeValue(foundObject, attributes);
                        objectsLabels.Add(requiredAttributes[0].GetValueAsString());
                    }
                    session.Logout();
                }
                return objectsLabels;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            
        }

        private void btnCreateKey_Click(object sender, EventArgs e)
        {
            try
            {
                string tokenPin = null;
                string objectLabel = null;

                FormEnterLabelAndPIN formEnterLabelAndPIN = new FormEnterLabelAndPIN();
                if (UIUtil.ShowDialogAndDestroy(formEnterLabelAndPIN) == DialogResult.OK)
                {
                    tokenPin = formEnterLabelAndPIN.enteredPIN;
                    objectLabel = formEnterLabelAndPIN.enteredObjectLabel;
                }
                else
                {
                    MessageBox.Show("PIN code entry cancelled");
                    return;
                }
                CreateObject(objectLabel, tokenPin);
                listViewDataObjects.Items.Clear();
                List<string> dataObjects = FindAllObjects(tokenPin);
                foreach (var dataObject in dataObjects)
                {
                    listViewDataObjects.Items.Add(new ListViewItem(dataObject));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            
        }

        /// <summary>
        /// Получение значения CKO_DATA объекта данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectKey_Click(object sender, EventArgs e)
        {
            try
            {
                string tokenPin = null;
                FormEnterPIN formEnterPIN = new FormEnterPIN();
                if (formEnterPIN.ShowDialog() == DialogResult.OK)
                {
                    tokenPin = formEnterPIN.enteredPIN;
                }
                else
                {
                    MessageBox.Show("PIN code entry cancelled");
                    return;
                }
                string keyValue = FindKeyObject(listViewDataObjects.SelectedItems[0].SubItems[0].Text, tokenPin);
                KeePKCS11.SaveSettings(this.tbxLibraryPath.Text, this.listViewTokens.SelectedItems[0].SubItems[1].Text, listViewDataObjects.SelectedItems[0].SubItems[0].Text);
                keyByteArray = Encoding.ASCII.GetBytes(keyValue);
                // return DialogResult.OK
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            
        }

        /// <summary>
        /// Ищет объекты CKO_DATA в выбраном токене по имени
        /// </summary>
        /// <param name="_findingObjectName">Название искомого объекта данных</param>
        /// <param name="_userPIN">PIN-код от пользователя</param>
        /// <returns></returns>
        string FindKeyObject(string _findingObjectName, string _userPIN)
        {
            try
            {
                string _keyValue = null;
                using (ISession session = selectedSlot.OpenSession(SessionType.ReadOnly))
                {
                    // Login as normal user
                    session.Login(CKU.CKU_USER, _userPIN);

                    List<IObjectAttribute> searchTemplate = new List<IObjectAttribute>();
                    searchTemplate.Add(session.Factories.ObjectAttributeFactory.Create(CKA.CKA_CLASS, CKO.CKO_DATA));

                    List<ulong> attributes = new List<ulong>();
                    attributes.Add((ulong)CKA.CKA_LABEL);
                    attributes.Add((ulong)CKA.CKA_VALUE);

                    List<IObjectHandle> foundObjects = session.FindAllObjects(searchTemplate);
                    foreach (var foundObject in foundObjects)
                    {
                        List<IObjectAttribute> requiredAttributes = session.GetAttributeValue(foundObject, attributes);
                        if (requiredAttributes[0].GetValueAsString() == _findingObjectName.Trim())
                        {
                            _keyValue = Encoding.UTF8.GetString(requiredAttributes[1].GetValueAsByteArray());
                        }
                    }
                    session.Logout();
                }
                return _keyValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            
        }

        /// <summary>
        /// Создает объект CKO_DATA в выбранном слоте (токене)
        /// </summary>
        /// <param name="_objectNameToCreate">Имя создаваемого объекта</param>
        /// <param name="_userPIN">PIN-код от пользователя</param>
        void CreateObject(string _objectNameToCreate, string _userPIN)
        {
            try
            {
                // Open RW session
                using (ISession session = selectedSlot.OpenSession(SessionType.ReadWrite))
                {
                    string keyValue = GenerateRandomPassword();
                    // Login as normal user
                    session.Login(CKU.CKU_USER, _userPIN);

                    // Prepare attribute template of new data object
                    List<IObjectAttribute> objectAttributes = new List<IObjectAttribute>();
                    objectAttributes.Add(session.Factories.ObjectAttributeFactory.Create(CKA.CKA_CLASS, CKO.CKO_DATA));
                    objectAttributes.Add(session.Factories.ObjectAttributeFactory.Create(CKA.CKA_TOKEN, true));
                    objectAttributes.Add(session.Factories.ObjectAttributeFactory.Create(CKA.CKA_PRIVATE, true));
                    objectAttributes.Add(session.Factories.ObjectAttributeFactory.Create(CKA.CKA_MODIFIABLE, false));
                    objectAttributes.Add(session.Factories.ObjectAttributeFactory.Create(CKA.CKA_LABEL, _objectNameToCreate));
                    objectAttributes.Add(session.Factories.ObjectAttributeFactory.Create(CKA.CKA_VALUE, keyValue));

                    // Create object
                    IObjectHandle objectHandle = session.CreateObject(objectAttributes);

                    // Do something interesting with new object

                    session.Logout();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            
        }

        /// <summary>
        /// Генератор случайного пароля
        /// </summary>
        /// <returns>256 битовое случайное значение пароля(Энтропия: ≈135.71 бит)</returns>
        string GenerateRandomPassword()
        {
            // Использовать Random() не безопасно, в следующей версии буду использовать встроенный генератор паролей KeePass
            Random rand = new Random();
            int symbolType;
            char[] charArray = new char[32];
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
            return new string(charArray).Trim();
        }

        /// <summary>
        /// Диалог выбора библиотеки pkcs11
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectLibrary_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.InitialDirectory = @"C:\Windows\System32";
                openFileDialog.Filter = "dll files (*.dll)|*.dll|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                    this.tbxLibraryPath.Text = openFileDialog.FileName;
                btnGetLibraryInfo.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Просто защита от дурака
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxLibraryPath_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbxLibraryPath.Text))
            {
                btnGetLibraryInfo.Enabled = false;
            }
            else
            {
                btnGetLibraryInfo.Enabled = true;
            }
        }
    }
}
