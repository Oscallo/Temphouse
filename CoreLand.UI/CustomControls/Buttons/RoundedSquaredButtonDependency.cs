using CoreLand.UI.Standart.Extensions.StructExtensions;
using System.Windows;

namespace CoreLand.UI.CustomControls.Buttons
{
    /// <summary>
    /// Скругленная кнопка от <seealso cref="SquaredButton"/>
    /// </summary>
    public partial class RoundedSquaredButton : SquaredButtonBase
    {
        /// <summary>
        /// <seealso cref="DependencyProperty"/> скругления.
        /// </summary>
        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(RoundedSquaredButton),
                                          new FrameworkPropertyMetadata(new CornerRadius(), FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender),
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

        static RoundedSquaredButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RoundedSquaredButton), new FrameworkPropertyMetadata(typeof(RoundedSquaredButton)));
        }
    }
}
