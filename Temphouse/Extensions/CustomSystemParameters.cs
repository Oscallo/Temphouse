using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Temphouse.Extensions
{
    public static class CustomSystemParameters
    {
        private static double _IconHeight = 45;
        private static double _IconWidth = 45;


        public static double IconHeight
        {
            get
            {
                return _IconHeight;
            }
        }

        public static double IconWidth
        {
            get
            {
                return _IconWidth;
            }
        }
    }
}
