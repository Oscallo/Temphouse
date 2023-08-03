using System.Windows;

namespace CoreLand.UI.CustomControls.HintableBoxes
{
    public partial class HintableTextBox : HintableBoxBase
    {
        static HintableTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(HintableTextBox), new FrameworkPropertyMetadata(typeof(HintableTextBox)));
        }
    }
}
