﻿using CoreLand.UI.Modules.Trey;
using System;
using System.Collections.ObjectModel;
using Temphouse.Enums;
using Temphouse.Models;

namespace Temphouse.Adapters
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

        public ObservableCollection<SessionModel> Sessions => _GetSessions();

        public DatabaseConnectionTypeEnum DatabaseConnectionType 
        {
            get { return (DatabaseConnectionTypeEnum)Properties.Settings.Default["DatabaseConnectionType"]; }
            set 
            {
                if (DatabaseConnectionType == value) { return; }
                if (Enum.IsDefined(typeof(DatabaseConnectionTypeEnum), value) == false) { throw new ArgumentOutOfRangeException(); }
                OnPropertyChanging(nameof(DatabaseConnectionType));
                Properties.Settings.Default["DatabaseConnectionType"] = value;
                OnPropertyChanged(nameof(DatabaseConnectionType));
            }
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
