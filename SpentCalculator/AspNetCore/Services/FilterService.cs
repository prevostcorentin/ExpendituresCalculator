using System.Collections.Generic;
using System.Text.Json;

namespace SpentCalculator.Services
{
    public class FilterService<T>
    {
        private IFilter<T> _filter;

        public FilterService(IFilter<T> injectedFilter)
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
