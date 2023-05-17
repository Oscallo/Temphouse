using System;
using System.Windows;
using System.Windows.Controls;

namespace CoreLand.UI.CustomControls
{
    public partial class SquaredButton : Button
    {
        /// <summary>
        /// <seealso cref="DependencyProperty"/> задающее ширину и высоту кнопки.
        /// </summary>
        public static readonly DependencyProperty EdgeProperty = DependencyProperty.Register(
                                                                 "Edge", typeof(double), typeof(SquaredButton),
                                                                 new FrameworkPropertyMetadata(Double.NaN, FrameworkPropertyMetadataOptions.AffectsMeasure, new PropertyChangedCallback(OnTransformDirty)),
                                                                 new ValidateValueCallback(IsEdgeValid));


        /// <summary>
        /// Вызывается при смене <seealso cref="Edge"/>
        /// </summary>
        /// <param name="d"><seealso cref="SquaredButton"/></param>
        /// <param name="e">Аргументы</param>
        private static void OnTransformDirty(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SquaredButton squaredButton = ((SquaredButton)d);

            squaredButton.Width = (double)e.NewValue;
            squaredButton.Height = (double)e.NewValue;
        }

        /// <summary>
        /// Проверка на валидность
        /// </summary>
        /// <param name="value">Предпологаемый <seealso cref="Edge"/></param>
        /// <returns></returns>
        private static bool IsEdgeValid(object value)
        {
            double doubleValue = (double)value;
            return (Double.IsNaN(doubleValue)) || (doubleValue >= 0.0d && !Double.IsPositiveInfinity(doubleValue));
        }

        static SquaredButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SquaredButton), new FrameworkPropertyMetadata(typeof(SquaredButton)));
        }
    }
}
