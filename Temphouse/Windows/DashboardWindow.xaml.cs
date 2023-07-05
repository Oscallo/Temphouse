using CoreLand.UI.CustomControls;
using Temphouse.Models;

namespace Temphouse.Windows
{
    /// <summary>
    /// Логика взаимодействия для DashboardWindow.xaml
    /// </summary>
    public partial class DashboardWindow : ExtendedWindow
    {
        public DashboardWindow(SessionModel sessionKey)
        {
            InitializeComponent();
        }

        public DashboardWindow()
        {
            InitializeComponent();
        }
    }
}
