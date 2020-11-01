using System.Collections.Generic;

namespace ExpendituresCalculator.Services
{
    public interface IFilter<T>
    {
        public IEnumerable<T> Data { get; set; }
        public IEnumerable<FilterCriteria> Criterias { get; set; }
        public abstract IEnumerable<T> Result { get; }
        public abstract bool IsEntityMatching(T entity);
    }
}
