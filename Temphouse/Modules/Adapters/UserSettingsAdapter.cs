using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Temphouse.Enums;
using Temphouse.Extensions;
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
    }
}
