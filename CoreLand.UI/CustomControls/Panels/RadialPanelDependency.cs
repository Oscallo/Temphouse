using CoreLand.UI.MicrosoftClasses.KnownBoxes;
using System.Windows;
using System.Windows.Controls;

namespace CoreLand.UI.CustomControls.Panels
{
    public partial class RadialPanel : Panel
    {
        public static readonly DependencyProperty IsAutoGenerateRadiusProperty = DependencyProperty.Register("IsAutoGenerateRadius", typeof(bool),typeof(RadialPanel),
                        new FrameworkPropertyMetadata(BooleanBoxes.TrueBox, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender));

        public static readonly DependencyProperty RadiusProperty = DependencyProperty.Register("Radius", typeof(double), typeof(RadialPanel),
                new FrameworkPropertyMetadata((double)50, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender));

        static RadialPanel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RadialPanel), new FrameworkPropertyMetadata(typeof(RadialPanel)));
        }
    }
}
