using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CoreLand.UI.CustomControls.HintableBoxes
{
    public partial class HintableBoxBase : TextBox
    {

        public static readonly DependencyProperty HintProperty = DependencyProperty.Register(nameof(Hint), typeof(string), typeof(HintableBoxBase),
                                                                 new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.AffectsRender));

        public static readonly DependencyProperty HintForegroundProperty = DependencyProperty.Register(nameof(HintForeground), typeof(SolidColorBrush), typeof(HintableBoxBase),
                                                         new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender));

        static HintableBoxBase()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(HintableBoxBase), new FrameworkPropertyMetadata(typeof(HintableBoxBase)));
        }
    }
}
