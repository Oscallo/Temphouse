using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Temphouse.Themes.SquaredButtonControl
{
    public partial class SquaredButton : Button
    {

        /// <summary>
        /// Сокрытие <seealso cref="Height"/> от <seealso cref="Button"/>
        /// </summary>
        [TypeConverter(typeof(LengthConverter))]
        [Localizability(LocalizationCategory.None, Readability = Readability.Unreadable)]
        public new double Height
        {
            get { return (double)GetValue(HeightProperty); }
            private set { SetValue(HeightProperty, value); }
        }

        /// <summary>
        /// Сокрытие <seealso cref="Width"/> от <seealso cref="Button"/>
        /// </summary>
        [TypeConverter(typeof(LengthConverter))]
        [Localizability(LocalizationCategory.None, Readability = Readability.Unreadable)]
        public new double Width
        {
            get { return (double)GetValue(WidthProperty); }
            private set { SetValue(WidthProperty, value); }
        }

        /// <summary>
        /// Новое свойство, которое заменяет <seealso cref="Height"/> и <seealso cref="Width"/>.
        /// </summary>
        [TypeConverter(typeof(LengthConverter))]
        [Localizability(LocalizationCategory.None, Readability = Readability.Unreadable)]
        public double Edge
        {
            get { return (double)GetValue(EdgeProperty); }
            set { SetValue(EdgeProperty, value); }
        }

        public SquaredButton() : base() 
        {

        }
    }
}
