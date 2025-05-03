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

namespace WindowsForms_pkcs11admin
{
    public partial class FormMain : Form
    {
        List<ISlot> slots = null;
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
                using (IPkcs11Library pkcs11Library = factories.Pkcs11LibraryFactory.LoadPkcs11Library(factories, tbxLibraryPath.Text, AppType.MultiThreaded))
                {
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
                tokenPin = formEnterPIN.EnteredText;
            }
            else
            {
                MessageBox.Show("PIN code entry cancelled");
            }

            //создаем объект ISlot, где SlotId совпадает с выбранным
            ulong.TryParse(this.listViewTokens.SelectedItems[0].SubItems[0].Text, out ulong selectedSlotID);
            ISlot selectedSlot = slots.FirstOrDefault(x => x.SlotId == selectedSlotID);


            using (ISession session = selectedSlot.OpenSession(SessionType.ReadWrite))
            {
                // Login as normal user
                session.Login(CKU.CKU_USER, tokenPin);

                //session.Logout();
            }

            //ReadDataObjects(selectedSlot, tokenPin);
        }

        public void ReadDataObjects(ISlot slot, string pin)
        {
            using (ISession session = slot.OpenSession(SessionType.ReadWrite))
            {
                // Login as normal user
                session.Login(CKU.CKU_USER, pin);

                //session.Logout();
            }
        }

    }
}
