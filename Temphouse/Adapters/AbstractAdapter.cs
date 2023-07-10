﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Temphouse.Adapters
{
    public abstract class AbstractAdapter : INotifyPropertyChanged, INotifyPropertyChanging
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

        #endregion
    }
}
