using CoreLand.UI.MVVM.Models;

namespace Temphouse.Models
{
    public class UserModel : BaseModel
    {
        private int _Id;
        private string _Password;
        private string _Name;
        private string _Family;

        public UserModel() { }

        public UserModel(string name,string family,string password) 
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
                if (_Id == value) { return; }
                OnPropertyChanging(nameof(Id));
                _Id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        public string Password
        {
            get => _Password;
            set
            {
                if (_Password == value) { return; }
                OnPropertyChanging(nameof(Password));
                _Password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public string Name
        {
            get => _Name;
            set
            {
                if (_Name == value) { return; }
                OnPropertyChanging(nameof(Name));
                _Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Family
        {
            get => _Family;
            set
            {
                if (_Family == value) { return; }
                OnPropertyChanging(nameof(Family));
                _Family = value;
                OnPropertyChanged(nameof(Family));
            }
        }
    }
}
