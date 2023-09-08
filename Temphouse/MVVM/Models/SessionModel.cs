using CoreLand.UI.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Temphouse.Development;

namespace Temphouse.MVVM.Models
{
    [Serializable]
    public class SessionModel : BaseModel
    {
        [NonSerialized]
        private const char PARSECHAR = ':';

        [NonSerialized]
        private int _Id;
        [NonSerialized]
        private int _UserId;
        [NonSerialized]
        private string _SessionString;

        public SessionModel(int userId)
        {
            SessionString = DevMethods.GenerateRandomString(255);
        }

        public SessionModel(int userId, string sessionString, int id)
        {
            SessionString = sessionString;
            Id = id;
            UserId = userId;
        }

        public int Id
        {
            get => _Id;
            set
            {
                SetValue(ref _Id, value);
            }
        }

        public int UserId
        {
            get => _UserId;
            set
            {
                SetValue(ref _UserId, value);
            }
        }

        public string SessionString
        {
            get => _SessionString;
            set
            {
                SetValue(ref _SessionString, value);
            }
        }

        public override string ToString()
        {
            return Id.ToString() + PARSECHAR + SessionString + PARSECHAR + UserId.ToString();
        }

        public static SessionModel ConvertFromString(string sessionModelString)
        {
            List<string> @params = sessionModelString.Split(PARSECHAR).ToList();

            if (@params.Count < 3) { throw new ArgumentException(); }

            string sessionString = @params[1];
            int userId = Convert.ToInt32(@params[2]);
            int id = Convert.ToInt32(@params[0]);

            SessionModel sessionModel = new SessionModel(userId, sessionString, id);

            return sessionModel;
        }
    }
}
