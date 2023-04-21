using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Temphouse.Themes.SquaredButtonControl;

namespace Temphouse.Themes.RoundedButtonControl
{
    public partial class RoundedButton : SquaredButton
    {
        /// <summary>
        /// Свойство CornerRadius позволяет пользователям независимо управлять округлостью углов, устанавливая 
        /// значение радиуса для каждого угла. Слишком большие значения радиуса масштабируются таким образом, 
        /// чтобы они плавно переходят из угла в угол.
        /// </summary>
        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }

        }
    }
}
