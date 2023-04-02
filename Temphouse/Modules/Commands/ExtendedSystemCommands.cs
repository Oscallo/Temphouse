using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace Temphouse.Modules.Commands
{
    public static class ExtendedSystemCommands
    {
        public static RoutedCommand CloseWindowCommand => SystemCommands.CloseWindowCommand;
        public static RoutedCommand MaximizeWindowCommand => SystemCommands.MaximizeWindowCommand;
        public static RoutedCommand MinimizeWindowCommand => SystemCommands.MinimizeWindowCommand;
        public static RoutedCommand RestoreWindowCommand => SystemCommands.RestoreWindowCommand;
        public static RoutedCommand ShowSystemMenuCommand => SystemCommands.ShowSystemMenuCommand;

        public static RoutedCommand HideInTreyWindowCommand { get; private set; }

        public static void CloseWindow(Window window) => SystemCommands.CloseWindow(window);

        public static void MaximizeWindow(Window window) => SystemCommands.MaximizeWindow(window);

        public static void MinimizeWindow(Window window) => SystemCommands.MinimizeWindow(window);

        public static void RestoreWindow(Window window) => SystemCommands.RestoreWindow(window);

        public static void ShowSystemMenu(Window window, Point screenLocation) => SystemCommands.ShowSystemMenu(window, screenLocation);
        
        static ExtendedSystemCommands() 
        {
            HideInTreyWindowCommand = new RoutedCommand("HideInTreyWindow", typeof(ExtendedSystemCommands));
        }

        public static void HideInTreyWindow(Window window) 
        {
            if (window == null) 
            {
                throw new ArgumentNullException(nameof(window));    
            }
            throw new NotImplementedException();
        }
    }
}
