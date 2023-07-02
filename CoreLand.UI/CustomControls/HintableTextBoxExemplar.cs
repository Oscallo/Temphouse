using CoreLand.UI.Modules.Boxes;
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
        public string Hint
        {
            get { return (string)GetValue(HintProperty); }
            set { SetValue(HintProperty, value); }
        }

        public SolidColorBrush HintForeground
        {
            get { return (SolidColorBrush)GetValue(HintForegroundProperty); }
            set { SetValue(HintForegroundProperty, value); }
        }
    }
}
