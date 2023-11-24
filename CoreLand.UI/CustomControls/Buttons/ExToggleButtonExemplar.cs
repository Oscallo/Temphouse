using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace CoreLand.UI.CustomControls.Buttons
{

    public partial class ExToggleButton : ToggleButton
    {
        [Bindable(true), Category("Appearance")]
        public Brush EllipseBrush
        {
            get { return (Brush)GetValue(EllipseBrushProperty); }
            set { SetValue(EllipseBrushProperty, value); }
        }
    }
}
