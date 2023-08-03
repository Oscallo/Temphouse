using CoreLand.UI.CustomControls.Windows;
using Temphouse.MVVM.Models;

namespace Temphouse.Windows
{
    /// <summary>
    /// Логика взаимодействия для DashboardWindow.xaml
    /// </summary>
    public partial class DashboardWindow : ExtendedWindow
    {
        public DashboardWindow(SessionModel sessionKey) : base()
        {
            
        }

        public DashboardWindow()
        {
            InitializeComponent();
        }
    }
}
