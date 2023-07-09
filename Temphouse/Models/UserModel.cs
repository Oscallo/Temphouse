using CoreLand.UI.Models;
using FontAwesome.Sharp;

namespace Temphouse.Models
{
    public class UserModel : BaseModel
    {
        private int _Id;
        private string _Password;

        public UserModel() { }

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
    }
}
