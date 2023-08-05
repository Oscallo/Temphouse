using CoreLand.UI.MicrosoftClasses.KnownBoxes;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace CoreLand.UI.CustomControls.Panels
{
    public partial class RadialPanel : Panel
    {
        static RadialPanel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RadialPanel), new FrameworkPropertyMetadata(typeof(RadialPanel)));
        }

        public static readonly DependencyProperty IsAutoGenerateRadiusProperty = DependencyProperty.Register("IsAutoGenerateRadius", typeof(bool), typeof(RadialPanel),
                new FrameworkPropertyMetadata(BooleanBoxes.TrueBox, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender));

        public static readonly DependencyProperty RadiusProperty = DependencyProperty.Register("Radius", typeof(double), typeof(RadialPanel),
                new FrameworkPropertyMetadata((double)50, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(OnRadiusChanged)), new ValidateValueCallback(IsRadiusValid));

        public static readonly DependencyProperty MinRadiusProperty = DependencyProperty.Register("MinRadius", typeof(double), typeof(RadialPanel),
                new FrameworkPropertyMetadata((double)0, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(OnMinRadiusChanged)), new ValidateValueCallback(IsMinRadiusValid));

        public static readonly DependencyProperty MaxRadiusProperty = DependencyProperty.Register("MaxRadius", typeof(double), typeof(RadialPanel),
                new FrameworkPropertyMetadata(Double.MaxValue, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(OnMaxRadiusChanged)), new ValidateValueCallback(IsMaxRadiusValid));

        private static bool IsRadiusValid(object value)
        {
            double v = (double)value;
            return (Double.IsNaN(v) == true) || (v >= 0.0d && (Double.IsPositiveInfinity(v) == false));
        }

        private static bool IsMinRadiusValid(object value)
        {
            double v = (double)value;
            return (Double.IsNaN(v) == false) && (v >= 0.0d) && (Double.IsPositiveInfinity(v) == false);
        }

        private static bool IsMaxRadiusValid(object value)
        {
            double v = (double)value;
            return (Double.IsNaN(v) == false) && (v >= 0.0d);
        }

        private static void OnRadiusChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            RadialPanel radialPanel = d as RadialPanel;
            Debug.Assert(radialPanel != null, "d must be typeof RadialPanel");
            radialPanel.OnRadiusChanged((double)e.NewValue);
        }

        private static void OnMinRadiusChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            RadialPanel radialPanel = d as RadialPanel;
            Debug.Assert(radialPanel != null, "d must be typeof RadialPanel");
            radialPanel.OnMinRadiusChanged((double)e.NewValue);
        }

        private static void OnMaxRadiusChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            RadialPanel radialPanel = d as RadialPanel;
            Debug.Assert(radialPanel != null, "d must be typeof RadialPanel");
            radialPanel.OnMaxRadiusChanged((double)e.NewValue);
        }
    }
}
