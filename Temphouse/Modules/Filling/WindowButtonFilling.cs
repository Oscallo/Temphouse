using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Temphouse.Models.WindowControlButton;

namespace Temphouse.Modules.Filling
{
    public static class WindowButtonFilling
    {
        private static WindowButtonModel _WindowCloseButtonFilling = new WindowButtonModel();

        private static WindowButtonModel _WindowMinimizeButtonFilling = new WindowButtonModel();

        private static WindowButtonModel _WindowMaximizeButtonFilling = new WindowButtonModel();

        private static WindowButtonModel _WindowHideButtonFilling = new WindowButtonModel();

        private static WindowButtonModel _WindowRestoreButtonFilling = new WindowButtonModel();

        public static WindowButtonModel WindowCloseButtonFilling 
        {
            get { return _WindowCloseButtonFilling; }
            private set 
            {
                _WindowCloseButtonFilling = value;
            }
        }

        public static WindowButtonModel WindowMinimizeButtonFilling
        {
            get { return _WindowMinimizeButtonFilling; }
            private set
            {
                _WindowMinimizeButtonFilling = value;
            }
        }

        public static WindowButtonModel WindowMaximizeButtonFilling
        {
            get { return _WindowMaximizeButtonFilling; }
            private set
            {
                _WindowMaximizeButtonFilling = value;
            }
        }

        public static WindowButtonModel WindowHideButtonFilling
        {
            get { return _WindowHideButtonFilling; }
            private set
            {
                _WindowHideButtonFilling = value;
            }
        }

        public static WindowButtonModel WindowRestoreButtonFilling
        {
            get { return _WindowRestoreButtonFilling; }
            private set
            {
                _WindowRestoreButtonFilling = value;
            }
        }

        static WindowButtonFilling() 
        {

        }
    }
}
