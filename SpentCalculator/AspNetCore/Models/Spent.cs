using System;
using System.ComponentModel.DataAnnotations;

namespace SpentCalculator.Models
{
    public class Spent
    {
        public Guid SpentId { get; set; }
        public Single Amount { get; set; }
        [Required]
        public String Name { get; set; }
        public DateTime DateTime { get; set; }
    }
}
