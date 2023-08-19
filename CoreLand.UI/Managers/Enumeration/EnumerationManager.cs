using CoreLand.UI.Attributes.Enum;
using System;
using System.Collections;
using System.ComponentModel;
using System.Reflection;

namespace CoreLand.UI.Managers.Enumeration
{
    public class EnumerationManager
    {
        /// <summary>
        /// Получение массива <seealso cref="Enum"/>, у которых указан <seealso cref="BrowsableAttribute"/> равный <seealso cref="true"/>
        /// </summary>
        /// <param name="type">Тип <seealso cref="Enum"/></param>
        /// <returns>Массив</returns>
        public static Array GetBrowsableValues(Type type)
        {
            Array wArray = Enum.GetValues(type);
            ArrayList wFinalArray = new ArrayList();
            foreach (Enum wValue in wArray)
            {
                FieldInfo fi = type.GetField(wValue.ToString());
                if (null != fi)
                {
                    BrowsableAttribute[] wBrowsableAttributes = fi.GetCustomAttributes(typeof(BrowsableAttribute), true) as BrowsableAttribute[];
                    if (wBrowsableAttributes.Length > 0)
                    {
                        if (wBrowsableAttributes[0].Browsable == false)
                        {
                            continue;
                        }
                        wFinalArray.Add(wValue);
                    }
                }
            }
            return wFinalArray.ToArray();
        }

        /// <summary>
        /// Получение массива <seealso cref="Enum"/>, у которых указан <seealso cref="NameAttribute"/> 
        /// </summary>
        /// <param name="type">Тип <seealso cref="Enum"/></param>
        /// <param name="onlyBrowsable">Указывает, проверять ли на <seealso cref="BrowsableAttribute"/> равный <seealso cref="true"/></param>
        /// <returns>Массив</returns>
        public static Array GetValues(Type type, bool onlyBrowsable = true)
        {
            Array wArray;
            ArrayList wFinalArray = new ArrayList();

            if (onlyBrowsable == true)
            {
                wArray = GetBrowsableValues(type);
            }
            else 
            {
                wArray = Enum.GetValues(type);
            }

            foreach (Enum wValue in wArray)
            {
                FieldInfo fi = type.GetField(wValue.ToString());
                if (null != fi)
                {
                    NameAttribute[] wDescriptions = fi.GetCustomAttributes(typeof(NameAttribute), true) as NameAttribute[];
                    if (wDescriptions.Length > 0)
                    {
                        wFinalArray.Add(wDescriptions[0].Name);
                    }
                    else
                    {
                        wFinalArray.Add(wValue);
                    }
                }
            }
            return wFinalArray.ToArray();
        }

        /// <summary>
        /// Получение <seealso cref="NameAttribute"/> у <seealso cref="Enum"/>
        /// </summary>
        /// <param name="enum"><seealso cref="Enum"/></param>
        /// <param name="type">Тип <seealso cref="Enum"/></param>
        /// <returns>Название, или если такового нет сам <seealso cref="Enum"/></returns>
        /// <exception cref="CustomAttributeFormatException">У<seealso cref="Enum"/> не найдены поля.</exception>
        public static string GetNameOfEnum(object @enum,Type type) 
        {
            FieldInfo fi = type.GetField(@enum.ToString());
            if (null != fi)
            {
                NameAttribute[] nameAttributes = fi.GetCustomAttributes(typeof(NameAttribute), true) as NameAttribute[];
                if (nameAttributes.Length > 0)
                {
                    return nameAttributes[0].Name;
                }
                else
                {
                    return @enum.ToString();
                }
            }
            throw new CustomAttributeFormatException();
        }

        /// <summary>
        /// Получение <seealso cref="Enum"/> по <seealso cref="NameAttribute"/>
        /// </summary>
        /// <param name="value"><seealso cref="NameAttribute"/> или сам <seealso cref="Enum"/></param>
        /// <param name="type">Тип <seealso cref="Enum"/></param>
        /// <returns><seealso cref="Enum"/></returns>
        /// <exception cref="Exception">Нет значений у <seealso cref="Enum"/> или не найдены соответствия. </exception>
        public static object GetEnumByName(object value, Type type)
        {
            Array wArray = Enum.GetValues(type);
            foreach (Enum wValue in wArray) 
            {
                FieldInfo fi = type.GetField(wValue.ToString());
                if (null != fi)
                {
                    NameAttribute[] nameAttributes = fi.GetCustomAttributes(typeof(NameAttribute), true) as NameAttribute[];
                    if (nameAttributes.Length > 0)
                    {
                        foreach (NameAttribute nameAttribute in nameAttributes)
                        {
                            if (nameAttribute.Name.ToString() == value.ToString()) { return wValue; }
                        }
                    }
                    else 
                    {
                        if (wValue.ToString() == value.ToString()) {return wValue; }
                    }
                }
            }
            throw new Exception();
        }
    }
}
