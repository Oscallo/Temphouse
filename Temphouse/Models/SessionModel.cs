using CoreLand.UI.Models;
using System;
using System.Configuration;
using Temphouse.Modules.Depelopment;

namespace Temphouse.Models
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

        public SessionModel(int userId, string sessionString, int id )
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
                if (_Id == value) { return; }
                OnPropertyChanging(nameof(Id));
                _Id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        public int UserId
        {
            get => _UserId;
            set
            {
                if (_UserId == value) { return; }
                OnPropertyChanging(nameof(UserId));
                _UserId = value;
                OnPropertyChanged(nameof(UserId));
            }
        }

        public string SessionString
        {
            get => _SessionString;
            set
            {
                if (_SessionString == value) { return; }
                OnPropertyChanging(nameof(SessionString));
                _SessionString = value;
                OnPropertyChanged(nameof(SessionString));
            }
        }

        public override string ToString()
        {
            return Id.ToString() + PARSECHAR + SessionString + PARSECHAR + UserId.ToString();
        }

        public static SessionModel ConvertFromString(string sessionModelString) 
        {
            List<string> @params =  sessionModelString.Split(PARSECHAR).ToList<string>();

            if (@params.Count < 3) { throw new ArgumentException(); }

            string sessionString = @params[1];
            int userId = Convert.ToInt32(@params[2]);
            int id = Convert.ToInt32(@params[0]);

            SessionModel sessionModel = new SessionModel(userId, sessionString, id);

            return sessionModel;
        }
    }
}
