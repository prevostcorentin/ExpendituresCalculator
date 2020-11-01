using System;

namespace ExpendituresCalculator.Services
{
    public class FilterCriteria
    {
        public String Name { get; set; }
        public Object Value { get; set; }

        public override String ToString() => $"[{Name}]";
    }
}
