using System;
using System.Collections.Generic;
using System.Linq;
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
    public partial class HintableTextBox : TextBox
    {
        /// <summary>
        /// <seealso cref="DependencyProperty"/> задающее ширину и высоту кнопки.
        /// </summary>
        public static readonly DependencyProperty HintProperty = DependencyProperty.Register(nameof(Hint), typeof(string), typeof(HintableTextBox),
                                                                 new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.AffectsMeasure));

        static HintableTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(HintableTextBox), new FrameworkPropertyMetadata(typeof(HintableTextBox)));
        }
    }
}
