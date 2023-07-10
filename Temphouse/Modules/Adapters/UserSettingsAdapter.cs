using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Temphouse.Models;

namespace Temphouse.Modules.Adapters
{
    public class UserSettingsAdapter
    {
        #region static Instance

        /// <summary>
        /// Статический экземпляр объекта.
        /// </summary>
        public static UserSettingsAdapter Instance { get; private set; }

        static UserSettingsAdapter()
        {
            Instance = new UserSettingsAdapter();
        }

        #endregion
    }
}
