using System.Windows;

namespace CoreLand.UI.CustomControls
{

    public partial class ExtendedWindow : Window
    {
        static ExtendedWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ExtendedWindow), new FrameworkPropertyMetadata(typeof(ExtendedWindow)));
        }

    }
}
