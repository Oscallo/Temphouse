using System;
using System.Globalization;
using System.Windows.Data;

namespace Temphouse.Converters
{
    /// <summary>
    /// Конвертер для получения первого <seealso cref="char">символа</seealso> из <seealso cref="string">строки</seealso>
    /// </summary>
    [ValueConversion(typeof(string), typeof(char))]
    public class StringToFirstCharConverter : IValueConverter
    {
        private const int _FIRSTCHARCONST = 0;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) { throw new NullReferenceException("Строка равна Null"); }
            return ((string)value)[_FIRSTCHARCONST];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
