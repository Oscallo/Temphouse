using System.Windows;

namespace CoreLand.UI.MicrosoftClasses.KnownBoxes
{
    /// <summary>
    /// Класс взят из https://referencesource.microsoft.com/#PresentationFramework/src/Framework/MS/Internal/KnownBoxes.cs,4392051c50d073ad
    /// internal -> public
    /// SR.Get(SRID.Rect_WidthAndHeightCannotBeNegative) -> "WidthAndHeightCannotBeNegative" | "WidthCannotBeNegative" | "HeightCannotBeNegative"
    /// </summary>
    public class SizeBox
    {
        public SizeBox(double width, double height)
        {
            if (width < 0 || height < 0)
            {
                throw new System.ArgumentException("WidthAndHeightCannotBeNegative");
            }

            _width = width;
            _height = height;
        }

        public SizeBox(Size size) : this(size.Width, size.Height) { }

        public double Width
        {
            get
            {
                return _width;
            }
            set
            {
                if (value < 0)
                {
                    throw new System.ArgumentException("WidthCannotBeNegative");
                }

                _width = value;
            }
        }

        public double Height
        {
            get
            {
                return _height;
            }
            set
            {
                if (value < 0)
                {
                    throw new System.ArgumentException("HeightCannotBeNegative");
                }

                _height = value;
            }
        }

        private double _width;
        private double _height;
    }
}
