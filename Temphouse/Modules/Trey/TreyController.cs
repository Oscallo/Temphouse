﻿using System;
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

        public TreyController(string text, Icon icon)
        {
            _InitializeEvents();
            _SetIcon(icon);
            _SetText(text);
        }

        public TreyController() : this(InformationReporter.ApplicationName + Environment.NewLine + "v." + InformationReporter.ApplicationVersion, InformationReporter.ApplicationIcon)
        {

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
        /// Деинициализация событий
        /// </summary>
        private void _UninitializeEvents()
        {
            _NotifyIcon.Click -= _NotifyIcon_Click;
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
            _UninitializeEvents();
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
