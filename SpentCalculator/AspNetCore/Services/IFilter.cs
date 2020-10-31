using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SpentCalculator.Services
{
    public struct FilterCriteria
    {
        public String Name { get; set; }
        public Object Value { get; set; }

        public override String ToString() => $"[{Name}]";
    }
        
    public interface IFilter<T>
    {
        public IEnumerable<T> Data { get; set; }
        public IEnumerable<FilterCriteria> Criterias { get; set; }
        public abstract IEnumerable<T> Result { get; }
    }
}
