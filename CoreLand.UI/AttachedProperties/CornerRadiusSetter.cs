using CoreLand.UI.Extensions.Standart.StructExtensions;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace CoreLand.UI.AttachedProperties
{
    /// <summary>
    /// Спасибо <seealso cref="https://stackoverflow.com/users/1548895/vadim-ovchinnikov">Vadim Ovchinnikov</seealso> за идею.
    /// </summary>

    public class CornerRadiusSetter
    {
        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.RegisterAttached(nameof(Border.CornerRadius), typeof(CornerRadius), typeof(CornerRadiusSetter),
                                                                 new UIPropertyMetadata(new CornerRadius(), CornerRadiusChangedCallback), new ValidateValueCallback(OnBorderValidation));
        public static CornerRadius GetCornerRadius(DependencyObject obj) => (CornerRadius)obj.GetValue(CornerRadiusProperty);

        public static void SetCornerRadius(DependencyObject obj, CornerRadius value) => obj.SetValue(CornerRadiusProperty, value);

        private static bool OnBorderValidation(object value)
        {
            return ((CornerRadius)value).IsValid(false, false, false, false);
        }

        public static void CornerRadiusChangedCallback(object sender, DependencyPropertyChangedEventArgs e)
        {
            Control? control = sender as Control;

            if (control == null) { return; }

            control.Loaded += _Control_Loaded;
        }

        private static void _Control_Loaded(object sender, EventArgs e)
        {
            Control? control = sender as Control;

            if (control == null || control.Template == null) { return; }

            control.ApplyTemplate();

            Border border = FindBorder(control);

            border.CornerRadius = GetCornerRadius(control);
        }

        public static Border FindBorder(Control control) 
        {
            List<string> names = new List<string>()
            {
                "border",
                "PART_Border",
                "PART_border",
                "Border"
            };

            Border? border = null;

            foreach (string name in names) 
            {
                border = FindBorder(control, name);
                if (border != null) { return border; }
            }

            throw new NotSupportedException("Border not found in this control");
        }

        public static Border? FindBorder(Control control, string name) 
        {
            return control.Template.FindName(name, control) as Border; ;
        }
    }
}
