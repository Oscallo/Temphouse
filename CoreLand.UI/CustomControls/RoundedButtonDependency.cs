using CoreLand.UI.Extensions;
using System.Windows;

namespace CoreLand.UI.CustomControls
{
    /// <summary>
    /// Скругленная кнопка от <seealso cref="SquaredButton"/>
    /// </summary>
    public partial class RoundedButton : SquaredButton
    {
        /// <summary>
        /// <seealso cref="DependencyProperty"/> скругления.
        /// </summary>
        public static readonly DependencyProperty CornerRadiusProperty
            = DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(RoundedButton),
                                          new FrameworkPropertyMetadata(
                                                new CornerRadius(),
                                                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender),
                                          new ValidateValueCallback(IsCornerRadiusValid));

        /// <summary>
        /// Проверка на валидность.
        /// </summary>
        /// <param name="value">Предпологаемый <seealso cref="CornerRadius"/></param>
        /// <returns>Возвращает True, если конвертация возможна.</returns>
        private static bool IsCornerRadiusValid(object value)
        {
            CornerRadius cr = (CornerRadius)value;
            return (cr.IsValid(false, false, false, false));
        }

        static RoundedButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RoundedButton), new FrameworkPropertyMetadata(typeof(RoundedButton)));
        }
    }
}
