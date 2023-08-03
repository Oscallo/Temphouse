using System.Windows;

namespace CoreLand.UI.MicrosoftClasses.KnownBoxes
{
    /// <summary>
    /// Класс взят из https://referencesource.microsoft.com/#PresentationCore/Core/CSharp/MS/Internal/KnownBoxes.cs,51b7bd3e0b50eb3e
    /// internal -> public
    /// </summary>
    public static class VisibilityBoxes
    {
        public static object VisibleBox = Visibility.Visible;
        public static object HiddenBox = Visibility.Hidden;
        public static object CollapsedBox = Visibility.Collapsed;

        public static object Box(Visibility value)
        {
            if (value == Visibility.Visible)
            {
                return VisibleBox;
            }
            else if (value == Visibility.Hidden)
            {
                return HiddenBox;
            }
            else
            {
                return CollapsedBox;
            }
        }
    }
}
