/*
   KeePKCS11 - A plugin for KeePass using the PKCS#11 standard for storing keys on cryptographic tokens
   Copyright (C) 2025 Uotan

   GNU GENERAL PUBLIC LICENSE
   Version 2, June 1991

   Copyright (C) 1989, 1991 Free Software Foundation, Inc.
   <https://fsf.org/>

   Everyone is permitted to copy and distribute verbatim copies
   of this license document, but changing it is not allowed.

   For the full license text, see: https://www.gnu.org/licenses/old-licenses/gpl-2.0.txt
*/

using KeePass.Plugins;
using KeePass.UI;
using KeePassLib.Keys;
using KeePassLib.Utility;
using KeePKCS11.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace KeePKCS11
{
    public sealed class KeePKCS11Ext : Plugin
    {

        private Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            // Дополнительно проверяем "Ссылки" на Pkcs11Interop.dll
            // Проверяем все версии Pkcs11Interop
            if (args.Name.StartsWith("Pkcs11Interop", StringComparison.OrdinalIgnoreCase) ||
                args.Name.StartsWith("Net.Pkcs11Interop", StringComparison.OrdinalIgnoreCase))
            {
                string resourceName = "KeePKCS11.Library.Pkcs11Interop.dll";

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
        private KeePKCS11 m_prov = null;

        public override bool Initialize(IPluginHost host)
        {
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
            m_prov = new KeePKCS11(host);
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
                return "1.0";
            }
        }
    }


    /// <summary>
    /// Основновй класс поставщика ключей KeePKCS11
    /// </summary>
    public sealed class KeePKCS11 : KeyProvider
    {
        public static IPluginHost m_host = null;
        public static string keepkcs11_conf_lib_path = null;
        public static string keepkcs11_conf_token_sn_id = null;
        public static string keepkcs11_conf_object_label = null;
        public static string database_name = null;

        public override bool DirectKey { get { return true; } }

        public override bool Exclusive { get { return true; } }

        public KeePKCS11(IPluginHost host)
        {
            m_host = host;
        }


        /// <summary>
        /// Вернуть отображаемое имя для KeePass
        /// </summary>
        public override string Name
        {
            get { return "KeePKCS11"; }
        }


        /// <summary>
        /// Функция полученя ключа для новой либо существующей базы данных
        /// </summary>
        /// <param name="ctx"></param>
        /// <returns></returns>
        public override byte[] GetKey(KeyProviderQueryContext ctx)
        {
            try
            {
                KeePKCS11.database_name = Path.GetFileName(ctx.DatabasePath);
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
        /// <returns>Массив байтов ключевого объекта данных</returns>
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
        /// Получить сохраненные данные о привязке ключевого объекта данных к базе KeePass
        /// </summary>
        public static void GetSettings()
        {
            string configBase = "KeePKCS11.";
            string strRef =
                Environment.MachineName + "." +
                Environment.UserDomainName + "." +
                Environment.UserName + ".";

            keepkcs11_conf_lib_path = m_host.CustomConfig.GetString(configBase + strRef + KeePKCS11.database_name + ".keepkcs11_lib_path");
            keepkcs11_conf_token_sn_id = m_host.CustomConfig.GetString(configBase + strRef + KeePKCS11.database_name + ".keepkcs11_token_sn_id");
            keepkcs11_conf_object_label = m_host.CustomConfig.GetString(configBase + strRef + KeePKCS11.database_name + ".keepkcs11_object_label");
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
            string _keepkcs11_conf_lib_path = configBase + strRef + KeePKCS11.database_name + ".keepkcs11_lib_path";
            string _keepkcs11_conf_token_sn_id = configBase + strRef + KeePKCS11.database_name + ".keepkcs11_token_sn_id";
            string _keepkcs11_conf_object_label = configBase + strRef + KeePKCS11.database_name + ".keepkcs11_object_label";

            m_host.CustomConfig.SetString(_keepkcs11_conf_lib_path, pkcs11LibraryPath);
            m_host.CustomConfig.SetString(_keepkcs11_conf_token_sn_id, tokenSN);
            m_host.CustomConfig.SetString(_keepkcs11_conf_object_label, objectLabel);
        }


        /// <summary>
        /// Хз, не разобрался, пусть пока останется тут
        /// </summary>
        /// <param name="file"></param>
        /// <param name="data"></param>
        /// <returns></returns>
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
        /// Открыть базу KeePass, используя поставщик KeePKCS11
        /// </summary>
        /// <param name="ctx"></param>
        /// <returns></returns>
        private static byte[] Open(KeyProviderQueryContext ctx)
        {
            GetSettings();

            //Если в сохраненных настройках нет данных о соотношении ключа с базой
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
            // иначе пытаемся открыть базу, используя ключ, который указан в сохраненных настройках
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
