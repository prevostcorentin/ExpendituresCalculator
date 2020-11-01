using ExpendituresCalculator.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ExpendituresCalculator.Utils
{
    public static class Reflection
    {
        internal static bool IsEntityPropertyBetween<T>(string propertyName, object min, object max, T entity)
        {
            if (!EntityContainsProperty(entity, propertyName))
            {
                throw new Exceptions.InvalidCriteriaException(entity.GetType(), propertyName, entity);
            }

            Object propertyValue = ExtractEntityPropertyValueFromName(entity, propertyName);
            bool isValueBetween = ValueBetween(propertyValue, min, max);
            return isValueBetween;
        }

        internal static bool IsEntityPropertyEqual<T>(string propertyName, object value, T entity)
        {
            if (!EntityContainsProperty(entity, propertyName))
            {
                throw new Exceptions.InvalidCriteriaException(entity.GetType(), propertyName, entity);
            }

            object propertyValue = ExtractEntityPropertyValueFromName(entity, propertyName);
            bool areValueEqual = EntityEquals(propertyValue, value);
            return areValueEqual;
        }

        private static object ExtractEntityPropertyValueFromName<T>(T entity, string propertyName)
        {
            propertyName = Char.ToUpper(propertyName[0]) + propertyName.Substring(1);
            object propertyValue = entity.GetType().GetProperty(propertyName).GetValue(entity);
            return propertyValue;
        }

        public static bool EntityContainsProperty<T>(T entity, string propertyName)
        {
            return entity.GetType().GetProperties()
                         .Select(p => p.Name.ToLower())
                         .Any(name => name == propertyName.ToLower());
        }


        public static bool EntityEquals(Object x, Object y)
        {
            var typedValues = AdaptTypes(x.GetType(), x, y);
            return typedValues[0] == typedValues[1];
        }

        public static bool ValueBetween(dynamic value, Object x, Object y)
        {
            dynamic[] typedValues = AdaptTypes(value.GetType(), x, y);
            Array.Sort(typedValues);
            return (typedValues[0] <= value) && (value <= typedValues[1]);
        }

        public static dynamic[] AdaptTypes(Type adaptedType, params Object[] objects)
        {
            Queue<dynamic> typedValues = new Queue<dynamic>(); ;
            for (int i = 0; i < objects.Length; i++)
            {
                dynamic untyped = objects[i];
                if (untyped == null)
                {
                    untyped = Activator.CreateInstance(adaptedType);
                }
                dynamic typed = Convert.ChangeType(untyped, adaptedType);
                typedValues.Enqueue(typed);
            }
            return typedValues.ToArray();
        }
    }
}
