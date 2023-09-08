using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CoreLand.UI.MVVM.Models
{
    public partial class BaseModel : INotifyPropertyChanged, INotifyPropertyChanging
    {
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

        protected void SetValue<T>(ref T storage, T value, IList<string> otherPropertyNames = null, [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value))
            {
                return;
            }

            this.OnPropertyChanging(propertyName);
            if (otherPropertyNames != null)
            {
                foreach (var otherPropertyName in otherPropertyNames)
                {
                    this.OnPropertyChanging(otherPropertyName);
                }
            }

            storage = value;

            this.OnPropertyChanged(propertyName);
            if (otherPropertyNames != null)
            {
                foreach (var otherPropertyName in otherPropertyNames)
                {
                    this.OnPropertyChanged(otherPropertyName);
                }
            }
        }

        #endregion

    }
}
