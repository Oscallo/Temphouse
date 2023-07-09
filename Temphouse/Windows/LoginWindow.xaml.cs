using CoreLand.UI.CustomControls;
using System.Windows;
using Temphouse.Adapters;
using Temphouse.Models;

namespace Temphouse.Windows
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : ExtendedWindow
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void AuthorizationButton_Click(object sender, RoutedEventArgs e)
        {
            bool isAuthorizationSuccess = false;

            SessionModel sessionKey = DataBaseAdapter.Instance.UserAuthorization(PART_LoginTextBox.Text, PART_PasswordTextBox.Text, out isAuthorizationSuccess);

            if (isAuthorizationSuccess == true) 
            {
                new DashboardWindow(sessionKey).Show();
                this.Close();
            }
        }
    }
}
