using ExpendituresCalculator.Models;
using ExpendituresCalculator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpendituresCalculator.Services
{
    public class FilterService<T>
    {
        private Filter<T> _filter;

        public FilterService(Filter<T> injectedFilter)
        {
            _filter = injectedFilter;
        }

        public IEnumerable<T> ApplyFilter(IEnumerable<T> data)
        {
            _filter.Data = data;
            return _filter.Result;
        }
    }
}
