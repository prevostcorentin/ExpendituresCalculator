using ExpendituresCalculator.Models;
using ExpendituresCalculator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpendituresCalculator.Services
{
    public class FilterService
    {
        private Filter<Spent> _filter;

        public FilterService(Filter<Spent> injectedFilter)
        {
            _filter = injectedFilter;
        }

        public IEnumerable<Spent> ApplyFilter(ICollection<FilterCriteria> criterias, IEnumerable<Spent> data)
        {
            _filter.Criterias = criterias;
            _filter.Data = data;
            return _filter.Result;
        }
    }
}
