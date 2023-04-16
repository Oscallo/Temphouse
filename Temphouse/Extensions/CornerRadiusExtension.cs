using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Temphouse.Extensions
{
    public static class CornerRadiusExtension
    {
        public static bool IsValid(this CornerRadius cornerRadius, bool allowNegative, bool allowNaN, bool allowPositiveInfinity, bool allowNegativeInfinity)
        {
            double _topLeft = cornerRadius.TopLeft;
            double _topRight = cornerRadius.TopRight;
            double _bottomLeft = cornerRadius.BottomLeft;
            double _bottomRight = cornerRadius.BottomRight;


            if (!allowNegative)
            {
                if (_topLeft < 0d || _topRight < 0d || _bottomLeft < 0d || _bottomRight < 0d)
                {
                    return (false);
                }
            }

            if (!allowNaN)
            {
                if (Double.IsNaN(_topLeft) || Double.IsNaN(_topRight) || Double.IsNaN(_bottomLeft) || Double.IsNaN(_bottomRight))
                {
                    return (false);
                }
            }

            if (!allowPositiveInfinity)
            {
                if (Double.IsPositiveInfinity(_topLeft) || Double.IsPositiveInfinity(_topRight) || Double.IsPositiveInfinity(_bottomLeft) || Double.IsPositiveInfinity(_bottomRight))
                {
                    return (false);
                }
            }

            if (!allowNegativeInfinity)
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
