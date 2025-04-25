using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Net.Pkcs11Interop.Common;
using Net.Pkcs11Interop.HighLevelAPI;

namespace WindowsForms_pkcs11admin
{
    public partial class Form1 : Form
    {
        Pkcs11InteropFactories factories;
        List<TokenInfo> tokenList = new List<TokenInfo>();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGetLibraryInfo_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbxLibraryPath.Text))
            {
                MessageBox.Show("Поле ввода пустое!");
            }
            else
            {
                factories = new Pkcs11InteropFactories();

                // Load unmanaged PKCS#11 library
                using (IPkcs11Library pkcs11Library = factories.Pkcs11LibraryFactory.LoadPkcs11Library(factories, tbxLibraryPath.Text, AppType.MultiThreaded))
                {
                    ILibraryInfo libraryInfo = pkcs11Library.GetInfo();

                    lblCryptokiVersion.Text = "Cryptoki Version: " + libraryInfo.CryptokiVersion;
                    lblLibraryManufacturer.Text = "Manufacturer: " + libraryInfo.ManufacturerId;
                    lblLibraryVersion.Text = "Library Version: " + libraryInfo.LibraryVersion;


                    List<ISlot> slots = pkcs11Library.GetSlotList(SlotsType.WithTokenPresent);

                    foreach (ISlot slot in slots)
                    {
                        var slotInfo = slot.GetSlotInfo();
                        var token = slot.GetTokenInfo();
                        TokenInfo tokenInfo = new TokenInfo();
                        tokenInfo.SlotId = slotInfo.SlotId;
                        tokenInfo.SerialNumber = token.SerialNumber;
                        tokenInfo.TokenLabel = token.Label;
                        tokenInfo.TokenModel = token.Model;
                        tokenList.Add(tokenInfo);
                    }

                    var bindingList = new BindingList<TokenInfo>(tokenList);
                    var source = new BindingSource(bindingList, null);
                    gridSlots.DataSource = source;

                }

                
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
