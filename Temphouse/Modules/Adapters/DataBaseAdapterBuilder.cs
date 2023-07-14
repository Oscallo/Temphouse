using System;
using Temphouse.Models;
using System.ComponentModel;
using Temphouse.Enums;

namespace Temphouse.Modules.Adapters
{
    /// <summary>
    /// Фасад + Строитель
    /// </summary>
    public class DataBaseAdapterBuilder : AbstractDataBaseAdapter
    {
        #region static Instance

        private static AbstractDataBaseAdapter _Instance;

        /// <summary>
        /// Статический экземпляр объекта.
        /// </summary>
        public static AbstractDataBaseAdapter Instance 
        {
            get { return _Instance; }
            private set 
            {
                if (Instance == value) { return; }
                if (Instance != null) 
                {
                    Instance.Dispose();
                }
                _Instance = value;
            }
        }

        static DataBaseAdapterBuilder()
        {
            ApplicationSettingsAdapter.Instance.PropertyChanged += ApplicationSettingsAdapterInstance_PropertyChanged;
            Instance = _GetDataBaseAdapterByConnectionType(ApplicationSettingsAdapter.Instance.DatabaseConnectionType);
        }

        private static AbstractDataBaseAdapter _GetDataBaseAdapterByConnectionType(DatabaseConnectionTypeEnum databaseConnectionType) 
        {
            if (databaseConnectionType == DatabaseConnectionTypeEnum.Local)
            {
                return new LocalDataBaseAdapter();
            }
            else if (databaseConnectionType == DatabaseConnectionTypeEnum.Network)
            {
                return new NetworkDataBaseAdapter();
            }
            else
            {
                throw new Exception("DatabaseConnectionTypeEnum = 0");
            }
        }

        private static void ApplicationSettingsAdapterInstance_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ApplicationSettingsAdapter.Instance.DatabaseConnectionType))
            {
                Instance = _GetDataBaseAdapterByConnectionType(ApplicationSettingsAdapter.Instance.DatabaseConnectionType);
            }
        }

        #endregion

        public override SessionModel UserAuthorization(string login, string password, out bool isAuthorizationSuccess)
        {
            return Instance.UserAuthorization(login, password, out isAuthorizationSuccess);
        }

        public override void UserAuthorization(SessionModel session, out bool isAuthorizationSuccess)
        {
            Instance.UserAuthorization(session, out isAuthorizationSuccess);
        }

        public override UserModel GetUserBySession(SessionModel session)
        {
            return Instance.GetUserBySession(session);
        }

        public override void CreateDataBase()
        {
            Instance.CreateDataBase();
        }

        public override void CreateConnection()
        {
            Instance.CreateConnection();
        }

        public override void CloseConnection()
        {
            Instance.CloseConnection();
        }

        public override void OnInitialize()
        {
            Instance.OnInitialize();
        }

    }
}
