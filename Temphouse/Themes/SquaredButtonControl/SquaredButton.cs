using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Temphouse.Themes.SquaredButtonControl
{
    public class SquaredButton : Button
    {

        [TypeConverter(typeof(LengthConverter))]
        [Localizability(LocalizationCategory.None, Readability = Readability.Unreadable)]
        private new double Height
        {
            get { return (double)GetValue(HeightProperty); }
            set { SetValue(HeightProperty, value); }
        }

        [TypeConverter(typeof(LengthConverter))]
        [Localizability(LocalizationCategory.None, Readability = Readability.Unreadable)]
        private new double Width
        {
            get { return (double)GetValue(WidthProperty); }
            set { SetValue(WidthProperty, value); }
        }

        [TypeConverter(typeof(LengthConverter))]
        [Localizability(LocalizationCategory.None, Readability = Readability.Unreadable)]
        public double Edge
        {
            get { return (double)GetValue(EdgeProperty); }
            set { SetValue(EdgeProperty, value); }
        }

        public SquaredButton() : base() 
        {
        }

        public static readonly DependencyProperty EdgeProperty = DependencyProperty.Register(
                                                                 "Edge", typeof(double), typeof(SquaredButton),
                                                                 new FrameworkPropertyMetadata(Double.NaN,FrameworkPropertyMetadataOptions.AffectsMeasure,new PropertyChangedCallback(OnTransformDirty)),
                                                                 new ValidateValueCallback(IsEdgeValid));


        private static void OnTransformDirty(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SquaredButton squaredButton = ((SquaredButton)d);

            squaredButton.Width = (double)e.NewValue;
            squaredButton.Height = (double)e.NewValue;
        }

        private static bool IsEdgeValid(object value)
        {
            double doubleValue = (double)value;
            return (Double.IsNaN(doubleValue)) || (doubleValue >= 0.0d && !Double.IsPositiveInfinity(doubleValue));
        }


        static SquaredButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SquaredButton), new FrameworkPropertyMetadata(typeof(SquaredButton)));
        }
    }
}
