using System;

namespace SpentCalculator.Models
{
    public class Spent
    {
        public Guid SpentId { get; set; }
        public Decimal Amount { get; set; }
        public String Name { get; set; }
        public DateTime DateTime { get; set; }
    }
}
