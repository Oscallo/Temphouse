using System;
using System.Collections.ObjectModel;
using Temphouse.Enums;
using Temphouse.Models;

namespace Temphouse.Modules.Adapters
{
    public class ApplicationSettingsAdapter : AbstractAdapter
    {
        #region static Instance

        /// <summary>
        /// Статический экземпляр объекта.
        /// </summary>
        public static ApplicationSettingsAdapter Instance { get; private set; }

        static ApplicationSettingsAdapter()
        {
            Instance = new ApplicationSettingsAdapter();
        }

        #endregion


    }
}
