using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpentCalculator.Services
{
    public class FilterAggregator<T> : IFilter<T>
    {
        public IEnumerable<T> Data { get; set; }
        public IEnumerable<FilterCriteria> Criterias { get; set; }
        public Queue<IFilter<T>> Filters { get; set; } = new Queue<IFilter<T>>();
        public IEnumerable<T> Result
        {
            get
            {
                IEnumerable<T> resultingData = Data;
                foreach (IFilter<T> filter in Filters)
                {
                    filter.Data = resultingData;
                    resultingData = filter.Result.Intersect(resultingData);
                }
                return resultingData;
            }
        }
    }
}
