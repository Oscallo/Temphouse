using System.Windows;

namespace CoreLand.UI.Extensions
{
    /// <summary>
    /// Расширение для <seealso cref="SystemParameters"/>
    /// </summary>
    public static class CustomSystemParameters
    {
        private static double _IconHeight = 45;
        private static double _IconWidth = 45;

        /// <summary>
        /// Высота иконки
        /// </summary>
        public static double IconHeight
        {
            get
            {
                return _IconHeight;
            }
        }

        /// <summary>
        /// Ширина иконки
        /// </summary>
        public static double IconWidth
        {
            get
            {
                return _IconWidth;
            }
        }
    }
}
