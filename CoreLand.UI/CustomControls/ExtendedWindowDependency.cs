using CoreLand.UI.Modules.Boxes;
using System;
using System.Windows;

namespace CoreLand.UI.CustomControls
{
    public partial class ExtendedWindow : System.Windows.Window
    {
        /// <summary>
        ///     DependencyProperty свойства IsHideable.
        /// </summary>
        public static readonly DependencyProperty IsHideableProperty = DependencyProperty.Register(nameof(IsHideable), typeof(bool), typeof(ExtendedWindow),
                               new FrameworkPropertyMetadata(BooleanBoxes.TrueBox,FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(OnIsHideableChanged), new CoerceValueCallback(VerifyAccessHideableCoercion)));


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
