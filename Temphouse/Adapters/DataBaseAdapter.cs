﻿using System;
using Temphouse.Models;

namespace Temphouse.Adapters
{
    public class DataBaseAdapter
    {
        public static SessionModel UserAuthorization(string login, string password, out bool isAuthorizationSuccess)
        {
            throw new NotImplementedException();
        }

        public static UserModel GetUserBySession(SessionModel session)
        {
            throw new NotImplementedException();
        }
    }
}
