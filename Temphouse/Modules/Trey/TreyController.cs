using System;
using System.Windows;
using System.Drawing;
using System.Windows.Forms;
using Temphouse.Modules.Information;

using ApplicationWPF = System.Windows.Application;

namespace Temphouse.Modules.Trey
{
    public class TreyController : IDisposable
    {
        public static TreyController Instance { get; private set; }

        private NotifyIcon _NotifyIcon = new NotifyIcon();

        private Window? _HidedWindow;

        public TreyController()
        {
            _NotifyIcon.Icon = InformationReporter.ApplicationIcon;
            _NotifyIcon.Text = InformationReporter.ApplicationName + Environment.NewLine + "v." + InformationReporter.ApplicationVersion;

            _NotifyIcon.Click += _NotifyIcon_Click;
            ApplicationWPF.Current.Exit += App_Exit;
        }

        private void App_Exit(object sender, ExitEventArgs e)
        {
            DisposeInstance();
        }

        static TreyController()
        {
            Instance = new TreyController();
        }

        public void HideWindow(Window window)
        {
            _NotifyIcon.Visible = true;
            _HidedWindow = window;
            _HidedWindow.Hide();
        }

        public void ShowWindow()
        {
            if (_HidedWindow != null)
            {
                _HidedWindow.Show();
                _HideIcon();
            }
        }

        private void _SetWindow(Window window) 
        {
            _HidedWindow = window;
        }
      
        private void _NotifyIcon_Click(object? sender, EventArgs e)
        {
            ShowWindow();
        }

        private void _SetIcon(Icon icon)
        {
            _NotifyIcon.Icon = icon;
        }

        private void _SetText(string text)
        {
            _NotifyIcon.Text = text;
        }

        private void _HideIcon()
        {
            _NotifyIcon.Visible = false;
        }

        public void Dispose()
        {
            _HideIcon();
        }

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
