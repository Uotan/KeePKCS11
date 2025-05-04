using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using Net.Pkcs11Interop.Common;
using Net.Pkcs11Interop.HighLevelAPI;
using WindowsForms_pkcs11admin.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WindowsForms_pkcs11admin
{
    public partial class FormMain : Form
    {
        List<ISlot> slots = null;
        ISlot selectedSlot = null;
        Pkcs11InteropFactories factories;
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnGetLibraryInfo_Click(object sender, EventArgs e)
        {
            try
            {
                listViewTokens.Items.Clear();
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "dll files (*.dll)|*.dll|All files (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                    this.tbxLibraryPath.Text = ofd.FileName;

                factories = new Pkcs11InteropFactories();

                // Load unmanaged PKCS#11 library
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

            }
            catch (Exception exeption)
            {
                MessageBox.Show(exeption.Message);
                throw;
            }
            btnReadTokenData.Enabled = true;
        }
  

        /// <summary>
        /// Нажатие кнопки для чтения данных с токена
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadTokenData_Click(object sender, EventArgs e)
        {
            if (listViewTokens.SelectedItems == null)
            {
                MessageBox.Show("No slot is selected");
                return;
            }
            //Вызываем диалоговое окно, для ввода пин кода для выбранного слота
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
            listViewDataObjects.Items.Clear();
            //создаем объект ISlot, где SlotId совпадает с выбранным
            ulong.TryParse(this.listViewTokens.SelectedItems[0].SubItems[0].Text, out ulong selectedSlotID);
            selectedSlot = slots.FirstOrDefault(x => x.SlotId == selectedSlotID);

            List <string> dataObjects = FindAllObjects(tokenPin);

            foreach (var dataObject in dataObjects)
            {
                listViewDataObjects.Items.Add(new ListViewItem(dataObject));
            }


        }

        List<string> FindAllObjects(string _userPIN)
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

        private void btnCreateKey_Click(object sender, EventArgs e)
        {
            string tokenPin = null;
            string objectLabel = null;

            FormEnterLabelAndPIN formEnterLabelAndPIN = new FormEnterLabelAndPIN();
            if (formEnterLabelAndPIN.ShowDialog() == DialogResult.OK)
            {
                tokenPin = formEnterLabelAndPIN.enteredPIN;
                objectLabel = formEnterLabelAndPIN.enteredObjectLabel;
            }
            else
            {
                MessageBox.Show("PIN code entry cancelled");
                return;
            }
            CreateObject(objectLabel,tokenPin);


            listViewDataObjects.Items.Clear();
            List<string> dataObjects = FindAllObjects(tokenPin);
            foreach (var dataObject in dataObjects)
            {
                listViewDataObjects.Items.Add(new ListViewItem(dataObject));
            }


        }

        private void btnSelectKey_Click(object sender, EventArgs e)
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
            Debug.WriteLine(keyValue);
        }



        /// <summary>
        /// Ищет объекты в выбраном токене по имени
        /// </summary>
        /// <param name="_findingObjectName">Название искомого объекта данных</param>
        /// <param name="_userPIN">Энтропия: ~190.5 бит</param>
        /// <returns></returns>
        string FindKeyObject(string _findingObjectName, string _userPIN)
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
                    if (requiredAttributes[0].GetValueAsString()== _findingObjectName.Trim())
                    {
                        _keyValue = Encoding.UTF8.GetString(requiredAttributes[1].GetValueAsByteArray());
                    }
                }
                session.Logout();
            }
            return _keyValue;
        }



        /// <summary>
        /// Создает объект данных вы выбранном слоте (токене)
        /// </summary>
        /// <param name="_objectNameToCreate">Имя создаваемого объекта</param>
        /// <param name="_userPIN">Энтропия: ~190.5 бит</param>
        void CreateObject(string _objectNameToCreate, string _userPIN)
        {
            // Open RW session
            using (ISession session = selectedSlot.OpenSession(SessionType.ReadWrite))
            {
                string keyValue = GeneratingRandomPassword();
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



        /// <summary>
        /// Генератор случайного пароля
        /// </summary>
        /// <returns>256 битовое случайное значение пароля(Энтропия: ~190.5 бит)</returns>
        string GeneratingRandomPassword()
        {
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
    }
}
