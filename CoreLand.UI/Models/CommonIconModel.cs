using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CoreLand.UI.Models
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
