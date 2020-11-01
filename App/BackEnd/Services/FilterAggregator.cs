using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpendituresCalculator.Services  
{
    public class FilterAggregator<T> : IFilter<T>
    {
        public IEnumerable<T> Data { get; set; }
        public IEnumerable<FilterCriteria> Criterias
        {
            get
            { 
                Queue<FilterCriteria> aggregatedCriterias = new Queue<FilterCriteria>();
                foreach (List<FilterCriteria> criterias in Filters.Select(filter => filter.Criterias).ToList())
                {
                    criterias.ForEach(c => aggregatedCriterias.Enqueue(c));
                }
                return aggregatedCriterias;
            }
            set
            {
                IEnumerable<FilterCriteria> intervalledCriterias = value.Where(FilterFactory<T>.ContainsMaxOrMin);
                IEnumerable<FilterCriteria> strictCriterias = value.Except(intervalledCriterias);
                if (intervalledCriterias.Count() > 0)
                {
                    Filters.Enqueue(new IntervalFilter<T> { Criterias = intervalledCriterias });
                }
                if (strictCriterias.Count() > 0)
                {
                    Filters.Enqueue(new StrictFilter<T> { Criterias = strictCriterias });
                }
            }
        }

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

        public bool IsEntityMatching(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
