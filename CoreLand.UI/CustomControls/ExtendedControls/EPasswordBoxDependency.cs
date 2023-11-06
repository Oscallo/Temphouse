using System.Security;
using System.Windows;
using System.Windows.Controls;

namespace CoreLand.UI.CustomControls.ExtendedControls
{
    public partial class EPasswordBox : TextBox
    {
        public static readonly DependencyProperty PasswordProperty = DependencyProperty.Register(nameof(Password), typeof(SecureString), typeof(EPasswordBox), new UIPropertyMetadata(new SecureString()));

        public static readonly DependencyProperty HiddenTextProperty = DependencyProperty.Register(nameof(HiddenText), typeof(string), typeof(EPasswordBox), new UIPropertyMetadata(string.Empty));

        public static readonly DependencyProperty PasswordCharProperty = DependencyProperty.Register(nameof(PasswordChar), typeof(char), typeof(EPasswordBox), new UIPropertyMetadata('*'));

        public static readonly DependencyProperty IsPasswordMaskedProperty = DependencyProperty.Register(nameof(IsPasswordMasked), typeof(bool), typeof(EPasswordBox), new UIPropertyMetadata(true, new PropertyChangedCallback(OnPasswordMaskedChanged)));

        private static void OnPasswordMaskedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            EPasswordBox ePasswordBox = ((EPasswordBox)d);

            if ((bool)e.NewValue == true)
            {
                ePasswordBox.MaskAllDisplayText();
            }
            else 
            {
                ePasswordBox.UnMaskAllDisplayText();
            }
        }

        static EPasswordBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(EPasswordBox), new FrameworkPropertyMetadata(typeof(EPasswordBox)));
        }
    }
}
