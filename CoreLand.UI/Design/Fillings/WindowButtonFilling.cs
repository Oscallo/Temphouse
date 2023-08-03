using CoreLand.UI.MVVM.Models;
using FontAwesome.Sharp;

namespace CoreLand.UI.Design.Fillings
{
    public static class WindowButtonFilling
    {
        private static WindowButtonModel _CloseButtonFilling = new WindowButtonModel(IconChar.WindowClose);

        private static WindowButtonModel _MinimizeButtonFilling = new WindowButtonModel(IconChar.WindowMinimize);

        private static WindowButtonModel _MaximizeButtonFilling = new WindowButtonModel(IconChar.WindowMaximize);

        private static WindowButtonModel _HideButtonFilling = new WindowButtonModel(IconChar.EyeLowVision);

        private static WindowButtonModel _RestoreButtonFilling = new WindowButtonModel(IconChar.WindowRestore);

        public static WindowButtonModel CloseButtonFilling
        {
            get { return _CloseButtonFilling; }
            private set
            {
                _CloseButtonFilling = value;
            }
        }

        public static WindowButtonModel MinimizeButtonFilling
        {
            get { return _MinimizeButtonFilling; }
            private set
            {
                _MinimizeButtonFilling = value;
            }
        }

        public static WindowButtonModel MaximizeButtonFilling
        {
            get { return _MaximizeButtonFilling; }
            private set
            {
                _MaximizeButtonFilling = value;
            }
        }

        public static WindowButtonModel HideButtonFilling
        {
            get { return _HideButtonFilling; }
            private set
            {
                _HideButtonFilling = value;
            }
        }

        public static WindowButtonModel RestoreButtonFilling
        {
            get { return _RestoreButtonFilling; }
            private set
            {
                _RestoreButtonFilling = value;
            }
        }

        static WindowButtonFilling()
        {

        }
    }
}
