using SpentCalculator.Services;
using System.Collections.Generic;
using System.Linq;

namespace SpentCalculator.Services
{
    internal class StrictFilter<T> : IFilter<T>
    {
        public IEnumerable<T> Data { get; set; }
        public IEnumerable<FilterCriteria> Criterias { get; set; }

        public IEnumerable<T> Result
        {
            get
            {
                var matchingSet = new Queue<T>();
                foreach (T filterable in Data)
                {
                    if (IsObjectMatching(filterable))
                    {
                        matchingSet.Enqueue(filterable);
                    }
                }
                return matchingSet;
            }
        }

        private bool IsObjectMatching(object filterable)
        {
            foreach (FilterCriteria criteria in Criterias)
            {
                if (IsCriteriaMatchesFilterable(criteria, filterable))
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsCriteriaMatchesFilterable(FilterCriteria criteria, object filterable)
        {
            bool filterableContainsCriteria = filterable.GetType().GetProperties()
                                                        .Select(p => p.Name.ToLower())
                                                        .Any(name => name == criteria.Name.ToLower());
            if (!filterableContainsCriteria)
            {
                throw new Exceptions.InvalidCriteriaException(filterable.GetType(), criteria);
            }

            object propertyValue = filterable.GetType().GetProperty(criteria.Name).GetValue(filterable);
            if (Utils.Reflection.Equals(criteria.Value, propertyValue))
            {
                return true;
            }
            return false;
        }
    }
}