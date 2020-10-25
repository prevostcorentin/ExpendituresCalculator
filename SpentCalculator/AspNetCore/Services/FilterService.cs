using System.Collections.Generic;
using System.Text.Json;

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
            TransformCriterias();
            _filter.Data = data;
            return _filter.Result;
        }

        private void TransformCriterias()
        {
            List<FilterCriteria> typedCriterias = new List<FilterCriteria>();
            foreach (FilterCriteria criteria in _filter.Criterias)
            {
                FilterCriteria singleCriteria = new FilterCriteria
                {
                    Name = criteria.Name,
                    Value = JsonTransformer.JsonElementToTypedValue((JsonElement)criteria.Value)
                };
                typedCriterias.Add(singleCriteria);
            }
            _filter.Criterias = typedCriterias;
        }
    }
}
