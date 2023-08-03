using FontAwesome.Sharp;

namespace CoreLand.UI.MVVM.Models
{
    public class CommonIconModel : BaseModel
    {
        private IconChar _Icon = IconChar.Accusoft;

        public CommonIconModel() { }

        public CommonIconModel(IconChar icon)
        {
            Icon = icon;
        }

        public IconChar Icon
        {
            get => _Icon;
            set
            {
                if (_Icon == value) { return; }
                OnPropertyChanging(nameof(Icon));
                _Icon = value;
                OnPropertyChanged(nameof(Icon));
            }
        }
    }
}
