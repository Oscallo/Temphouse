using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace CoreLand.UI.Converters
{
    [ValueConversion(typeof(Color), typeof(SolidColorBrush))]
    public class ColorToSolidColorBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Color color = (Color)value;
            Brush colorBrush = new SolidColorBrush(color);
            return colorBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            SolidColorBrushToColorConverter solidColorBrushToColorConverter = new SolidColorBrushToColorConverter();
            return solidColorBrushToColorConverter.Convert(value, targetType, parameter, culture);
        }
    }
}
