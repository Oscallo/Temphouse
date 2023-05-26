using FontAwesome.Sharp;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CoreLand.UI.Models
{
    public class WindowButtonModel : INotifyPropertyChanged, INotifyPropertyChanging
    {
        public WindowButtonModel() { }

        public WindowButtonModel(IconChar icon)
        { 
            Icon = icon; 
        }

        private IconChar _Icon = IconChar.Accusoft;

        public IconChar Icon
        {
            get { return _Icon; }
            set
            {
                if (_Icon == value) return;
                OnPropertyChanging(nameof(Icon));
                _Icon = value;
                OnPropertyChanged(nameof(Icon));
            }
        }

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
    }
}
