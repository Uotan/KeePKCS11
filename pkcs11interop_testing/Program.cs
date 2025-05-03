using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime;
using System.Runtime.InteropServices;
using Net.Pkcs11Interop.Common;
using Net.Pkcs11Interop.HighLevelAPI;

namespace pkcs11interop_testing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pkcs11InteropFactories pkcs11InteropFactories = new Pkcs11InteropFactories();
            string libraryPath = @"C:\Windows\System32\jcPKCS11-2.dll";
            List<ISlot> slots = null;
            string userPIN = "11111111";
            string testLabel = "test label";
            string testData = "test DATA";

            CreateDestroyObjectTest();

            void CreateDestroyObjectTest()
            {
                using (IPkcs11Library pkcs11Library = pkcs11InteropFactories.Pkcs11LibraryFactory.LoadPkcs11Library(pkcs11InteropFactories, libraryPath, AppType.MultiThreaded))
                {
                    // Find first slot with token present
                    slots = pkcs11Library.GetSlotList(SlotsType.WithTokenPresent);

                    ISlot slot = slots.FirstOrDefault();

                    // Open RW session
                    using (ISession session = slot.OpenSession(SessionType.ReadWrite))
                    {
                        // Login as normal user
                        session.Login(CKU.CKU_USER, userPIN);

                        // Prepare attribute template of new data object
                        List<IObjectAttribute> objectAttributes = new List<IObjectAttribute>();
                        objectAttributes.Add(session.Factories.ObjectAttributeFactory.Create(CKA.CKA_CLASS, CKO.CKO_DATA));
                        objectAttributes.Add(session.Factories.ObjectAttributeFactory.Create(CKA.CKA_TOKEN, true));
                        objectAttributes.Add(session.Factories.ObjectAttributeFactory.Create(CKA.CKA_PRIVATE, true));
                        objectAttributes.Add(session.Factories.ObjectAttributeFactory.Create(CKA.CKA_MODIFIABLE, false));
                        objectAttributes.Add(session.Factories.ObjectAttributeFactory.Create(CKA.CKA_LABEL, testLabel));
                        objectAttributes.Add(session.Factories.ObjectAttributeFactory.Create(CKA.CKA_VALUE, testData));

                        // Create object
                        IObjectHandle objectHandle = session.CreateObject(objectAttributes);

                        // Do something interesting with new object

                        session.Logout();
                    }
                }
            }

        }

        
    }
}
