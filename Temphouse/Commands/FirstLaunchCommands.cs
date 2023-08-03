using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace Temphouse.Commands
{
    public static class FirstLaunchCommands
    {
        private const int _STEP = 1;

        /// <summary>
        /// Константа имени для RoutedCommand NextTabItemCommand.
        /// </summary>
        private static string _NEXTTABITEMCOMMANDNAME = "NextTabItemTabControl";

        /// <summary>
        /// Константа имени для RoutedCommand BackTabItemCommand.
        /// </summary>
        private static string _BACKTABITEMCOMMANDNAME = "BackTabItemTabControl";

        /// <summary>
        /// Комманда для перехода к следующему TabItem.
        /// </summary>
        public static RoutedCommand NextTabItemCommand { get; private set; }

        /// <summary>
        /// Комманда для перехода к предыдущему TabItem.
        /// </summary>
        public static RoutedCommand BackTabItemCommand { get; private set; }

        static FirstLaunchCommands()
        {
            NextTabItemCommand = new RoutedCommand(_NEXTTABITEMCOMMANDNAME, typeof(FirstLaunchCommands));
            BackTabItemCommand = new RoutedCommand(_BACKTABITEMCOMMANDNAME, typeof(FirstLaunchCommands));
        }

        public static void GoToNextTabItem(TabControl tabControl)
        {
            if (tabControl == null)
            {
                throw new ArgumentNullException(nameof(tabControl));
            }
            if (OnCanGoToNextTabItem(tabControl) == true)
            {
                tabControl.SelectedIndex += _STEP;
            }
        }

        public static bool OnCanGoToNextTabItem(TabControl tabControl)
        {
            if (tabControl.SelectedIndex + _STEP < tabControl.Items.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void GoToBackTabItem(TabControl tabControl)
        {
            if (tabControl == null)
            {
                throw new ArgumentNullException(nameof(tabControl));
            }
            if (OnCanGoToBackTabItem(tabControl) == true)
            {
                tabControl.SelectedIndex -= _STEP;
            }
        }

        public static bool OnCanGoToBackTabItem(TabControl tabControl)
        {
            if (tabControl.SelectedIndex - _STEP > -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
