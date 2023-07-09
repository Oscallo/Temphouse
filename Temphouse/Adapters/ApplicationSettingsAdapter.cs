using CoreLand.UI.Modules.Trey;
using System;
using System.Collections.ObjectModel;
using Temphouse.Enums;
using Temphouse.Models;

namespace Temphouse.Adapters
{
    public class ApplicationSettingsAdapter
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

        public ObservableCollection<SessionModel> Sessions => _GetSessions();

        public DatabaseConnectionTypeEnum DatabaseConnectionType => _GetDatabaseConnectionType();

        private DatabaseConnectionTypeEnum _GetDatabaseConnectionType()
        {
            throw new NotImplementedException();
        }

        private ObservableCollection<SessionModel> _GetSessions()
        {
            throw new NotImplementedException();
        }

        public void RemoveSession(SessionModel session)
        {
            throw new NotImplementedException();
        }
    }
}
