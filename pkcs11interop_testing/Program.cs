using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using Net.Pkcs11Interop.Common;
using Net.Pkcs11Interop.HighLevelAPI;
using Net.Pkcs11Interop.Logging;
using Net.Pkcs11Interop.LowLevelAPI40;

namespace pkcs11interop_testing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            using (IPkcs11Library pkcs11Library = Settings.Factories.Pkcs11LibraryFactory.LoadPkcs11Library(Settings.Factories, "C:\\Windows\\System32\\jcPKCS11-2.dll", Settings.AppType))
            {
                ILibraryInfo libraryInfo = pkcs11Library.GetInfo();
                Console.WriteLine(libraryInfo.LibraryVersion);
                Console.WriteLine(libraryInfo.ManufacturerId);
                Console.WriteLine(libraryInfo.CryptokiVersion);
                Console.WriteLine(libraryInfo.Flags);
                
            }


            using (IPkcs11Library pkcs11Library = Settings.Factories.Pkcs11LibraryFactory.LoadPkcs11Library(Settings.Factories, "C:\\Windows\\System32\\jcPKCS11-2.dll", Settings.AppType))
            {
                // Get list of available slots
                List<ISlot> slots = pkcs11Library.GetSlotList(SlotsType.WithTokenPresent);

                foreach (ISlot slot in slots)
                {
                    var slotInfo = slot.GetSlotInfo();
                    //Debug.WriteLine(slotInfo.ManufacturerId);
                    Console.WriteLine(slotInfo.SlotId);
                    Console.WriteLine(slotInfo.SlotDescription);
                }
            }
        }
    }
}
