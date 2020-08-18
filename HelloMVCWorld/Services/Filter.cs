using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace EasySpents.Services
{
    public struct FilterCriteria
    {
        public String Name { get; set; }
        public object Value { get; set; }
    }

    public class Filter<T>
    {
        public IEnumerable<T> Data { get; set; }
        public ICollection<FilterCriteria> Criterias { get; set; }
        public IEnumerable<T> Result
        { 
            get
            {
                var matchingSet = new Queue<T>();
                foreach (T filterable in Data)
                {
                    if (IsMatchingObject(filterable))
                    {
                        matchingSet.Enqueue(filterable);
                    }
                }
                return matchingSet;
            }
        }

        public bool IsMatchingObject(object filterable)
        {
            var filterablePropertiesNames = filterable.GetType().GetProperties()
                                                                .Select(p => p.Name.ToLower());
            foreach (FilterCriteria criteria in Criterias)
            {
                if (filterablePropertiesNames.Contains(criteria.Name.ToLower()))
                {
                    object propertyValue = filterable.GetType().GetProperty(criteria.Name).GetValue(filterable);
                    Type propertyType = propertyValue.GetType();
                    if (criteria.Value == propertyValue)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
