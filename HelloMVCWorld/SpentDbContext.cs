using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpendituresCalculator.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpendituresCalculator
{
    public class SpentDbContext : DbContext
    {
        public SpentDbContext(DbContextOptions<SpentDbContext> options)
            : base(options)
        {
        }

        public SpentDbContext()
        {
        }

        public DbSet<Spent> Spents { get; set; }
    }
}
