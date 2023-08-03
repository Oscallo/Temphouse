using System.Windows;

namespace CoreLand.UI.Standart.Extensions.StructExtensions
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
        /// <param name="allowNaN">Возможность установки <seealso cref="double.NaN"/></param>
        /// <param name="allowPositiveInfinity">Возможность установки <seealso cref="double.PositiveInfinity"/></param>
        /// <param name="allowNegativeInfinity">Возможность установки <seealso cref="double.NegativeInfinity"/></param>
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
                    return false;
                }
            }

            if (allowNaN == false)
            {
                if (double.IsNaN(topLeft) || double.IsNaN(topRight) || double.IsNaN(bottomLeft) || double.IsNaN(bottomRight))
                {
                    return false;
                }
            }

            if (allowPositiveInfinity == false)
            {
                if (double.IsPositiveInfinity(topLeft) || double.IsPositiveInfinity(topRight) || double.IsPositiveInfinity(bottomLeft) || double.IsPositiveInfinity(bottomRight))
                {
                    return false;
                }
            }

            if (allowNegativeInfinity == false)
            {
                if (double.IsNegativeInfinity(topLeft) || double.IsNegativeInfinity(topRight) || double.IsNegativeInfinity(bottomLeft) || double.IsNegativeInfinity(bottomRight))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
