using System;

namespace ExpendituresCalculator.Services
{
    public class IntervalledFilterCriteria : FilterCriteria
    {
        public dynamic Max { get; set; }
        public dynamic Min { get; set; }
    }
}