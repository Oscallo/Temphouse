using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CoreLand.UI.Models
{
    public class WindowButtonModel : INotifyPropertyChanged, INotifyPropertyChanging
    {
        public WindowButtonModel() { }

        private object? _Content;

        public object? Content
        {
            get { return _Content; }
            set
            {
                if (_Content == value) return;
                OnPropertyChanging(nameof(Content));
                _Content = value;
                OnPropertyChanged(nameof(Content));
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
