using System.Windows;

namespace CoreLand.UI.CustomControls.Buttons
{
    public partial class SquaredButton : SquaredButtonBase
    {
        static SquaredButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SquaredButton), new FrameworkPropertyMetadata(typeof(SquaredButton)));
        }
    }
}
