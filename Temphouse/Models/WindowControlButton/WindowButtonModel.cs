using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Temphouse.Models.WindowControlButton
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
                OnPropertyChanging(nameof(this.Content));
                _Content = value;
                OnPropertyChanged(nameof(this.Content));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public event PropertyChangingEventHandler? PropertyChanging;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public void OnPropertyChanging([CallerMemberName] string prop = "")
        {
            if (PropertyChanging != null)
                PropertyChanging(this, new PropertyChangingEventArgs(prop));
        }
    }
}
