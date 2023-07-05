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
                OnPropertyChanging(nameof(Icon));
                _Id = value;
                OnPropertyChanged(nameof(Icon));
            }
        }

        public string Password
        {
            get => _Password;
            set
            {
                if (_Password == value) { return; }
                OnPropertyChanging(nameof(Icon));
                _Password = value;
                OnPropertyChanged(nameof(Icon));
            }
        }
    }
}
