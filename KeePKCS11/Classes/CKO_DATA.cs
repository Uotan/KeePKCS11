using System;

namespace KeePKCS11.Classes
{
    //[Serializable] // Позволяет сериализацию
    public class CKO_DATA
    {
        // Все поля должны быть свойствами (public get/set) для сериализации
        public readonly string CKA_CLASS = "CKO_DATA"; // Значение по умолчанию
        public readonly bool CKA_TOKEN = true;
        public readonly bool CKA_PRIVATE = true; // Защита PIN-кодом по умолчанию
        public readonly bool CKA_MODIFIABLE = false; // защита от изменения
        public string CKA_LABEL; // Метка объекта
        public byte[] CKA_VALUE; // Бинарные данные

        public CKO_DATA(string _label, byte[] _value)
        {
            CKA_LABEL = _label;
            CKA_VALUE = _value;
        }
    }
}
