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
    public partial class UsersWithSavedSessionsView : UserControl
    {
        public UsersWithSavedSessionsView()
        {
            InitializeComponent();

            _FindParent();
        }

        private void _FindParent()
        {
            Loaded += (s, e) =>
            {
                ((UsersViewModel)this.DataContext).LoginWindow = DesignerReporter.Instance.GetParentExtendedWindow<ExtendedWindow>(this);
            };
        }
    }
}
