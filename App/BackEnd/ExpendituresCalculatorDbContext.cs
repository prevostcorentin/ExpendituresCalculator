using ExpendituresCalculator.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpendituresCalculator
{
    public class ExpendituresCalculatorDbContext : DbContext
    {
        public ExpendituresCalculatorDbContext(DbContextOptions<ExpendituresCalculatorDbContext> options)
            : base(options)
        {
        }

        public ExpendituresCalculatorDbContext()
        {
        }

        public DbSet<Expenditure> Expenditures { get; set; }
    }
}
