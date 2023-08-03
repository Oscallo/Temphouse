using System.Windows.Controls;
using System.Windows.Media;

namespace CoreLand.UI.CustomControls.HintableBoxes
{
    public partial class HintableBoxBase : TextBox
    {
        public string Hint
        {
            get { return (string)GetValue(HintProperty); }
            set { SetValue(HintProperty, value); }
        }

        public SolidColorBrush HintForeground
        {
            get { return (SolidColorBrush)GetValue(HintForegroundProperty); }
            set { SetValue(HintForegroundProperty, value); }
        }
    }
}
