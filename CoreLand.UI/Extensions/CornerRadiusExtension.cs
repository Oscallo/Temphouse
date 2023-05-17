using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CoreLand.UI.Extensions
{

    /// <summary>
    /// Класс расшринения <seealso cref="CornerRadius"/>
    /// </summary>
    
    public static class CornerRadiusExtension
    {

        /// <summary>
        /// Проверка на валидность <seealso cref="CornerRadius"/>
        /// <br/>
        /// <a href="https://referencesource.microsoft.com/PresentationFramework/R/81b5f08f3b2031bd.html">Ссылка на исходный код от Microsoft </a>
        /// </summary>
        /// <param name="cornerRadius">CornerRadius в который внесены значения.</param>
        /// <param name="allowNegative">Возможность установки отрицательных значений.</param>
        /// <param name="allowNaN">Возможность установки <seealso cref="Double.NaN"/></param>
        /// <param name="allowPositiveInfinity">Возможность установки <seealso cref="Double.PositiveInfinity"/></param>
        /// <param name="allowNegativeInfinity">Возможность установки <seealso cref="Double.NegativeInfinity"/></param>
        /// <returns>Валидность значений</returns>
        public static bool IsValid(this CornerRadius cornerRadius, bool allowNegative, bool allowNaN, bool allowPositiveInfinity, bool allowNegativeInfinity)
        {
            double _topLeft = cornerRadius.TopLeft;
            double _topRight = cornerRadius.TopRight;
            double _bottomLeft = cornerRadius.BottomLeft;
            double _bottomRight = cornerRadius.BottomRight;

            if (allowNegative == false)
            {
                if (_topLeft < 0d || _topRight < 0d || _bottomLeft < 0d || _bottomRight < 0d)
                {
                    return (false);
                }
            }

            if (allowNaN == false)
            {
                if (Double.IsNaN(_topLeft) || Double.IsNaN(_topRight) || Double.IsNaN(_bottomLeft) || Double.IsNaN(_bottomRight))
                {
                    return (false);
                }
            }

            if (allowPositiveInfinity == false)
            {
                if (Double.IsPositiveInfinity(_topLeft) || Double.IsPositiveInfinity(_topRight) || Double.IsPositiveInfinity(_bottomLeft) || Double.IsPositiveInfinity(_bottomRight))
                {
                    return (false);
                }
            }

            if (allowNegativeInfinity == false)
            {
                if (Double.IsNegativeInfinity(_topLeft) || Double.IsNegativeInfinity(_topRight) || Double.IsNegativeInfinity(_bottomLeft) || Double.IsNegativeInfinity(_bottomRight))
                {
                    return (false);
                }
            }

            return (true);
        }
    }
}
