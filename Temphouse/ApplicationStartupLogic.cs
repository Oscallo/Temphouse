using System;
using Temphouse.Modules.Adapters;

namespace Temphouse
{
    public static class ApplicationStartupLogic
        {
        public static Uri StartupWindowUri { get => _GetStartupWindow(); }

        private static Uri _GetStartupWindow()
        {
            if (ApplicationSettingsAdapter.Instance.IsFirstLaunch == true)
            {
                return new Uri("/Windows/FirstLaunchWindow.xaml", UriKind.Relative);
            }
            else 
            {
                return new Uri("/Windows/LoginWindow.xaml", UriKind.Relative);
            }
        }
    }
}
