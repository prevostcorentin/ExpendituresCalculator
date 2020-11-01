using System;
using System.ComponentModel.DataAnnotations;

namespace ExpendituresCalculator.Models
{
    public class Expenditure
    {
        public Guid ExpenditureId { get; set; }
        public Single Amount { get; set; }
        [Required]
        public String Name { get; set; }
        public DateTime DateTime { get; set; }
    }
}
