using CoreLand.UI.CustomControls.Windows;
using System.Windows;
using Temphouse.DataAccess.Adapters;
using Temphouse.MVVM.Models;

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

            //SessionModel sessionKey = DataBaseAdapterBuilder.Instance.UserAuthorization(PART_LoginTextBox.Text, PART_PasswordTextBox.Text, out isAuthorizationSuccess);

            if (isAuthorizationSuccess == true) 
            {
                //new DashboardWindow(sessionKey).Show();
                this.Close();
            }
        }
    }
}
