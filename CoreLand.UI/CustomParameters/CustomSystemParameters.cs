using System.Windows;

namespace CoreLand.UI.CustomParameters
{
    /// <summary>
    /// Расширение для <seealso cref="SystemParameters"/>
    /// </summary>
    public static class CustomSystemParameters
    {
        private static double _IconHeight = 30;
        private static double _IconWidth = 30;

        /// <summary>
        /// Высота иконки
        /// </summary>
        public static double IconHeight { get { return _IconHeight; } }

        /// <summary>
        /// Ширина иконки
        /// </summary>
        public static double IconWidth { get { return _IconWidth; } }
    }
}
