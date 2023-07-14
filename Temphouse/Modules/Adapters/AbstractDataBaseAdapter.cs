using System;
using Temphouse.Enums;
using Temphouse.Models;

namespace Temphouse.Modules.Adapters
{
    public abstract class AbstractDataBaseAdapter : AbstractAdapter, IDisposable
    {
        public DatabaseConnectionStatusEnum DatabaseConnectionStatus { get; set; } = DatabaseConnectionStatusEnum.Closed;

        public AbstractDataBaseAdapter()
        {
            OnInitialize();
        }

        public virtual void Dispose()
        {
            this.CloseConnection();
        }

        public abstract SessionModel UserAuthorization(string login, string password, out bool isAuthorizationSuccess);

        public abstract void UserAuthorization(SessionModel session, out bool isAuthorizationSuccess);

        public abstract UserModel GetUserBySession(SessionModel session);

        public abstract void CreateDataBase();

        public abstract void OnInitialize();

        public virtual void CreateConnection() 
        {
            if (DatabaseConnectionStatus == DatabaseConnectionStatusEnum.Opened) { return; }
            if (DatabaseConnectionStatus == DatabaseConnectionStatusEnum.Opening) { return; }
        }

        public virtual void CloseConnection() 
        {
            if (DatabaseConnectionStatus == DatabaseConnectionStatusEnum.Closed) { return; }
            if (DatabaseConnectionStatus == DatabaseConnectionStatusEnum.Closing) { return; }
        }
    }
}
