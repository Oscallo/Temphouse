using System.Windows.Media;

namespace CoreLand.UI.MicrosoftClasses.KnownBoxes
{
    /// <summary>
    /// Класс взят из https://referencesource.microsoft.com/#PresentationCore/Core/CSharp/MS/Internal/KnownBoxes.cs,51b7bd3e0b50eb3e
    /// internal -> public
    /// </summary>
    public static class FillRuleBoxes
    {
        public static object EvenOddBox = FillRule.EvenOdd;
        public static object NonzeroBox = FillRule.Nonzero;

        public static object Box(FillRule value)
        {
            if (value == FillRule.Nonzero)
            {
                return NonzeroBox;
            }
            else
            {
                return EvenOddBox;
            }
        }
    }
}
