using System;
using System.Reflection;
using System.Runtime.InteropServices;
using Net.Pkcs11Interop.Common;
using Net.Pkcs11Interop.HighLevelAPI;

namespace pkcs11interop_testing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Set up a custom DllImportResolver that may be needed on some Linux distributions
            SetupCustomDllImportResolver();

            // Specify the path to unmanaged PKCS#11 library provided by the cryptographic device vendor
            string pkcs11LibraryPath = @"c:\SoftHSM2\lib\softhsm2-x64.dll";

            // Create factories used by Pkcs11Interop library
            Pkcs11InteropFactories factories = new Pkcs11InteropFactories();

            // Load unmanaged PKCS#11 library
            using (IPkcs11Library pkcs11Library = factories.Pkcs11LibraryFactory.LoadPkcs11Library(factories, pkcs11LibraryPath, AppType.MultiThreaded))
            {
                // Show general information about loaded library
                ILibraryInfo libraryInfo = pkcs11Library.GetInfo();

                Console.WriteLine("Library");
                Console.WriteLine("  Manufacturer:       " + libraryInfo.ManufacturerId);
                Console.WriteLine("  Description:        " + libraryInfo.LibraryDescription);
                Console.WriteLine("  Version:            " + libraryInfo.LibraryVersion);

                // Get list of all available slots
                foreach (ISlot slot in pkcs11Library.GetSlotList(SlotsType.WithOrWithoutTokenPresent))
                {
                    // Show basic information about slot
                    ISlotInfo slotInfo = slot.GetSlotInfo();

                    Console.WriteLine();
                    Console.WriteLine("Slot");
                    Console.WriteLine("  Manufacturer:       " + slotInfo.ManufacturerId);
                    Console.WriteLine("  Description:        " + slotInfo.SlotDescription);
                    Console.WriteLine("  Token present:      " + slotInfo.SlotFlags.TokenPresent);

                    if (slotInfo.SlotFlags.TokenPresent)
                    {
                        // Show basic information about token present in the slot
                        ITokenInfo tokenInfo = slot.GetTokenInfo();

                        Console.WriteLine("Token");
                        Console.WriteLine("  Manufacturer:       " + tokenInfo.ManufacturerId);
                        Console.WriteLine("  Model:              " + tokenInfo.Model);
                        Console.WriteLine("  Serial number:      " + tokenInfo.SerialNumber);
                        Console.WriteLine("  Label:              " + tokenInfo.Label);

                        // Show list of mechanisms (algorithms) supported by the token
                        Console.WriteLine("Supported mechanisms: ");
                        foreach (CKM mechanism in slot.GetMechanismList())
                            Console.WriteLine("  " + mechanism);
                    }
                }
            }
        }

        /// <summary>
        /// Sets up a custom DllImportResolver that may be needed when Pkcs11Interop is running on Linux with .NET 5 or later
        /// </summary>
        static void SetupCustomDllImportResolver()
        {

            if (Platform.IsLinux)
            {
                // Pkcs11Interop uses native functions from "libdl.so", but Ubuntu 22.04 and possibly also other distros have "libdl.so.2".
                // Therefore, we need to set up a DllImportResolver to remap "libdl" to "libdl.so.2".
                NativeLibrary.SetDllImportResolver(typeof(Pkcs11InteropFactories).Assembly, (libraryName, assembly, dllImportSearchPath) =>
                {
                    if (libraryName == "libdl")
                    {
                        // Note: This mapping might need to be modified if your distribution uses a different version of libdl.
                        return NativeLibrary.Load("libdl.so.2", assembly, dllImportSearchPath);
                    }
                    else
                    {
                        return NativeLibrary.Load(libraryName, assembly, dllImportSearchPath);
                    }
                });
            }

        }
    }
}
