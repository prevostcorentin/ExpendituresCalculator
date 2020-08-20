using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpentCalculator.Models;
using Microsoft.EntityFrameworkCore;

namespace SpentCalculator
{
    public class SpentContext : DbContext
    {
        public SpentContext(DbContextOptions<SpentContext> options)
            : base(options)
        {
        }

        public SpentContext()
        {
        }

        public DbSet<Spent> Spents { get; set; }
    }
}
