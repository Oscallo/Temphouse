using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace CoreLand.UI.Converters
{
    [ValueConversion(typeof(object), typeof(Visibility))]
    internal class ContentToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) {return Visibility.Collapsed;}
            else { return Visibility.Visible; }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
