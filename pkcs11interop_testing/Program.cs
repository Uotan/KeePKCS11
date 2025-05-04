using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Text;
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
            string userPIN = "11111111";
            string testLabel = "test label";
            string testData = "test DATA";

            List<ISlot> slots = null;
            ISlot slot = null;



            LessInitThisThing();

            //CreateObjectTest();

            //FindAllObjects();


            string keyValue = null;
            keyValue = FindKeyObject("secret");
            Console.WriteLine(keyValue);

            Console.ReadKey();



            void LessInitThisThing()
            {
                IPkcs11Library pkcs11Library = pkcs11InteropFactories.Pkcs11LibraryFactory.LoadPkcs11Library(pkcs11InteropFactories,
                    libraryPath, AppType.MultiThreaded);
                slots = pkcs11Library.GetSlotList(SlotsType.WithTokenPresent);
                slot = slots.FirstOrDefault();
            }

            void CreateObjectTest()
            {

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

            void FindAllObjects()
            {

                using (ISession session = slot.OpenSession(SessionType.ReadOnly))
                {
                    // Login as normal user
                    session.Login(CKU.CKU_USER, userPIN);

                    List<IObjectAttribute> searchTemplate = new List<IObjectAttribute>();
                    searchTemplate.Add(session.Factories.ObjectAttributeFactory.Create(CKA.CKA_CLASS, CKO.CKO_DATA));

                    List<ulong> attributes = new List<ulong>();
                    attributes.Add((ulong)CKA.CKA_PRIVATE);
                    attributes.Add((ulong)CKA.CKA_LABEL);
                    attributes.Add((ulong)CKA.CKA_APPLICATION);
                    attributes.Add((ulong)CKA.CKA_VALUE);

                    List<IObjectHandle> foundObjects = session.FindAllObjects(searchTemplate);
                    foreach (var foundObject in foundObjects)
                    {
                        List<IObjectAttribute> requiredAttributes = session.GetAttributeValue(foundObject, attributes);
                        Console.Write(requiredAttributes[1].GetValueAsString()+"\t");
                        Console.WriteLine(Encoding.UTF8.GetString(requiredAttributes[3].GetValueAsByteArray()));
                    }

                    session.Logout();
                }

            }


            string FindKeyObject(string _keyObjectLabel)
            {
                string _keyValue = null;
                using (ISession session = slot.OpenSession(SessionType.ReadOnly))
                {
                    // Login as normal user
                    session.Login(CKU.CKU_USER, userPIN);

                    List<IObjectAttribute> searchTemplate = new List<IObjectAttribute>();
                    searchTemplate.Add(session.Factories.ObjectAttributeFactory.Create(CKA.CKA_CLASS, CKO.CKO_DATA));

                    List<ulong> attributes = new List<ulong>();
                    attributes.Add((ulong)CKA.CKA_PRIVATE);
                    attributes.Add((ulong)CKA.CKA_LABEL);
                    attributes.Add((ulong)CKA.CKA_APPLICATION);
                    attributes.Add((ulong)CKA.CKA_VALUE);

                    List<IObjectHandle> foundObjects = session.FindAllObjects(searchTemplate);
                    foreach (var foundObject in foundObjects)
                    {
                        List<IObjectAttribute> requiredAttributes = session.GetAttributeValue(foundObject, attributes);
                        if (requiredAttributes[1].GetValueAsString().Contains(_keyObjectLabel.Trim()))
                        {
                            _keyValue = Encoding.UTF8.GetString(requiredAttributes[3].GetValueAsByteArray());
                        }
                    }
                    session.Logout();
                }
                return _keyValue;

            }

        }

        
    }
}
