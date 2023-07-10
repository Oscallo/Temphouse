using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                throw new NotImplementedException();
            }
            else 
            {
                return new Uri("/Windows/LoginWindow.xaml", UriKind.Relative);
            }
        }
    }
}
