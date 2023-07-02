using CoreLand.UI.Modules.Boxes;
using System;
using System.Security;
using System.Windows;
using System.Windows.Media;

using Window = System.Windows.Window;

namespace CoreLand.UI.CustomControls
{
    public partial class ExtendedWindow : Window
    {
        private static object ISHIDEABLE_DEFAULTVALUE = BooleanBoxes.TrueBox;
        private const SolidColorBrush HEADERBARBACKGROUND_DEFAULTVALUE = (SolidColorBrush)null;

        /// <summary>
        ///     DependencyProperty свойства <see cref="IsHideable"/>.
        /// </summary>
        public static readonly DependencyProperty IsHideableProperty = DependencyProperty.Register(nameof(IsHideable), typeof(bool), typeof(ExtendedWindow),
                               new FrameworkPropertyMetadata(ExtendedWindow.ISHIDEABLE_DEFAULTVALUE, FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(OnIsHideableChanged), new CoerceValueCallback(VerifyAccessHideableCoercion)));

        /// <summary>
        ///     DependencyProperty свойства <see cref="HeaderBarBackground\"/>.
        /// </summary>
        public static readonly DependencyProperty HeaderBarBackgroundProperty = DependencyProperty.Register(nameof(HeaderBarBackground), typeof(SolidColorBrush), typeof(ExtendedWindow),
                               new FrameworkPropertyMetadata(ExtendedWindow.HEADERBARBACKGROUND_DEFAULTVALUE, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.SubPropertiesDoNotAffectRender));

        /// <summary>
        /// Проверяет на запрет изменения свойства
        /// </summary>
        /// <param name="d">Свойство</param>
        /// <param name="baseValue">Ьазвое значение</param>
        /// <returns>Итоговое значение</returns>
        private static object VerifyAccessHideableCoercion(DependencyObject d, object baseValue)
        {
            ((ExtendedWindow)d).VerifyApiSupported(d);

            return baseValue;
        }

        /// <summary>
        /// Возвращает исключение, если установка свойства запрещена.
        /// </summary>
        /// <param name="d">Свойство</param>
        /// <exception cref="FieldAccessException"/>
        [SecurityCritical, SecurityTreatAsSafe]
        private void VerifyApiSupported(DependencyObject d) 
        {
        
        }

        private static void OnIsHideableChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            
        }

        static ExtendedWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ExtendedWindow), new FrameworkPropertyMetadata(typeof(ExtendedWindow)));
        }
    }
}
