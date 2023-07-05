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
using System.Windows.Shapes;
using CoreLand.UI.CustomControls;

namespace Temphouse.Windows
{
    /// <summary>
    /// Логика взаимодействия для DashboardWindow.xaml
    /// </summary>
    public partial class DashboardWindow : ExtendedWindow
    {
        public DashboardWindow(string sessionKey)
        {
            InitializeComponent();
        }

        public DashboardWindow()
        {
            InitializeComponent();
        }
    }
}
