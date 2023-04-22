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
using Temphouse.Modules.Information;
using Temphouse.Windows;

namespace Temphouse.Themes.ExtendedWindowControl
{
    /// <summary>
    /// Расширенный класс окна, наследуемый от <seealso cref="Window"/>
    /// </summary>
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

        /// <summary>
        /// <seealso cref="Delegate">Делегат</seealso> на проверку возможности свернуть в трей.
        /// </summary>
        /// <param name="sender">Вызывающий объект</param>
        /// <param name="e">Аргументы</param>
        private void OnCanHideInTreyWindow(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = InformationReporter.ApplicationIcon != null;
        }

        /// <summary>
        /// <seealso cref="Delegate">Делегат</seealso> на сокрытие окна в трее.
        /// </summary>
        /// <param name="sender">Вызывающий объект</param>
        /// <param name="e">Аргументы</param>
        private void OnHideInTreyWindow(object sender, ExecutedRoutedEventArgs e)
        {
            ExtendedSystemCommands.HideInTreyWindow(this);
        }

        /// <summary>
        /// <seealso cref="Delegate">Делегат</seealso> на проверку возможности свернуть окно.
        /// </summary>
        /// <param name="sender">Вызывающий объект</param>
        /// <param name="e">Аргументы</param>
        private void OnCanMinimizeWindow(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = this.ResizeMode != ResizeMode.NoResize;
        }

        /// <summary>
        /// <seealso cref="Delegate">Делегат</seealso> на проверку возможности изменить размер окна.
        /// </summary>
        /// <param name="sender">Вызывающий объект</param>
        /// <param name="e">Аргументы</param>
        private void OnCanResizeWindow(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = this.ResizeMode == ResizeMode.CanResize || this.ResizeMode == ResizeMode.CanResizeWithGrip;
        }

        /// <summary>
        /// <seealso cref="Delegate">Делегат</seealso> на закрытие окна.
        /// </summary>
        /// <param name="sender">Вызывающий объект</param>
        /// <param name="e">Аргументы</param>
        private void OnCloseWindow(object sender, ExecutedRoutedEventArgs e)
        {
            ExtendedSystemCommands.CloseWindow(this);
        }

        /// <summary>
        /// <seealso cref="Delegate">Делегат</seealso> на разворачивание окна в полноэкранный режим.
        /// </summary>
        /// <param name="sender">Вызывающий объект</param>
        /// <param name="e">Аргументы</param>
        private void OnMaximizeWindow(object sender, ExecutedRoutedEventArgs e)
        {
            ExtendedSystemCommands.MaximizeWindow(this);
        }

        /// <summary>
        /// <seealso cref="Delegate">Делегат</seealso> на сокрытие окна.
        /// </summary>
        /// <param name="sender">Вызывающий объект</param>
        /// <param name="e">Аргументы</param>
        private void OnMinimizeWindow(object sender, ExecutedRoutedEventArgs e)
        {
            ExtendedSystemCommands.MinimizeWindow(this);
        }

        /// <summary>
        /// <seealso cref="Delegate">Делегат</seealso> на восстановление окна.
        /// </summary>
        /// <param name="sender">Вызывающий объект</param>
        /// <param name="e">Аргументы</param>
        private void OnRestoreWindow(object sender, ExecutedRoutedEventArgs e)
        {
            ExtendedSystemCommands.RestoreWindow(this);
        }

        /// <summary>
        /// Проверка на DesignMode.
        /// </summary>
        /// <returns>Возвращает true, если объект <seealso cref="Window"/> находится в режиме разработки</returns>
        public bool IsInDesignMode
        {
            get
            {
                return DesignerProperties.GetIsInDesignMode(this);
            }
        }
    }
}
