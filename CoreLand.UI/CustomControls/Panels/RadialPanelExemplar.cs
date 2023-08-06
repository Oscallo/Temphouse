using CoreLand.UI.MicrosoftClasses.KnownBoxes;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Media3D;

namespace CoreLand.UI.CustomControls.Panels
{
    public partial class RadialPanel : Panel
    {
        private const double _MaxAngle = 360.0f;
        private const double _RadianCoef = (Math.PI / 180);

        public RadialPanel() : base()
        {

        }

        public double Radius 
        { 
            get { return (double)GetValue(RadiusProperty); }
            set { SetValue(RadiusProperty, value); }
        }

        public double MinRadius
        {
            get { return (double)GetValue(MinRadiusProperty); }
            set { SetValue(MinRadiusProperty, value); }
        }

        public double MaxRadius
        {
            get { return (double)GetValue(MaxRadiusProperty); }
            set { SetValue(MaxRadiusProperty, value); }
        }

        public bool IsAutoGenerateRadius
        {
            get { return (bool)GetValue(IsAutoGenerateRadiusProperty); }
            set { SetValue(IsAutoGenerateRadiusProperty, BooleanBoxes.Box(value)); }
        }

        /// <summary>
        /// При переопределении в производном классе измеряет размер в структуре, требуемый для дочерних элементов, и определяет размер для класса, производного от <seealso cref="FrameworkElement"/>. 
        /// (Минимальный необходимый размер для элемента)
        /// </summary>
        /// <param name="availableSize">Доступный размер, который этот элемент может предоставить дочерним элементам. Можно задать бесконечное значение, указав таким образом, что элемент будет масштабироваться в соответствии с любым содержимым.</param>
        /// <returns>Размер, определяемый данным элементом для своих потребностей во время структурирования на основе вычисления размеров дочерних элементов.</returns>
        protected override Size MeasureOverride(Size availableSize)
        {
            Size mySize = new Size(0, 0);

            bool CalculationIsMinWidth = availableSize.Width == Double.PositiveInfinity;
            bool CalculationIsMinHeight = availableSize.Height == Double.PositiveInfinity;

            foreach (UIElement child in this.Children)
            {
                child.Measure(availableSize);
                mySize.Width += child.DesiredSize.Width;
                mySize.Height += child.DesiredSize.Height;
            }

            return mySize;
        }

        /// <summary>
        /// При переопределении в производном классе размещает дочерние элементы и определяет размер для производного от <seealso cref="FrameworkElement"/>.
        /// </summary>
        /// <param name="finalSize">Итоговая область в родительском элементе, которую этот элемент должен использовать для размещения себя и своих дочерних элементов.</param>
        /// <returns>Фактический используемый размер.</returns>
        protected override Size ArrangeOverride(Size finalSize)
        {
            if (Children.Count == 0) { return finalSize; }

            Point centerPanelPoint;
            double elementRadian = 0;
            double radianStep = 0;
            double radius = 0;
            double radiusX = 0;
            double radiusY = 0;

            radianStep = (_MaxAngle / Children.Count) * _RadianCoef;
            centerPanelPoint = _GetCenterPanel(finalSize);
            if (IsAutoGenerateRadius == true)
            {
                radius = _CalculateRadius(centerPanelPoint, finalSize, radianStep);
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

        /// <summary>
        /// Вычисляет радиус
        /// </summary>
        /// <param name="centerPanelPoint">Точка центра </param>
        /// <param name="finalSize">Итоговая область в родительском элементе, которую этот элемент должен использовать для размещения себя и своих дочерних элементов.</param>
        /// <param name="radianStep">Шаг в радианах</param>
        /// <returns></returns>
        private double _CalculateRadius(Point centerPanelPoint, Size finalSize, double radianStep) 
        {
            bool isHorizontalDecrease = true;
            bool isVerticalDecrease = true;

            if (Children.Count < 3)
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

                    if ((radius - goingBeyondX > this.MinRadius) && (radius - goingBeyondX < this.MaxRadius)) { radius -= goingBeyondX; }
                    else if (radius - goingBeyondX > this.MinRadius) { radius = MinRadius; }
                    else if (radius - goingBeyondX < this.MaxRadius) { radius = MaxRadius; }
                }

                if ((coordinateElement.Y + elem.DesiredSize.Height > possibleHeight) && (isVerticalDecrease == true))
                {
                    // На сколько вылез за пределы элемента
                    double goingBeyondY = coordinateElement.Y + elem.DesiredSize.Height - possibleHeight;

                    if ((radius - goingBeyondY > this.MinRadius) && (radius - goingBeyondY < this.MaxRadius)) { radius -= goingBeyondY; }
                    else if (radius - goingBeyondY > this.MinRadius) { radius = MinRadius; }
                    else if (radius - goingBeyondY < this.MaxRadius) { radius = MaxRadius; }
                }

                elementRadian += radianStep;
            }
            return radius;
        }

        private Point _GetCenterPanel(Size size)
        {
            return new Point(size.Width/2, size.Height/2);
        }

        private void OnRadiusChanged(double newValue)
        {
            if (newValue < this.MinRadius) { Radius = this.MinRadius; }
            if (newValue > this.MaxRadius) { Radius = this.MaxRadius; }
        }

        private void OnMaxRadiusChanged(double newValue)
        {
            if (newValue < this.Radius) { Radius = newValue; }
            if (newValue < this.MinRadius) { MaxRadius = this.MinRadius; }
        }

        private void OnMinRadiusChanged(double newValue)
        {
            if (newValue > this.Radius) { Radius = newValue; }
            if (newValue > this.MaxRadius) { MinRadius = this.MaxRadius; }
        }
    }
}
