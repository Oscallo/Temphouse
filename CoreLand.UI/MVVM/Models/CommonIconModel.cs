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
                SetValue(ref _Icon, value);
            }
        }
    }
}
