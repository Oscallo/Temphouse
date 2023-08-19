using CoreLand.UI.CustomControls.Selectors.Consts;
using CoreLand.UI.CustomControls.Selectors.DefaultValues.Enums;
using CoreLand.UI.Managers.Enumeration;
using CoreLand.UI.MicrosoftClasses.KnownBoxes;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace CoreLand.UI.AttachedProperties
{
    public class DataController : ItemsControl
    {
        private const DefaultEnum _DefaultEnum = DefaultEnum.Default;

        public static readonly DependencyProperty EnumTypeRAProperty = DependencyProperty.RegisterAttached("EnumTypeRA", typeof(Type), typeof(DataController),
                                                         new FrameworkPropertyMetadata(_DefaultEnum.GetType(), FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(EnumTypeChanged)), new ValidateValueCallback(EnumTypeValidation));

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly DependencyProperty ItemsSourceLockedProperty = DependencyProperty.RegisterAttached("ItemsSourceLocked", typeof(Boolean), typeof(DataController),
                                                  new FrameworkPropertyMetadata(BooleanBoxes.FalseBox, FrameworkPropertyMetadataOptions.AffectsRender));

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly DependencyProperty IsEnumTypeSetedWithEnumTypeProperty = DependencyProperty.RegisterAttached("IsEnumTypeSetedWithEnumType", typeof(Boolean), typeof(DataController),
                                          new FrameworkPropertyMetadata(BooleanBoxes.FalseBox, FrameworkPropertyMetadataOptions.AffectsRender));


        static DataController() 
        {
            
        }

        private static void EnumTypeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
            /*
            ItemsControl itemsControl = (ItemsControl)d;

            if (((Boolean)itemsControl.GetValue(IsEnumTypeSetedWithEnumTypeProperty) == false) && (itemsControl.ItemsSource != null))
            {
                throw new NotSupportedException("Не возможно использовать EnumType и ItemsSource");
            }

            itemsControl.ItemsSource = EnumerationManager.GetValues((Type)e.NewValue);

            itemsControl.SetValue(IsEnumTypeSetedWithEnumTypeProperty, true);
            */
        }

        private static bool EnumTypeValidation(object value)
        {
            if (value == null) { return false; }
            if ((((Type)value).BaseType).FullName == EnumSelectorStrings.EnumBaseTypeFullName) { return true; }
            return true;
        }

        public static void SetEnumTypeRA(ItemsControl element, Type value)
        {
            element.SetValue(EnumTypeRAProperty, value);
        }

        public static Type GetEnumTypeRA(ItemsControl element)
        {
            return (Type)element.GetValue(EnumTypeRAProperty);
        }

        public static void SetItemsSourceLocked(ItemsControl element, Boolean value)
        {
            element.SetValue(ItemsSourceLockedProperty, value);
        }

        public static Boolean GetItemsSourceLocked(ItemsControl element)
        {
            return (Boolean)element.GetValue(ItemsSourceLockedProperty);
        }

        public static void SetIsEnumTypeSetedWithEnumType(ItemsControl element, Boolean value)
        {
            element.SetValue(IsEnumTypeSetedWithEnumTypeProperty, value);
        }

        public static Boolean GetIsEnumTypeSetedWithEnumType(ItemsControl element)
        {
            return (Boolean)element.GetValue(IsEnumTypeSetedWithEnumTypeProperty);
        }

    }
}
