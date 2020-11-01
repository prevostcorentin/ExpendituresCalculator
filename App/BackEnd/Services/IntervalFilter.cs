using ExpendituresCalculator.Services;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;

namespace ExpendituresCalculator.Services
{
    internal class IntervalFilter<T> : IFilter<T>
    {
        public IEnumerable<T> Data { get; set; }
        public IEnumerable<FilterCriteria> Criterias { get; set; }
        public IEnumerable<IntervalledFilterCriteria> IntervalledCriterias 
        { 
            get
            {
                IEnumerable<IntervalledFilterCriteria> aggregatedCriterias = FilterCriteriaAggregator.AggregateFilterCriterias(Criterias);
                return aggregatedCriterias;
            }
        }

        public IEnumerable<T> Result
        {
            get
            {
                Queue<T> result = new Queue<T>();
                foreach (T entity in Data)
                {
                    if (IsEntityMatching(entity))
                    {
                        result.Enqueue(entity);
                    }
                }
                return result;
            }
        }

        public bool IsEntityMatching(T entity)
        {
            foreach (IntervalledFilterCriteria intervalledCriteria in IntervalledCriterias)
            {
                if (!Utils.Reflection.IsEntityPropertyBetween(intervalledCriteria.Name, intervalledCriteria.Min, intervalledCriteria.Max, entity))
                {
                    return false;
                }
            }
            return true;
        }
    }
}