using SpentCalculator.Models;
using SpentCalculator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpentCalculator.Services
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
            TypeFilter();
            _filter.Data = data;
            return _filter.Result;
        }

        private void TypeFilter()
        {
            List<FilterCriteria> typedCriterias = new List<FilterCriteria>();
            foreach(var criteria in _filter.Criterias)
            {
                typedCriterias.Add(new FilterCriteria { Name = criteria.Name, Value = JsonTransformer.GetTypedFilterCriteriaValue(criteria) });
            }
            _filter.Criterias = typedCriterias;
        }
    }
}
