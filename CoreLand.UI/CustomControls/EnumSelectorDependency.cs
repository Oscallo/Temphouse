using CoreLand.UI.Modules.Boxes;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace CoreLand.UI.CustomControls
{
    public partial class EnumSelector : Selector
    {
        static EnumSelector()
        {
            KeyboardNavigation.TabNavigationProperty.OverrideMetadata(typeof(EnumSelector), new FrameworkPropertyMetadata(KeyboardNavigationMode.Local));
            KeyboardNavigation.ControlTabNavigationProperty.OverrideMetadata(typeof(EnumSelector), new FrameworkPropertyMetadata(KeyboardNavigationMode.None));
            KeyboardNavigation.DirectionalNavigationProperty.OverrideMetadata(typeof(EnumSelector), new FrameworkPropertyMetadata(KeyboardNavigationMode.None));

            DefaultStyleKeyProperty.OverrideMetadata(typeof(EnumSelector), new FrameworkPropertyMetadata(typeof(EnumSelector)));
        }
    }
}
