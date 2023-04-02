using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Permissions;
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
using Temphouse.Modules.Commands;
using Temphouse.Windows;

namespace Temphouse.Themes.ExtendedWindowControl
{
    
    public partial class ExtendedWindow : Window
    {
        public ExtendedWindow() : base()
        {
            this.CommandBindings.Add(new CommandBinding(ExtendedSystemCommands.CloseWindowCommand, OnCloseWindow));
            this.CommandBindings.Add(new CommandBinding(ExtendedSystemCommands.MaximizeWindowCommand, OnMaximizeWindow, OnCanResizeWindow));
            this.CommandBindings.Add(new CommandBinding(ExtendedSystemCommands.MinimizeWindowCommand, OnMinimizeWindow, OnCanMinimizeWindow));
            this.CommandBindings.Add(new CommandBinding(ExtendedSystemCommands.RestoreWindowCommand, OnRestoreWindow, OnCanResizeWindow));
            this.CommandBindings.Add(new CommandBinding(ExtendedSystemCommands.HideInTreyWindowCommand, OnHideInTreyWindow, OnCanHideInTreyWindow));
        }

        private void OnCanHideInTreyWindow(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = this.Icon != null;
        }

        private void OnHideInTreyWindow(object sender, ExecutedRoutedEventArgs e)
        {
            ExtendedSystemCommands.HideInTreyWindow(this);
        }

        private void OnCanMinimizeWindow(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = this.ResizeMode != ResizeMode.NoResize;
        }

        private void OnCanResizeWindow(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = this.ResizeMode == ResizeMode.CanResize || this.ResizeMode == ResizeMode.CanResizeWithGrip;
        }

        private void OnCloseWindow(object sender, ExecutedRoutedEventArgs e)
        {
            ExtendedSystemCommands.CloseWindow(this);
        }

        private void OnMaximizeWindow(object sender, ExecutedRoutedEventArgs e)
        {
            ExtendedSystemCommands.MaximizeWindow(this);
        }

        private void OnMinimizeWindow(object sender, ExecutedRoutedEventArgs e)
        {
            ExtendedSystemCommands.MinimizeWindow(this);
        }

        private void OnRestoreWindow(object sender, ExecutedRoutedEventArgs e)
        {
            ExtendedSystemCommands.RestoreWindow(this);
        }

        /// <summary>
        /// Возвращает true, если объект Window находится в режиме разработки, или false, если в режиме выполнения.
        /// </summary>
        /// <returns>Boolean</returns>
        public bool IsInDesignMode
        {
            get
            {
                return DesignerProperties.GetIsInDesignMode(this);
            }
        }
    }
}
