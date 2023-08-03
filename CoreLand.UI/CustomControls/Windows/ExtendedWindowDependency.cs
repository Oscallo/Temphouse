using CoreLand.UI.Modules.Boxes;
using System;
using System.Security;
using System.Windows;

using Window = System.Windows.Window;

namespace CoreLand.UI.CustomControls.Windows
{
    public partial class ExtendedWindow : Window
    {
        /// <summary>
        ///     DependencyProperty свойства IsHideable.
        /// </summary>
        public static readonly DependencyProperty IsHideableProperty = DependencyProperty.Register(nameof(IsHideable), typeof(bool), typeof(ExtendedWindow),
                               new FrameworkPropertyMetadata(BooleanBoxes.TrueBox,FrameworkPropertyMetadataOptions.AffectsRender|FrameworkPropertyMetadataOptions.Inherits, new PropertyChangedCallback(OnIsHideableChanged), new CoerceValueCallback(VerifyAccessHideableCoercion)));




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
        /// <exception cref="FieldAccessException"/>`
        [SecurityCritical, SecurityTreatAsSafe]
        private void VerifyApiSupported(DependencyObject d) 
        {
        
        }

        private static void OnIsHideableChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ExtendedWindow extendedWindow = (ExtendedWindow)d;

            extendedWindow.OnIsHideableChanged((bool)e.NewValue);
        }


        static ExtendedWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ExtendedWindow), new FrameworkPropertyMetadata(typeof(ExtendedWindow)));
        }
    }
}
