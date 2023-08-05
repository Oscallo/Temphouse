using System;
using System.Windows;
using System.Windows.Controls;

namespace CoreLand.UI.CustomControls.Buttons
{
    public partial class SquaredButtonBase : Button
    {
        /// <summary>
        /// <seealso cref="DependencyProperty"/> задающее <see cref="Height"/> и высоту <see cref="Width"/>.
        /// </summary>
        public static readonly DependencyProperty EdgeProperty = DependencyProperty.Register(nameof(Edge), typeof(double), typeof(SquaredButtonBase),
                                                                 new FrameworkPropertyMetadata(Double.NaN, FrameworkPropertyMetadataOptions.AffectsMeasure, new PropertyChangedCallback(OnTransformDirty)),
                                                                 new ValidateValueCallback(IsEdgeValid));


        /// <summary>
        /// Вызывается при смене <seealso cref="Edge"/>
        /// </summary>
        /// <param name="d"><seealso cref="SquaredButtonBase"/></param>
        /// <param name="e">Аргументы</param>
        private static void OnTransformDirty(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SquaredButtonBase squaredButtonBase = ((SquaredButtonBase)d);

            squaredButtonBase.Width = (double)e.NewValue;
            squaredButtonBase.Height = (double)e.NewValue;
        }

        /// <summary>
        /// Проверка на валидность
        /// </summary>
        /// <param name="value">Предпологаемый <seealso cref="Edge"/></param>
        /// <returns></returns>
        private static bool IsEdgeValid(object value)
        {
            double doubleValue = (double)value;
            return (Double.IsNaN(doubleValue) == true) || (doubleValue >= 0.0d && Double.IsPositiveInfinity(doubleValue) == false);
        }

        static SquaredButtonBase()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SquaredButtonBase), new FrameworkPropertyMetadata(typeof(SquaredButtonBase)));
        }
    }
}
