using System;
using System.Collections.Generic;
using System.Text;
using KeePass.Plugins;
using KeePassLib.Keys;
using KeePassLib.Utility;
using KeePass.UI;
using System.IO;

namespace KeeTestProvider
{
    public class KeeTestProviderExt: Plugin
    {
        //public KeeTestExt()
        //{
        //    //AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
        //}
        //private Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        //{
        //    // Загружаем только Pkcs11Interop
        //    if (!args.Name.Contains("Pkcs11Interop"))
        //        return null;

        //    try
        //    {
        //        // Формируем имя ресурса: ПространствоИмен.Папка.Файл.dll
        //        string resourceName = "KeeTest.Library.Pkcs11Interop.dll";

        //        using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
        //        {
        //            if (stream == null) return null;

        //            byte[] buffer = new byte[stream.Length];
        //            stream.Read(buffer, 0, buffer.Length);
        //            return Assembly.Load(buffer);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Error loading Pkcs11Interop: " + ex.Message);
        //        return null;
        //    }
        //}

        private IPluginHost m_host = null;
        private KeeTestProvider m_prov = null;

        public override bool Initialize(IPluginHost host)
        {
            //AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;

            m_prov = new KeeTestProvider(host);
            m_host = host;
            m_host.KeyProviderPool.Add(m_prov);

            return true;
        }

        public override void Terminate()
        {
            m_host.KeyProviderPool.Remove(m_prov);
        }

        public override string UpdateUrl
        {
            get
            {
                return "http://implogy.de/CryptokiKeyProvider/version";
            }
        }
    }

    public sealed class KeeTestProvider : KeyProvider
    {
        public static IPluginHost m_host = null;
        public KeeTestProvider(IPluginHost host)
        {
            m_host = host;
        }

        public override string Name
        {
            get { return "KeeTestProvider"; }
        }

        public override byte[] GetKey(KeyProviderQueryContext ctx)
        {

            return null;
        }

        private static byte[] Create(KeyProviderQueryContext ctx)
        {
            return null;
        }



        public static bool ByteArrayToFile(string file, byte[] data)
        {
            try
            {
                System.IO.FileStream stream = new System.IO.FileStream(file, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                stream.Write(data, 0, data.Length);
                stream.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception caught in process: {0}", e.ToString());
            }
            return false;
        }

        private static byte[] Open(KeyProviderQueryContext ctx)
        {
            return null;
        }
    }
}

