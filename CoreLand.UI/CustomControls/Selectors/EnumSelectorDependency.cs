using CoreLand.UI.CustomControls.Selectors.Consts;
using CoreLand.UI.CustomControls.Selectors.DefaultValues.Enums;
using CoreLand.UI.Managers.Enumeration;
using System;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace CoreLand.UI.CustomControls.Selectors
{
    public partial class EnumSelector : Selector
    {
        private const DefaultEnum _DefaultEnum = DefaultEnum.Default;

        public static readonly DependencyProperty EnumTypeProperty = DependencyProperty.Register(nameof(EnumType), typeof(Type), typeof(EnumSelector),
                                                         new FrameworkPropertyMetadata(_DefaultEnum.GetType(), FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(EnumTypeChanged)),new ValidateValueCallback(EnumTypeValidation));

        private static void EnumTypeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
            /*
            EnumSelector enumSelector = (EnumSelector)d;

            enumSelector.ItemsSource = EnumerationManager.GetValues((Type)e.NewValue);
            */
        }

        private static bool EnumTypeValidation(object value)
        {
            if (value == null) { return false; }
            if ((((Type)value).BaseType).FullName == EnumSelectorStrings.EnumBaseTypeFullName) { return true; }
            return true;
        }

        static EnumSelector()
        {
            KeyboardNavigation.TabNavigationProperty.OverrideMetadata(typeof(EnumSelector), new FrameworkPropertyMetadata(KeyboardNavigationMode.Local));
            KeyboardNavigation.ControlTabNavigationProperty.OverrideMetadata(typeof(EnumSelector), new FrameworkPropertyMetadata(KeyboardNavigationMode.None));
            KeyboardNavigation.DirectionalNavigationProperty.OverrideMetadata(typeof(EnumSelector), new FrameworkPropertyMetadata(KeyboardNavigationMode.None));

            DefaultStyleKeyProperty.OverrideMetadata(typeof(EnumSelector), new FrameworkPropertyMetadata(typeof(EnumSelector)));
        }
    }
}
