using Microsoft.EntityFrameworkCore.Migrations.Operations;
using ExpendituresCalculator.Exceptions;
using ExpendituresCalculator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpendituresCalculator.Services
{
    public static class FilterFactory<T>
    {
        public static IFilter<T> Create(IEnumerable<FilterCriteria> criterias)
        {
            IFilter<T> filter = null;
            if (criterias.Any(ContainsMaxOrMin))
            {
                filter = new FilterAggregator<T> { Criterias = criterias };
            }
            else
            {
                filter = new StrictFilter<T> { Criterias = criterias };
            }
            return filter;
        }

        public static bool ContainsMaxOrMin(FilterCriteria criteria)
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
