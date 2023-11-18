using CoreLand.UI.CustomControls.Windows;
using System.Windows;
using System.Windows.Controls;
using Temphouse.MVVM.ViewModels;

namespace Temphouse.Windows
{
    /// <summary>
    /// Логика взаимодействия для ApplicationInitializeWindow.xaml
    /// </summary>
    public partial class ApplicationInitializeWindow : ExtendedWindow
    {
        public ApplicationInitializeWindow()
        {
            InitializeComponent();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            { 
                ((ApplicationInitializeViewModel)this.DataContext).AdministratorData.Password = ((PasswordBox)sender).SecurePassword;
            }
        }
    }
}
