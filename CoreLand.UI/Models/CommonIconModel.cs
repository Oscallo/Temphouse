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
    public class CommonIconModel : INotifyPropertyChanged, INotifyPropertyChanging
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

        #region PropertyChanged and PropertyChanging

        public event PropertyChangedEventHandler? PropertyChanged;
        public event PropertyChangingEventHandler? PropertyChanging;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        public void OnPropertyChanging([CallerMemberName] string prop = "")
        {
            if (PropertyChanging != null)
            {
                PropertyChanging(this, new PropertyChangingEventArgs(prop));
            }
        }

        #endregion
    }
}
