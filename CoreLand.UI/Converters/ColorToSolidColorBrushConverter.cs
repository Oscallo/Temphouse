using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace CoreLand.UI.Converters
{
    [ValueConversion(typeof(Color), typeof(SolidColorBrush))]
    public class ColorToSolidColorBrushConverter : IValueConverter
    {
        private SolidColorBrushToColorConverter _SolidColorBrushToColorConverter = new SolidColorBrushToColorConverter();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return _SolidColorBrushToColorConverter.ConvertBack(value, targetType, parameter, culture);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return _SolidColorBrushToColorConverter.Convert(value, targetType, parameter, culture);
        }
    }
}
