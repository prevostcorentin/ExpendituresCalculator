using Microsoft.AspNetCore.Mvc.Diagnostics;
using ExpendituresCalculator.Services;
using System.Collections.Generic;
using System.Linq;

namespace ExpendituresCalculator.Services
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
                foreach (T entity in Data)
                {
                    if (IsEntityMatching(entity))
                    {
                        matchingSet.Enqueue(entity);
                    }
                }
                return matchingSet;
            }
        }

        public bool IsEntityMatching(T entity)
        {
            foreach (FilterCriteria criteria in Criterias)
            {
                if (!Utils.Reflection.IsEntityPropertyEqual(criteria.Name, criteria.Value, entity))
                {
                    return false;
                }
            }
            return true;
        }
    }
}