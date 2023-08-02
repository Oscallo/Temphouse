using CoreLand.UI.Modules.Boxes;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace CoreLand.UI.CustomControls.Panels
{
    public partial class RadialPanel : Panel
    {
        private const double _MaxAngle = 360.0f;
        private const double _RadianCoef = (Math.PI / 180);

        public RadialPanel() : base()
        {

        }

        private int _ChildrensCount => Children.Count;

        public double Radius 
        {
            get
            {
                return (double)GetValue(RadiusProperty);
            }
            set
            {
                SetValue(RadiusProperty, value);
            }
        }

        public bool IsAutoGenerateRadius
        {
            get
            {
                return (bool)GetValue(IsAutoGenerateRadiusProperty);
            }
            set
            {
                SetValue(IsAutoGenerateRadiusProperty, BooleanBoxes.Box(value));
            }
        }

        /// <summary>
        /// Необходимый минимальный размер
        /// </summary>
        /// <param name="availableSize"></param>
        /// <returns></returns>
        protected override Size MeasureOverride(Size availableSize)
        {
            Size mySize = new Size(0,0);

            foreach (UIElement child in this.InternalChildren)
            {
                child.Measure(availableSize);
                mySize.Width += child.DesiredSize.Width;
                mySize.Height += child.DesiredSize.Height;
            }

            // КАК ПОЛУЧИТЬ НОРМАЛЬНОЕ ЗНАЧЕНИЕ????

            return mySize;
        }

        /// <summary>
        /// Логика расположения элементов
        /// </summary>
        /// <param name="finalSize"></param>
        /// <returns></returns>
        protected override Size ArrangeOverride(Size finalSize)
        {
            if (_ChildrensCount == 0) { return finalSize; }

            Point centerPanelPoint;
            double elementRadian = 0;
            double radianStep = 0;
            double radius = 0;
            double radiusX = 0;
            double radiusY = 0;

            radianStep = (_MaxAngle / _ChildrensCount) * _RadianCoef;
            centerPanelPoint = _GetCenterPanel(finalSize);
            if (IsAutoGenerateRadius == true)
            {
                radius = _CalculateRadius(centerPanelPoint, finalSize, radianStep, _ChildrensCount);
            }
            else 
            {
                radius = Radius;
            }

            radiusX = radius;
            radiusY = radius;


            foreach (UIElement child in Children)
            {
                // Вычислить точку на окружности для элемента
                Point childPoint = new Point(Math.Cos(elementRadian) * radiusX, -Math.Sin(elementRadian) * radiusY);

                // Смещение точки в доступной прямоугольной области, равной FinalSize.
                Point actualChildPoint = new Point(centerPanelPoint.X + childPoint.X - child.DesiredSize.Width / 2, centerPanelPoint.Y + childPoint.Y - child.DesiredSize.Height / 2);

                // Вызовите метод Arrange для дочернего элемента, указывающий на вычисленную точку в качестве PlacementPoint.
                child.Arrange(new Rect(actualChildPoint.X, actualChildPoint.Y, child.DesiredSize.Width, child.DesiredSize.Height));

                // Вычислить новый _angle для данного элемента
                elementRadian += radianStep;
            }

            return finalSize;
        }

        private double _CalculateRadius(Point centerPanelPoint, Size finalSize, double radianStep, int childrensCount) 
        {
            bool isHorizontalDecrease = true;
            bool isVerticalDecrease = true;

            if (_ChildrensCount < 3)
            {
                isVerticalDecrease = false;
            }

            double elementRadian = 0;
            double radius = 0;

            double possibleWidth = finalSize.Width;
            double possibleHeight = finalSize.Height;

            if ((isHorizontalDecrease == true) && (isVerticalDecrease == true))
            {
                radius = Math.Min(possibleWidth / 2, possibleHeight / 2);
            }
            else if (isHorizontalDecrease == true)
            {
                radius = possibleWidth / 2;
            }
            else if (isVerticalDecrease == true)
            {
                radius = possibleHeight / 2;
            }

            foreach (UIElement elem in Children)
            {
                // Кординаты левой верхней границы фигуры
                Point coordinateElement = new Point(centerPanelPoint.X + radius * Math.Cos(elementRadian), centerPanelPoint.Y + radius * Math.Sin(elementRadian));

                if ((coordinateElement.X + elem.DesiredSize.Width > possibleWidth) && (isHorizontalDecrease == true))
                {
                    // На сколько вылез за пределы элемента
                    double goingBeyondX = coordinateElement.X + elem.DesiredSize.Width - possibleWidth;

                    radius -= goingBeyondX;
                }

                if ((coordinateElement.Y + elem.DesiredSize.Height > possibleHeight) && (isVerticalDecrease == true))
                {
                    // На сколько вылез за пределы элемента
                    double goingBeyondY = coordinateElement.Y + elem.DesiredSize.Height - possibleHeight;

                    radius -= goingBeyondY;
                }

                elementRadian += radianStep;
            }
            return radius;
        }

        private Point _GetCenterPanel(Size size)
        {
            return new Point(size.Width/2, size.Height/2);
        }

    }
}
