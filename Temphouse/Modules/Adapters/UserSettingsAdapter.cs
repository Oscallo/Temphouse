using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Temphouse.Enums;
using Temphouse.Extensions;
using Temphouse.Models;

namespace Temphouse.Modules.Adapters
{
    public class UserSettingsAdapter : AbstractAdapter
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

        private StringCollection WindowUserSessions 
        {
            get { return Properties.Settings.Default.SavedUserSessions; }
            init 
            {
                if (value == null) { throw new NullReferenceException(); }
                if (Properties.Settings.Default.SavedUserSessions == value) { return; }
                Properties.Settings.Default.SavedUserSessions = value;
            }
        }

        public UserSettingsAdapter() 
        {
            if (WindowUserSessions == null)
            {
                Properties.Settings.Default.SavedUserSessions = new StringCollection();
            }
        }

        public void AddUserSession(SessionModel session) 
        {
            WindowUserSessions.Add(session.ToStringCollectionElement());
        }

        public void RemoveUserSession(SessionModel session) 
        {
            WindowUserSessions.Remove(session.ToStringCollectionElement());
        }

        public ReadOnlyCollection<SessionModel> Sessions 
        {
            get { return Parse(WindowUserSessions); }
        }

        private ReadOnlyCollection<SessionModel> Parse(StringCollection windowUserSessions)
        {
            IList<SessionModel> sessionModels = new List<SessionModel>();
            foreach (string session in windowUserSessions) 
            {
                sessionModels.Add(SessionModel.ConvertFromString(session));
            }

            return new ReadOnlyCollection<SessionModel>(sessionModels);
        }

        public DatabaseTypeEnum DatabaseConnectionType
        {
            get { return (DatabaseTypeEnum)Properties.Settings.Default["DatabaseConnectionType"]; }
            set
            {
                if (DatabaseConnectionType == value) { return; }
                if (Enum.IsDefined(typeof(DatabaseTypeEnum), value) == false) { throw new ArgumentOutOfRangeException(); }
                OnPropertyChanging(nameof(DatabaseConnectionType));
                Properties.Settings.Default["DatabaseConnectionType"] = (int)value;
                OnPropertyChanged(nameof(DatabaseConnectionType));
            }
        }

        public bool IsFirstLaunch
        {
            get { return (bool)Properties.Settings.Default["IsFirstLaunch"]; }
            set
            {
                if (IsFirstLaunch == value) { return; }
                OnPropertyChanging(nameof(IsFirstLaunch));
                Properties.Settings.Default["IsFirstLaunch"] = value;
                OnPropertyChanged(nameof(IsFirstLaunch));
            }
        }
    }
}
