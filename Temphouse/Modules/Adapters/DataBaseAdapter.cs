using System;
using Temphouse.Models;

namespace Temphouse.Modules.Adapters
{
    public class DataBaseAdapter
    {
        #region static Instance

        /// <summary>
        /// Статический экземпляр объекта.
        /// </summary>
        public static DataBaseAdapter Instance { get; private set; }

        static DataBaseAdapter()
        {
            Instance = new DataBaseAdapter();
        }

        #endregion

        public SessionModel UserAuthorization(string login, string password, out bool isAuthorizationSuccess)
        {
            throw new NotImplementedException();
        }

        public void UserAuthorization(SessionModel session, out bool isAuthorizationSuccess)
        {
            throw new NotImplementedException();
        }

        public UserModel GetUserBySession(SessionModel session)
        {
            throw new NotImplementedException();
        }
    }
}
