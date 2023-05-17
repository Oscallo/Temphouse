using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using CoreLand.UI.Modules;

/// https://www.codeproject.com/Articles/499241/Growl-Alike-WPF-Notifications

namespace Temphouse.Modules.Notifications
{
    /// <summary>
    /// Уведомления
    /// </summary>
    public class GrowlNotifiactions : IDisposable
    {
        public const byte MAX_NOTIFICATIONS = 4;

        public static GrowlNotifiactions Instance { get; private set; }

        static GrowlNotifiactions()
        {
            Instance = new GrowlNotifiactions();
        }

        public GrowlNotifiactions() 
        {
        
        }

        public void Dispose()
        {
            throw new NotImplementedException();
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
