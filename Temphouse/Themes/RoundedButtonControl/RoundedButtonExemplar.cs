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
        /// The CornerRadius property allows users to control the roundness of the corners independently by
        /// setting a radius value for each corner.  Radius values that are too large are scaled so that they
        /// smoothly blend from corner to corner.
        /// </summary>
        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }

        }
    }
}
