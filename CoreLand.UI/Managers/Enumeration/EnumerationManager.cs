using CoreLand.UI.Attributes.Enum;
using System;
using System.Collections;
using System.ComponentModel;
using System.Reflection;

namespace CoreLand.UI.Managers.Enumeration
{
    public class EnumerationManager
    {
        public static Array GetValues(Type enumeration)
        {
            Array wArray = Enum.GetValues(enumeration);
            ArrayList wFinalArray = new ArrayList();
            foreach (Enum wValue in wArray)
            {
                FieldInfo fi = enumeration.GetField(wValue.ToString());
                if (null != fi)
                {
                    BrowsableAttribute[] wBrowsableAttributes = fi.GetCustomAttributes(typeof(BrowsableAttribute), true) as BrowsableAttribute[];
                    if (wBrowsableAttributes.Length > 0)
                    {
                        //  If the Browsable attribute is false
                        if (wBrowsableAttributes[0].Browsable == false)
                        {
                            // Do not add the enumeration to the list.
                            continue;
                        }
                    }

                    NameAttribute[] wDescriptions = fi.GetCustomAttributes(typeof(NameAttribute), true) as NameAttribute[];
                    if (wDescriptions.Length > 0)
                    {
                        wFinalArray.Add(wDescriptions[0].Name);
                    }
                    else
                        wFinalArray.Add(wValue);
                }
            }

            return wFinalArray.ToArray();
        }
    }
}
