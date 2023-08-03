using CoreLand.UI.Trey;
using System;
using System.Windows;
using System.Windows.Input;

namespace CoreLand.UI.Commands
{
    /// <summary>
    /// Фасад от <seealso cref="SystemCommands"/>.
    /// <br/> 
    /// Объединение всех команд, используемых в <seealso cref="Themes.ExtendedWindowControl.ExtendedWindow"/>
    /// и в шаблоне <seealso cref="Window"/>.
    /// </summary>
    public static class ExtendedSystemCommands
    {
        /// <summary>
        /// Константа имени для <seealso cref="RoutedCommand"/> <seealso cref="HideInTreyWindowCommand"/>.
        /// </summary>
        private static string _HIDEINTREYWINDOWCOMMANDNAME = "HideInTreyWindow";

        /// <summary>
        /// Комманда на закрытие окна.
        /// </summary>
        public static RoutedCommand CloseWindowCommand => SystemCommands.CloseWindowCommand;

        /// <summary>
        /// Комманда на разворачивание окна в полноэкранный режим.
        /// </summary>
        public static RoutedCommand MaximizeWindowCommand => SystemCommands.MaximizeWindowCommand;

        /// <summary>
        /// Комманда на сворачивание окна.
        /// </summary>
        public static RoutedCommand MinimizeWindowCommand => SystemCommands.MinimizeWindowCommand;

        /// <summary>
        /// Комманда на восстановление окна.
        /// </summary>
        public static RoutedCommand RestoreWindowCommand => SystemCommands.RestoreWindowCommand;

        /// <summary>
        /// Комманда на показ системного меню
        /// </summary>
        public static RoutedCommand ShowSystemMenuCommand => SystemCommands.ShowSystemMenuCommand;

        /// <summary>
        /// Комманда на сворачивание окна трей с помощью <seealso cref="TreyController"/>.
        /// </summary>
        public static RoutedCommand HideInTreyWindowCommand { get; private set; }

        /// <summary>
        /// Закрыть окно
        /// </summary>
        /// <param name="window">Окно</param>
        public static void CloseWindow(Window window) => SystemCommands.CloseWindow(window);

        /// <summary>
        /// Развернуть в полноэкранный режим окно
        /// </summary>
        /// <param name="window">Окно</param>
        public static void MaximizeWindow(Window window) => SystemCommands.MaximizeWindow(window);

        /// <summary>
        /// Свернуть окно
        /// </summary>
        /// <param name="window">Окно</param>
        public static void MinimizeWindow(Window window) => SystemCommands.MinimizeWindow(window);

        /// <summary>
        /// Восстановить окно
        /// </summary>
        /// <param name="window">Окно</param>
        public static void RestoreWindow(Window window) => SystemCommands.RestoreWindow(window);

        /// <summary>
        /// Показать системное меню
        /// </summary>
        /// <param name="window">Окно</param>
        /// <param name="screenLocation">Место для отображения системного меню в координатах логического экрана.</param>
        public static void ShowSystemMenu(Window window, Point screenLocation) => SystemCommands.ShowSystemMenu(window, screenLocation);

        static ExtendedSystemCommands()
        {
            HideInTreyWindowCommand = new RoutedCommand(_HIDEINTREYWINDOWCOMMANDNAME, typeof(ExtendedSystemCommands));
        }

        /// <summary>
        /// Сокрытие окна в трей.
        /// </summary>
        /// <param name="window">Окно</param>
        /// <exception cref="ArgumentNullException">Значение окна = <seealso cref="Nullable"/></exception>
        public static void HideInTreyWindow(Window window)
        {
            if (window == null)
            {
                throw new ArgumentNullException(nameof(window));
            }
#pragma warning disable CS8602 // Разыменование вероятной пустой ссылки.
            TreyController.Instance.HideWindow(window);
#pragma warning restore CS8602 // Разыменование вероятной пустой ссылки.
        }
    }
}
