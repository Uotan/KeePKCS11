using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;
using WindowsForms_pkcs11admin.Classes;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //byte[] data = Encoding.UTF8.GetBytes("4E3900145638304C");
            byte[] data = Encoding.UTF8.GetBytes("4E3900145638304C");
            uint crc32 = Crc32.Compute(data);

            Console.WriteLine($"CRC32: {crc32:X8}"); // Вывод в HEX
        }
    }
}
