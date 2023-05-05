using System;
using System.Windows;
using System.Drawing;
using System.Windows.Forms;
using Temphouse.Modules.Information;

using ApplicationWPF = System.Windows.Application;
using static System.Net.Mime.MediaTypeNames;

namespace Temphouse.Modules.Trey
{
    /// <summary>
    /// Контроллер окна для вывода в трей
    /// </summary>
    public class TreyController : IDisposable
    {
        #region static Instance

        /// <summary>
        /// Статический экземпляр объекта.
        /// </summary>
        public static TreyController Instance { get; private set; }

        static TreyController()
        {
            Instance = new TreyController();
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

        #endregion

        /// <summary>
        /// Иконка окна трей-панели.
        /// </summary>
        private NotifyIcon _NotifyIcon = new NotifyIcon();

        /// <summary>
        /// Свернутое окно.
        /// </summary>
        private Window? _HidedWindow;

        public TreyController(string text, Icon icon)
        {
            _InitializeEvents();
            _SetIcon(icon);
            _SetText(text);
        }

        public TreyController() : this(InformationReporter.ApplicationName + Environment.NewLine + "v." + InformationReporter.ApplicationVersion, InformationReporter.ApplicationIcon)
        {

        }

        /// <summary>
        /// Инициализация событий
        /// </summary>
        private void _InitializeEvents()
        {
            _NotifyIcon.MouseClick += _NotifyIcon_MouseClick;
            ApplicationWPF.Current.Exit += App_Exit;
        }

        /// <summary>
        /// <seealso cref="Delegate">Делегат</seealso> события <seealso cref="NotifyIcon.MouseClick">нажатия на иконку</seealso>.
        /// </summary>
        /// <param name="sender">Вызывающий объект</param>
        /// <param name="e">Аргументы</param>
        private void _NotifyIcon_MouseClick(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _MouseLeftButtonClick();
            }
            else if (e.Button == MouseButtons.Right) 
            {
                _MouseRightButtonClick();
            }
        }

        /// <summary>
        /// При нажатии левой кнопки мыши
        /// </summary>
        private void _MouseLeftButtonClick()
        {
            ShowWindow();
        }

        /// <summary>
        /// При нажатии правой кнопки мыши
        /// </summary>
        private void _MouseRightButtonClick()
        {
            /// Возможна отрисовка меню выбора.
        }

        /// <summary>
        /// Деинициализация событий
        /// </summary>
        private void _UninitializeEvents()
        {
            _NotifyIcon.MouseClick -= _NotifyIcon_MouseClick;
            ApplicationWPF.Current.Exit -= App_Exit;
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
            _SetWindow(window);
            HideWindow();
        }

        /// <summary>
        /// Скрыть окно в трее и отобразить иконку окна трей-панели.
        /// </summary>
        public void HideWindow()
        {
            if (_HidedWindow == null) { throw new NullReferenceException(); }
            _NotifyIcon.Visible = true;
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
            _UninitializeEvents();
        }

    }
}
