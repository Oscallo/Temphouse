using CoreLand.UI.Models;
using FontAwesome.Sharp;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Temphouse.Models.Interfaces;

namespace Temphouse.Models
{
    public class MenuButtonModel : CommonIconModel, ISelectable
    {
        private bool _IsSelected = false;

        public MenuButtonModel() : base() { }

        public MenuButtonModel(IconChar icon) : base(icon) { }

        public bool IsSelected 
        { 
            get => _IsSelected;
            set 
            {
                if (_IsSelected == value) { return; }
                OnPropertyChanging(nameof(IsSelected));
                _IsSelected = value;
                OnPropertyChanged(nameof(IsSelected));
            }
        }
    }
}
