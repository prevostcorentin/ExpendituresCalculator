using System;
using System.Collections.Generic;

namespace ExpendituresCalculator.Models
{
    public class Spent
    {
        public Guid SpentId { get; set; }
        public Double Amount { get; set; }
        public String Name { get; set; }
        public DateTime DateTime { get; set; }
    }
}
