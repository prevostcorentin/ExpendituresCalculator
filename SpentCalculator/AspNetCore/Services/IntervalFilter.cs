using SpentCalculator.Services;
using System.Collections.Generic;

namespace SpentCalculator.Services
{
    internal class IntervalFilter<T> : IFilter<T>
    {
        public IEnumerable<T> Data { get; set; }
        public IEnumerable<FilterCriteria> Criterias { get; set; }

        public IEnumerable<T> Result
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }
    }
}