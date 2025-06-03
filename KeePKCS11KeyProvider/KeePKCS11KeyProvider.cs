/*
  CryptokiKeyPrivder - A PKCS#11 Plugin for Keepass
  Copyright (C) 2013 Daniel Pieper <daniel.pieper@implogy.de>

  This program is free software: you can redistribute it and/or modify
  it under the terms of the GNU General Public License as published by
  the Free Software Foundation, either version 3 of the License, or
  (at your option) any later version.

  This program is distributed in the hope that it will be useful,
  but WITHOUT ANY WARRANTY; without even the implied warranty of
  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
  GNU General Public License for more details.

  You should have received a copy of the GNU General Public License
  along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using KeePass.Plugins;
using KeePass.UI;
using KeePassLib.Keys;
using KeePassLib.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace KeePKCS11KeyProvider
{

    public sealed class KeePKCS11KeyProviderExt : Plugin
    {
        private Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            // Проверяем все версии Pkcs11Interop
            if (args.Name.StartsWith("Pkcs11Interop", StringComparison.OrdinalIgnoreCase) ||
                args.Name.StartsWith("Net.Pkcs11Interop", StringComparison.OrdinalIgnoreCase))
            {
                string resourceName = "KeePKCS11KeyProvider.Library.Pkcs11Interop.dll";

                using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
                {
                    if (stream == null) return null;
                    byte[] buffer = new byte[stream.Length];
                    stream.Read(buffer, 0, buffer.Length);
                    return Assembly.Load(buffer);
                }
            }
            return null;
        }

        private IPluginHost m_host = null;
        private KeePKCS11KeyProvider m_prov = null;

        public override bool Initialize(IPluginHost host)
        {
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
            m_prov = new KeePKCS11KeyProvider(host);
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
                return "0.1.0";
            }
        }
    }

    public sealed class KeePKCS11KeyProvider : KeyProvider
    {
        public static IPluginHost m_host = null;
        public static string pkcs11_conf_lib = null;
        public static string pkcs11_conf_slot = null;
        public static string pkcs11_conf_label = null;
        public static string database_name = null;

        public override bool DirectKey { get { return true; } }

        public override bool Exclusive { get { return true; } }

        public KeePKCS11KeyProvider(IPluginHost host)
        {
            m_host = host;
        }


        public override string Name
        {
            get { return "KeePKCS11KeyProvider"; }
        }

        public override byte[] GetKey(KeyProviderQueryContext ctx)
        {

            return null;
        }

        private static byte[] Create(KeyProviderQueryContext ctx)
        {
            return null;
        }

        public static void getSettings() {



        }


        public static void saveSettings(string lib, string slot, string label)
        {

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
