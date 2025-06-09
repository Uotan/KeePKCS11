using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Security.Cryptography;

namespace KeePKCS11_Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string GenerateRandomPassword()
            {
                int length = 32;
                string allowedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                if (length < 1)
                    throw new ArgumentException("Длина пароля должна быть положительной", nameof(length));

                if (string.IsNullOrEmpty(allowedChars))
                    throw new ArgumentException("Набор символов не может быть пустым", nameof(allowedChars));

                char[] password = new char[length];
                byte[] randomBytes = new byte[length * 4]; // Буфер для случайных байт

                using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
                {
                    rng.GetBytes(randomBytes); // Заполняем буфер криптостойкими байтами

                    for (int i = 0; i < length; i++)
                    {
                        // Преобразуем случайные байты в индекс символа
                        uint randomValue = BitConverter.ToUInt32(randomBytes, i * 4);
                        password[i] = allowedChars[(int)(randomValue % (uint)allowedChars.Length)];
                    }
                }

                return new string(password);
            }
            string myStrongPasswor = GenerateRandomPassword();
            Console.WriteLine(myStrongPasswor);
        }
    }
}
