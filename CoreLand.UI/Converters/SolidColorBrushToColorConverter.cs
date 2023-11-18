using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace CoreLand.UI.Converters
{
    [ValueConversion(typeof(SolidColorBrush),typeof(Color))]
    public class SolidColorBrushToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            SolidColorBrush colorBrush = (SolidColorBrush)value;
            return colorBrush.Color;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ColorToSolidColorBrushConverter colorToSolidColorBrushConverter = new ColorToSolidColorBrushConverter();
            return colorToSolidColorBrushConverter.Convert(value, targetType, parameter, culture);
        }
    }
}
