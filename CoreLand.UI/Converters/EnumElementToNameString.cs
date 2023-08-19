using CoreLand.UI.Managers.Enumeration;
using System;
using System.Globalization;
using System.Windows.Data;

namespace CoreLand.UI.Converters
{
    [ValueConversion(typeof(Enum), typeof(string))]
    public class EnumElementToNameString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return EnumerationManager.GetNameOfEnum(value,value.GetType());
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return EnumerationManager.GetEnumByName(value, targetType);
        }
    }
}
