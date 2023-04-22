using System;
using System.Windows;
using System.Drawing;
using System.Windows.Forms;
using Temphouse.Modules.Information;

using ApplicationWPF = System.Windows.Application;

namespace Temphouse.Modules.Trey
{
    /// <summary>
    /// Контроллер окна для вывода в трей
    /// </summary>
    public class TreyController : IDisposable
    {
        /// <summary>
        /// Статический экземпляр объекта.
        /// </summary>
        public static TreyController Instance { get; private set; }

        /// <summary>
        /// Иконка окна трей-панели.
        /// </summary>
        private NotifyIcon _NotifyIcon = new NotifyIcon();

        /// <summary>
        /// Свернутое окно.
        /// </summary>
        private Window? _HidedWindow;

        public TreyController()
        {
            _SetIcon(InformationReporter.ApplicationIcon);
            _SetText(InformationReporter.ApplicationName + Environment.NewLine + "v." + InformationReporter.ApplicationVersion);

            _InitializeEvents();
        }

        static TreyController()
        {
            Instance = new TreyController();
        }

        /// <summary>
        /// Инициализация событий
        /// </summary>
        private void _InitializeEvents()
        {
            _NotifyIcon.Click += _NotifyIcon_Click;
            ApplicationWPF.Current.Exit += App_Exit;
        }

        /// <summary>
        /// <seealso cref="Delegate">Делегат</seealso> события <seealso cref="ApplicationWPF.Exit">закрытия ПО</seealso>.
        /// </summary>
        /// <param name="sender">Вызывающий объект</param>
        /// <param name="e">Аргументы</param>
        private void App_Exit(object sender, ExitEventArgs e)
        {
            DisposeInstance();
        }

        /// <summary>
        /// Скрыть окно в трее и отобразить иконку окна трей-панели.
        /// </summary>
        /// <param name="window">Скрываемое окно.</param>
        public void HideWindow(Window window)
        {
            _NotifyIcon.Visible = true;
            _HidedWindow = window;
            _HidedWindow.Hide();
        }

        /// <summary>
        /// Отобразить окно и скрыть иконку окна трей-панели.
        /// </summary>
        public void ShowWindow()
        {
            if (_HidedWindow != null)
            {
                _HidedWindow.Show();
                _HideIcon();
            }
        }

        /// <summary>
        /// Установить новое окно.
        /// </summary>
        /// <param name="window">Новое окно для сокрытия</param>
        private void _SetWindow(Window window) 
        {
            if (_HidedWindow != null)
            {
                ShowWindow();
            }
            _HidedWindow = window;
        }

        /// <summary>
        /// <seealso cref="Delegate">Делегат</seealso> события <seealso cref="NotifyIcon.Click">нажатия на иконку</seealso>.
        /// </summary>
        /// <param name="sender">Вызывающий объект</param>
        /// <param name="e">Аргументы</param>
        private void _NotifyIcon_Click(object? sender, EventArgs e)
        {
            ShowWindow();
        }

        /// <summary>
        /// Установка иконки.
        /// </summary>
        /// <param name="icon">Иконка</param>
        private void _SetIcon(Icon icon)
        {
            _NotifyIcon.Icon = icon;
        }

        /// <summary>
        /// Установка текстовой подсказки.
        /// </summary>
        /// <param name="text">Текстовая подсказка</param>
        private void _SetText(string text)
        {
            _NotifyIcon.Text = text;
        }

        /// <summary>
        /// Скрыть иконку трей-панели.
        /// </summary>
        private void _HideIcon()
        {
            _NotifyIcon.Visible = false;
        }

        public void Dispose()
        {
            _HideIcon();
        }

        /// <summary>
        /// Вызов <seealso cref="Dispose"/> для <seealso cref="Instance"/>.
        /// </summary>
        public static void DisposeInstance()
        {
            if (Instance != null)
            {
                Instance.Dispose();
                Instance = null;
            }
        }
    }
}
