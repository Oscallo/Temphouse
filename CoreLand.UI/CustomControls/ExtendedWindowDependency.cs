using CoreLand.UI.Modules.Boxes;
using System;
using System.Windows;

namespace CoreLand.UI.CustomControls
{
    public partial class ExtendedWindow : System.Windows.Window
    {
        /// <summary>
        ///     DependencyProperty свойства IsHideable.
        /// </summary>
        public static readonly DependencyProperty IsHideableProperty = DependencyProperty.Register(nameof(IsHideable), typeof(bool), typeof(ExtendedWindow),
                               new FrameworkPropertyMetadata(BooleanBoxes.TrueBox,new PropertyChangedCallback(OnIsHideableChanged)));

        private static void OnIsHideableChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            
        }

        static ExtendedWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ExtendedWindow), new FrameworkPropertyMetadata(typeof(ExtendedWindow)));
        }
    }
}
