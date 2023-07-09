using CoreLand.UI.CustomControls;
using CoreLand.UI.Modules.Designer;
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
using Temphouse.ViewModels;

namespace Temphouse.UserControls
{
    /// <summary>
    /// Логика взаимодействия для UsersWithSavedSessionsView.xaml
    /// </summary>
    public partial class UsersWithSavedSessionsView : UserControl, IDisposable
    {
        public UsersWithSavedSessionsView()
        {
            InitializeComponent();
            _InitializeEvents();
        }

        private void _InitializeEvents() 
        {
            Loaded += View_Loaded;
        }

        private void _UnInitializeEvents()
        {
            Loaded -= View_Loaded;
        }

        private void View_Loaded(object sender, RoutedEventArgs e)
        {
            ((UsersViewModel)this.DataContext).LoginWindow = DesignerReporter.Instance.GetParentExtendedWindow<ExtendedWindow>(this);
        }

        #region IDisposable

        public void Dispose()
        {
            _UnInitializeEvents();
        }

        #endregion
    }
}

