using Microsoft.EntityFrameworkCore.Migrations.Operations;
using SpentCalculator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpentCalculator.Services
{
    public static class FilterFactory<T>
    {
        public static IFilter<T> Create(IEnumerable<FilterCriteria> criterias)
        {
            IEnumerable<FilterCriteria> intervalledCriterias = criterias.Where(ContainsMaxOrMin);
            IEnumerable<FilterCriteria> strictCriterias = criterias.Except(intervalledCriterias);
            FilterAggregator<T> filterAggregator = new FilterAggregator<T>();
            if (intervalledCriterias.Count() > 0)
            {
                filterAggregator.Filters.Enqueue(new IntervalFilter<T> 
                {
                    Criterias = intervalledCriterias 
                });
            }
            if (strictCriterias.Count() > 0)
            {
                filterAggregator.Filters.Enqueue(new StrictFilter<T>
                {
                    Criterias = strictCriterias
                });
            }
            return filterAggregator;
        }

        private static bool ContainsMaxOrMin(FilterCriteria criteria)
        {
            if (criteria.Name.ToLower().StartsWith("max") || criteria.Name.ToLower().StartsWith("min"))
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
