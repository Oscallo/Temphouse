using CoreLand.UI.Modules.Boxes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CoreLand.UI.CustomControls
{
    public partial class HintablePasswordBox : HintableBoxBase
    {
        public static readonly DependencyProperty PasswordProperty = DependencyProperty.Register(nameof(Password), typeof(SecureString), typeof(HintablePasswordBox), new UIPropertyMetadata(new SecureString()));

        public static readonly DependencyProperty HiddenTextProperty = DependencyProperty.Register(nameof(HiddenText), typeof(string), typeof(HintablePasswordBox), new UIPropertyMetadata(string.Empty));

        public static readonly DependencyProperty PasswordCharProperty = DependencyProperty.Register(nameof(PasswordChar), typeof(char), typeof(HintablePasswordBox), new UIPropertyMetadata('*'));

        public static readonly DependencyProperty IsPasswordMaskedProperty = DependencyProperty.Register(nameof(IsPasswordMasked), typeof(bool), typeof(HintablePasswordBox), new UIPropertyMetadata(true, new PropertyChangedCallback(OnPasswordMaskedChanged)));

        private static void OnPasswordMaskedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            HintablePasswordBox hintablePasswordBox = ((HintablePasswordBox)d);

            if ((bool)e.NewValue == true)
            {
                hintablePasswordBox.MaskAllDisplayText();
            }
            else 
            {
                hintablePasswordBox.UnMaskAllDisplayText();
            }
        }

        static HintablePasswordBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(HintablePasswordBox), new FrameworkPropertyMetadata(typeof(HintablePasswordBox)));
        }
    }
}
