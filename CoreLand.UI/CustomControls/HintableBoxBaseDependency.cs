using CoreLand.UI.Modules.Boxes;
using System;
using System.Collections.Generic;
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

namespace CoreLand.UI.CustomControls
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
