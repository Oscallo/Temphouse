using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace CoreLand.UI.Converters
{
    /// <summary>
    /// Базовый преобразователь кисти заднего фона для <seealso cref="Border"/>
    /// </summary>
    [ValueConversion(typeof(Border), typeof(Border))]
    internal class ToWhiteBackgroundBorderConventer : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Border border = (Border)value;
            border.Background = Brushes.White;
            return border;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
