using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SpentCalculator.Utils
{
    public static class Reflection
    {
        public new static bool Equals(object x, object y)
        {
            Type xType = x.GetType();
            Type yType = y.GetType();
            dynamic typedX = Convert.ChangeType(x, xType);
            dynamic typedY = Convert.ChangeType(y, yType);
            if(xType != yType)
            {
                throw new StrongTypingException($"x is of type {xType} and y is of type {yType}");
            }

            if (typedY == typedX)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
