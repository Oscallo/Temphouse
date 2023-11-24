using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace CoreLand.UI.CustomControls.Buttons
{

    public partial class ExToggleButton : ToggleButton
    {
        public static readonly DependencyProperty EllipseBrushProperty = DependencyProperty.Register(nameof(EllipseBrush), typeof(Brush), typeof(ExToggleButton),
                                   new FrameworkPropertyMetadata((Brush)null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.SubPropertiesDoNotAffectRender));

        static ExToggleButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ExToggleButton), new FrameworkPropertyMetadata(typeof(ExToggleButton)));
        }

        private static bool IsWidthHeightValid(object value)
        {
            double v = (double)value;
            return (Double.IsNaN(v)) || (v >= 0.0d && !Double.IsPositiveInfinity(v));
        }
    }
}
