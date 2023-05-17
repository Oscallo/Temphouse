using System.Windows;

namespace CoreLand.UI.CustomControls
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
