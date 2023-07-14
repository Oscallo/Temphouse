﻿using System;
using Temphouse.Models;

namespace Temphouse.Modules.Adapters
{
    public class LocalDataBaseAdapter : AbstractDataBaseAdapter
    {
        public override SessionModel UserAuthorization(string login, string password, out bool isAuthorizationSuccess)
        {
            throw new NotImplementedException();
        }

        public override void UserAuthorization(SessionModel session, out bool isAuthorizationSuccess)
        {
            throw new NotImplementedException();
        }

        public override UserModel GetUserBySession(SessionModel session)
        {
            throw new NotImplementedException();
        }

        public override void CreateDataBase()
        {
            throw new NotImplementedException();
        }

        public override void CreateConnection()
        {
            base.CreateConnection();
        }

        public override void CloseConnection()
        {
            base.CloseConnection();
        }

        public override void OnInitialize()
        {

        }
    }
}
