using System;
using System.Windows;
using System.Windows.Controls;

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
