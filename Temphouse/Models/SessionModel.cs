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
        private int _Id;
        [NonSerialized]
        private int _UserId;
        [NonSerialized]
        private string _SessionString;

        public SessionModel(int userId)
        {
            SessionString = DevMethods.GenerateRandomString(255);
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

    }
}
