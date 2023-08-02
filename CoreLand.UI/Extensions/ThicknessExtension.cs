﻿using System;
using System.Windows;

namespace CoreLand.UI.Extensions
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
        /// <param name="allowNaN">Возможность установки <seealso cref="Double.NaN"/></param>
        /// <param name="allowPositiveInfinity">Возможность установки <seealso cref="Double.PositiveInfinity"/></param>
        /// <param name="allowNegativeInfinity">Возможность установки <seealso cref="Double.NegativeInfinity"/></param>
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
                if (Double.IsNaN(left) || Double.IsNaN(right) || Double.IsNaN(top) || Double.IsNaN(bottom))
                    return false;
            }

            if (allowPositiveInfinity == false)
            {
                if (Double.IsPositiveInfinity(left) || Double.IsPositiveInfinity(right) || Double.IsPositiveInfinity(top) || Double.IsPositiveInfinity(bottom))
                {
                    return false;
                }
            }

            if (allowNegativeInfinity == false)
            {
                if (Double.IsNegativeInfinity(left) || Double.IsNegativeInfinity(right) || Double.IsNegativeInfinity(top) || Double.IsNegativeInfinity(bottom))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
