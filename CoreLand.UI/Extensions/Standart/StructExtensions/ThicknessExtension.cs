using System.Windows;

namespace CoreLand.UI.Extensions.Standart.StructExtensions
{
    /// <summary>
    /// Класс расшринения <seealso cref="Thickness"/>
    /// </summary>
    public static class ThicknessExtension
    {
        /// <summary>
        /// Проверка на валидность <seealso cref="Thickness"/>
        /// <br/>
        /// <a href="https://referencesource.microsoft.com/#PresentationFramework/src/Framework/System/Windows/Thickness.cs,713ed3a783acf131">Ссылка на исходный код от Microsoft </a>
        /// </summary>
        /// <param name="thickness">Thickness в который внесены значения.</param>
        /// <param name="allowNegative">Возможность установки отрицательных значений.</param>
        /// <param name="allowNaN">Возможность установки <seealso cref="double.NaN"/></param>
        /// <param name="allowPositiveInfinity">Возможность установки <seealso cref="double.PositiveInfinity"/></param>
        /// <param name="allowNegativeInfinity">Возможность установки <seealso cref="double.NegativeInfinity"/></param>
        /// <returns>Валидность значений</returns>
        public static bool IsValid(this Thickness thickness, bool allowNegative, bool allowNaN, bool allowPositiveInfinity, bool allowNegativeInfinity)
        {
            double left = thickness.Left;
            double right = thickness.Right;
            double top = thickness.Top;
            double bottom = thickness.Bottom;

            if (allowNegative == false)
            {
                if (left < 0d || right < 0d || top < 0d || bottom < 0d)
                    return false;
            }

            if (allowNaN == false)
            {
                if (double.IsNaN(left) || double.IsNaN(right) || double.IsNaN(top) || double.IsNaN(bottom))
                    return false;
            }

            if (allowPositiveInfinity == false)
            {
                if (double.IsPositiveInfinity(left) || double.IsPositiveInfinity(right) || double.IsPositiveInfinity(top) || double.IsPositiveInfinity(bottom))
                {
                    return false;
                }
            }

            if (allowNegativeInfinity == false)
            {
                if (double.IsNegativeInfinity(left) || double.IsNegativeInfinity(right) || double.IsNegativeInfinity(top) || double.IsNegativeInfinity(bottom))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
