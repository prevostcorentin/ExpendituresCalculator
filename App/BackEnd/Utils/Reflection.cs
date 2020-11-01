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
            bool isValueBetween = IsPropertyMatching(ValueBetween, propertyName, entity, min, max);

            return isValueBetween;
        }

        internal static bool IsEntityPropertyEqual<T>(string propertyName, object value, T entity)
        {
            if (!EntityContainsProperty(entity, propertyName))
            {
                throw new Exceptions.InvalidCriteriaException(entity.GetType(), propertyName, entity);
            }
            bool areValueEqual = IsPropertyMatching(EntityEquals, propertyName, entity, value);

            return areValueEqual;
        }

        public static bool EntityContainsProperty<T>(T entity, string propertyName)
        {
            return entity.GetType().GetProperties()
                         .Select(p => p.Name.ToLower())
                         .Any(name => name == propertyName.ToLower());
        }
        public static bool IsPropertyMatching(Func<dynamic, Object[], bool> predicate, String propertyName, Object entity, params Object[] matches)
        {
            propertyName = Char.ToUpper(propertyName[0]) + propertyName.Substring(1);
            object propertyValue = entity.GetType().GetProperty(propertyName).GetValue(entity);

            return predicate.Invoke(propertyValue, matches);
        }

        public static bool ValueBetween(dynamic value, params Object[] objects)
        {
            dynamic[] typedValues = AdaptTypes(value.GetType(), objects);
            Array.Sort(typedValues);

            return (typedValues[0] <= value) && (value <= typedValues.Last());
        }

        private static bool EntityEquals(dynamic value, params Object[] objects)
        {
            dynamic[] typedValues = AdaptTypes(value.GetType(), objects);

            return typedValues.All(val => val == value);
        }

        public static dynamic[] AdaptTypes(Type adaptedType, params Object[] objects)
        {
            Queue<dynamic> typedValues = new Queue<dynamic>();
            for (int i = 0; i < objects.Length; i++)
            {
                dynamic untyped = objects[i];
                if (untyped == null)
                {
                    // Activator.CreateInstance static method returns the default value for a given type
                    // ref: https://docs.microsoft.com/en-us/dotnet/api/system.activator.createinstance?view=netcore-3.1#System_Activator_CreateInstance_System_Type_
                    untyped = Activator.CreateInstance(adaptedType);
                }
                dynamic typed = Convert.ChangeType(untyped, adaptedType);
                typedValues.Enqueue(typed);
            }

            return typedValues.ToArray();
        }
    }
}
