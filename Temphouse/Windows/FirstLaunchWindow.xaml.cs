using CoreLand.UI.CustomControls.Windows;
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
using Temphouse.Modules.Commands;

namespace Temphouse.Windows
{
    /// <summary>
    /// Логика взаимодействия для FirstLaunchWindow.xaml
    /// </summary>
    public partial class FirstLaunchWindow : ExtendedWindow
    {
        public FirstLaunchWindow()
        {
            InitializeComponent();

            this.CommandBindings.Add(new CommandBinding(FirstLaunchCommands.NextTabItemCommand, OnNextTabItem, OnCanGoToNextTabItem));
            this.CommandBindings.Add(new CommandBinding(FirstLaunchCommands.BackTabItemCommand, OnBackTabItem, OnCanGoToBackTabItem));
        }

        private void OnCanGoToBackTabItem(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = FirstLaunchCommands.OnCanGoToBackTabItem(PART_TabControl);
        }

        private void OnCanGoToNextTabItem(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = FirstLaunchCommands.OnCanGoToNextTabItem(PART_TabControl);
        }

        private void OnBackTabItem(object sender, ExecutedRoutedEventArgs e)
        {
            FirstLaunchCommands.GoToBackTabItem(PART_TabControl);
        }

        private void OnNextTabItem(object sender, ExecutedRoutedEventArgs e)
        {
            FirstLaunchCommands.GoToNextTabItem(PART_TabControl);
        }
    }
}
