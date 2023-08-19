using System;
using Temphouse.DataAccess.Adapters.Subject;

namespace Temphouse
{
    public static class ApplicationStartupLogic
    {
        public static Uri StartupWindowUri { get => _GetStartupWindow(); }

        private static Uri _GetStartupWindow()
        {
            if (UserSettingsAdapter.Instance.IsFirstLaunch == true)
            {
                return new Uri("/Windows/ApplicationInitializeWindow.xaml", UriKind.Relative);
            }
            else 
            {
                return new Uri("/Windows/LoginWindow.xaml", UriKind.Relative);
            }
        }
    }
}
