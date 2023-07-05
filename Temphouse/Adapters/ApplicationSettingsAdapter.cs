using System;
using System.Collections.ObjectModel;
using Temphouse.Enums;
using Temphouse.Models;

namespace Temphouse.Adapters
{
    public class ApplicationSettingsAdapter
    {
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


    }
}
