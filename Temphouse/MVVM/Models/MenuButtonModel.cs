using CoreLand.UI.MVVM.Models;
using FontAwesome.Sharp;
using Temphouse.MVVM.Models.Interfaces;

namespace Temphouse.MVVM.Models
{
    public class MenuButtonModel : CommonIconModel, ISelectable
    {
        private bool _IsSelected = false;
        private string _Title = string.Empty;

        public MenuButtonModel() : base() { }

        public MenuButtonModel(IconChar icon) : base(icon) { }

        public bool IsSelected
        {
            get => _IsSelected;
            set
            {
                SetValue(ref _IsSelected, value);
            }
        }

        public string Title
        {
            get => _Title;
            set
            {
                SetValue(ref _Title, value);
            }
        }
    }
}
