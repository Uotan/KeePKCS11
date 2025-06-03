using KeePass.Plugins;
using KeePass.UI;
using KeePassLib.Keys;
using KeePassLib.Utility;
using KeePKCS11KeyProvider;
using KeePKCS11KeyProvider.Forms;
using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace KeePKCS11KeyProvider
{
    // на конце имени класса обязательно должно быть окончание "Ext"
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

        /// <summary>
        /// Инициализация провайдера
        /// </summary>
        /// <param name="host"></param>
        /// <returns></returns>
        public override bool Initialize(IPluginHost host)
        {
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;

            m_prov = new KeePKCS11KeyProvider(host);
            m_host = host;
            m_host.KeyProviderPool.Add(m_prov);

            return true;
        }

        /// <summary>
        /// Уничтожение провайдера
        /// </summary>
        public override void Terminate()
        {
            m_host.KeyProviderPool.Remove(m_prov);
        }
    }


    /// <summary>
    /// Основнйо класс провайдера
    /// </summary>
    public sealed class KeePKCS11KeyProvider : KeyProvider
    {
        public static IPluginHost m_host = null;
        public static string keepkcs11_conf_lib_path = null;
        public static string keepkcs11_conf_token_sn_id = null;
        public static string keepkcs11_conf_object_label = null;
        public static string database_name = null;

        public override bool DirectKey { get { return true; } }

        public override bool Exclusive { get { return true; } }

        public KeePKCS11KeyProvider(IPluginHost host)
        {
            m_host = host;
        }


        /// <summary>
        /// Вернуть отображаемое имя для KeePass
        /// </summary>
        public override string Name
        {
            get { return "KeePKCS11KeyProvider"; }
        }


        public override byte[] GetKey(KeyProviderQueryContext ctx)
        {
            try
            {
                KeePKCS11KeyProvider.database_name = Path.GetFileName(ctx.DatabasePath);

                GetSettings();

                if (ctx.CreatingNewKey)
                {
                    return CreateOrSelectKey(ctx);
                }
                else
                {
                    return Open(ctx);
                }
            }
            catch (Exception ex) { MessageService.ShowWarning(ex.Message); }

            return null;
        }

        /// <summary>
        /// Создание или выбор объекта данных с токена
        /// </summary>
        /// <param name="ctx"></param>
        /// <returns>Массив байтов ключевого обхекта данных</returns>
        private static byte[] CreateOrSelectKey(KeyProviderQueryContext ctx)
        {
            FormCreateOrSelect dialog = new FormCreateOrSelect(m_host, Path.GetFileName(ctx.DatabasePath));

            if (UIUtil.ShowDialogAndDestroy(dialog) != DialogResult.OK)
            {
                return null;
            }
            else
            {
                return dialog.keyByteArray;
            }
        }

        /// <summary>
        /// Получить сохраненные данные о привязке ключевого объекта данных к KeePass базе данных
        /// </summary>
        public static void GetSettings()
        {
            string configBase = "KeePKCS11.";
            string strRef =
                Environment.MachineName + "." +
                Environment.UserDomainName + "." +
                Environment.UserName + ".";

            keepkcs11_conf_lib_path = m_host.CustomConfig.GetString(configBase + strRef + KeePKCS11KeyProvider.database_name + ".keepkcs11_lib_path");
            keepkcs11_conf_token_sn_id = m_host.CustomConfig.GetString(configBase + strRef + KeePKCS11KeyProvider.database_name + ".keepkcs11_token_sn_id");
            keepkcs11_conf_object_label = m_host.CustomConfig.GetString(configBase + strRef + KeePKCS11KeyProvider.database_name + ".keepkcs11_object_label");
        }

        /// <summary>
        /// Сохранение настроек для соотношения ключа с базой
        /// </summary>
        /// <param name="pkcs11LibraryPath">путь к модулю pkcs11</param>
        /// <param name="tokenSN">Серийный номер токена</param>
        /// <param name="objectLabel">Имя объекта данных</param>
        public static void SaveSettings(string pkcs11LibraryPath, string tokenSN, string objectLabel)
        {
            string configBase = "KeePKCS11.";
            string strRef =
                Environment.MachineName + "." +
                Environment.UserDomainName + "." +
                Environment.UserName + ".";
            string _keepkcs11_conf_lib_path = configBase + strRef + KeePKCS11KeyProvider.database_name + ".keepkcs11_lib_path";
            string _keepkcs11_conf_token_sn_id = configBase + strRef + KeePKCS11KeyProvider.database_name + ".keepkcs11_token_sn_id";
            string _keepkcs11_conf_object_label = configBase + strRef + KeePKCS11KeyProvider.database_name + ".keepkcs11_object_label";

            m_host.CustomConfig.SetString(_keepkcs11_conf_lib_path, pkcs11LibraryPath);
            m_host.CustomConfig.SetString(_keepkcs11_conf_token_sn_id, tokenSN);
            m_host.CustomConfig.SetString(_keepkcs11_conf_object_label, objectLabel);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctx"></param>
        /// <returns></returns>
        private static byte[] Open(KeyProviderQueryContext ctx)
        {
            GetSettings();

            if ((keepkcs11_conf_lib_path == null) || (keepkcs11_conf_token_sn_id == null))
            {
                FormCreateOrSelect dialog = new FormCreateOrSelect(m_host, Path.GetFileName(ctx.DatabasePath));

                if (UIUtil.ShowDialogAndDestroy(dialog) != DialogResult.OK)
                {
                    return null;
                }
                else
                {
                    return dialog.keyByteArray;
                }
            }
            else
            {
                try
                {
                    FormConfirmKey dialogConfirm = new FormConfirmKey(keepkcs11_conf_lib_path, keepkcs11_conf_token_sn_id, keepkcs11_conf_object_label);
                    if (UIUtil.ShowDialogAndDestroy(dialogConfirm) == DialogResult.OK)
                    {
                        return dialogConfirm.keyByteArray;
                    }

                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            return null;
        }
    }

}
