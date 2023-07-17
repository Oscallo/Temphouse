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
                if (Properties.Settings.Default.SavedUserSessions == null)
                {
                    Properties.Settings.Default.SavedUserSessions = new StringCollection();
                }
                else if (Properties.Settings.Default.SavedUserSessions == value) { return; }
                else 
                {
                    Properties.Settings.Default.SavedUserSessions = value;
                }
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
            get { throw new NotImplementedException(); }
        }
    }
}
