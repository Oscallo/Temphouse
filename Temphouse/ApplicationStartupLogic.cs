using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temphouse
{
    public static class ApplicationStartupLogic
    {
        public static Uri StartupWindowUri { get => _GetStartupWindow(); }

        private static Uri _GetStartupWindow()
        {
            return new Uri("/Windows/LoginWindow.xaml", UriKind.Relative);
        }
    }
}
