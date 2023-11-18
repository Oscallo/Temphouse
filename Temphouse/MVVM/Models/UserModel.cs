using CoreLand.UI.MVVM.Models;
using System;
using System.Security;

namespace Temphouse.MVVM.Models
{
    public class UserModel : BaseModel
    {
        private int _Id = -1;
        private SecureString _Password;
        private string _Name = string.Empty;
        private string _SecondName = string.Empty;
        private string _Family = string.Empty;
        private string _Login = string.Empty;
        private DateOnly _DateBirthday = new DateOnly();

        public UserModel() { }

        public UserModel(string name, string family, SecureString password)
        {
            Name = name;
            Family = family;
            Password = password;
        }

        public string Login
        {
            get => _Login;
            set
            {
                SetValue(ref _Login, value);
            }
        }

        public DateOnly DateBirthday
        {
            get => _DateBirthday;
            set
            {
                SetValue(ref _DateBirthday, value);
            }
        }

        public int Id
        {
            get => _Id;
            private set
            {
                SetValue(ref _Id, value);
            }
        }

        public SecureString Password
        {
            get => _Password;
            set
            {
                SetValue(ref _Password, value);
            }
        }

        public string Name
        {
            get => _Name;
            set
            {
                SetValue(ref _Name, value);
            }
        }
        public string SecondName
        {
            get => _SecondName;
            set
            {
                SetValue(ref _SecondName, value);
            }
        }

        public string Family
        {
            get => _Family;
            set
            {
                SetValue(ref _Family, value);
            }
        }
    }
}
