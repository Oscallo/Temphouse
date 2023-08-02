using System;
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
            double topLeft = cornerRadius.TopLeft;
            double topRight = cornerRadius.TopRight;
            double bottomLeft = cornerRadius.BottomLeft;
            double bottomRight = cornerRadius.BottomRight;

            if (allowNegative == false)
            {
                if (topLeft < 0d || topRight < 0d || bottomLeft < 0d || bottomRight < 0d)
                {
                    return (false);
                }
            }

            if (allowNaN == false)
            {
                if (Double.IsNaN(topLeft) || Double.IsNaN(topRight) || Double.IsNaN(bottomLeft) || Double.IsNaN(bottomRight))
                {
                    return (false);
                }
            }

            if (allowPositiveInfinity == false)
            {
                if (Double.IsPositiveInfinity(topLeft) || Double.IsPositiveInfinity(topRight) || Double.IsPositiveInfinity(bottomLeft) || Double.IsPositiveInfinity(bottomRight))
                {
                    return (false);
                }
            }

            if (allowNegativeInfinity == false)
            {
                if (Double.IsNegativeInfinity(topLeft) || Double.IsNegativeInfinity(topRight) || Double.IsNegativeInfinity(bottomLeft) || Double.IsNegativeInfinity(bottomRight))
                {
                    return (false);
                }
            }

            return (true);
        }
    }
}
