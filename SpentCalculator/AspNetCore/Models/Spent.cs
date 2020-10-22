using System;
using System.Collections.Generic;

namespace SpentCalculator.Models
{
    public class Spent
    {
        public Int32 SpentId { get; set; }
        public Decimal Amount { get; set; }
        public String Name { get; set; }
        public DateTime DateTime { get; set; }
    }
}
