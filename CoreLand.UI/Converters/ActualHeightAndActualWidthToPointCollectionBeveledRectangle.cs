using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows;
using System.Drawing.Printing;

namespace CoreLand.UI.Converters
{
    internal class ActualHeightAndActualWidthToPointCollectionBeveledRectangle : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            double degreesAngle = Double.NaN;
            double radianKoef = Math.PI / 180;

            double splitHeightKoef = (double)1 / 2;

            double height = (double)values[0];
            double width = (double)values[1];
            Thickness margins = (Thickness)values[2];

            height += margins.Bottom + margins.Top;
            width += margins.Left + margins.Right;

            try
            {
                degreesAngle = Double.Parse((string)parameter);
            }
            catch (Exception) 
            {
                degreesAngle = 0;
            }
            double radianAngle = degreesAngle * radianKoef;

            double bottomWidth = splitHeightKoef * height * (1.0 / Math.Tan(radianAngle));

            if (Double.IsInfinity(bottomWidth) == true) { bottomWidth = 0; }

            PointCollection points = new PointCollection();
            Point LTpoint = new Point(0, 0);
            Point RTpoint = new Point(width + bottomWidth, 0);

            Point RSpoint = new Point(width + bottomWidth, (1 - splitHeightKoef) * height);

            Point RBpoint = new Point(width, height);
            Point LBpoint = new Point(0, height);


            points.Add(LTpoint);
            points.Add(RTpoint);
            points.Add(RSpoint);
            points.Add(RBpoint);
            points.Add(LBpoint);
            return points;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
