using CoreLand.UI.MVVM.Models;

namespace Temphouse.MVVM.Models
{
    public class UserModel : BaseModel
    {
        private int _Id = -1;
        private string _Password = string.Empty;
        private string _Name = string.Empty;
        private string _SecondName = string.Empty;
        private string _Family = string.Empty;

        public UserModel() { }

        public UserModel(string name, string family, string password)
        {
            Name = name;
            Family = family;
            Password = password;
        }

        public int Id
        {
            get => _Id;
            private set
            {
                SetValue(ref _Id, value);
            }
        }

        public string Password
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
