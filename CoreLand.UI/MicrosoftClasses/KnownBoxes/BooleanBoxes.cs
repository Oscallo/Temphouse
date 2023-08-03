namespace CoreLand.UI.MicrosoftClasses.KnownBoxes
{
    /// <summary>
    /// Класс взят из https://referencesource.microsoft.com/#q=BooleanBoxes
    /// internal -> public
    /// </summary>
    public static class BooleanBoxes
    {
        public static object TrueBox = true;
        public static object FalseBox = false;

        public static object Box(bool value)
        {
            if (value)
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
