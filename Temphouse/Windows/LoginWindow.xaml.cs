using CoreLand.UI.CustomControls;
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
using Temphouse.Adapters;

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

            string sessionKey = DataBaseAdapter.UserAuthorization(PART_LoginTextBox.Text, PART_PasswordTextBox.Text, out isAuthorizationSuccess);

            if (isAuthorizationSuccess == true) 
            {
                new DashboardWindow(sessionKey).Show();
                this.Close();
            }
        }
    }
}
