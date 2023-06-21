using System;

namespace CoreLand.UI.Modules.Boxes
{
    public static class BooleanBoxes
    {
        public static object TrueBox = true;
        public static object FalseBox = false;

        public static bool Exist(object obj) 
        {
            try
            {
                bool val = Convert.ToBoolean(obj);

                return true;
            }
            catch { return false; }
        }

        public static object Box(bool value)
        {
            if (value == true)
            {
                return TrueBox;
            }
            else
            {
                return FalseBox;
            }
        }
    }
}
