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
            dynamic typedY;

            if (xType != yType)
            {
                typedY = Convert.ChangeType(y, xType);
            }
            else
            {
                typedY = Convert.ChangeType(y, yType);
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
