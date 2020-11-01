using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ExpendituresCalculator.Services;
using ExpendituresCalculator.Models;

namespace ExpendituresCalculator.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SpentController : ControllerBase
    {
        private ExpendituresCalculatorDbContext _context;

        public SpentController(ExpendituresCalculatorDbContext injectedDbContext)
        {
            _context = injectedDbContext;
        }

        [HttpGet]
        public IEnumerable<Expenditure> GetAllSpents()
        {
            return _context.Spents;
        }

        [HttpPost]
        public IEnumerable<Expenditure> FilterSpents(IEnumerable<FilterCriteria> criterias)
        {
            IEnumerable<Expenditure> filteredResults;
            if (criterias.Count() == 0)
            {
                filteredResults = _context.Spents;
            }
            else
            {
                var filter = FilterFactory<Expenditure>.Create(criterias);
                var spentFilterService = new FilterService<Expenditure>(filter);
                filteredResults = spentFilterService.ApplyFilter(_context.Spents);
            }
            return filteredResults;

        }

        [HttpPut]
        public void AddSpent(Expenditure newSpent)
        {
            if (_context.Spents.Any(s => s.ExpenditureId == newSpent.ExpenditureId))
            {
                _context.Spents.Update(newSpent);
            }
            else
            {
                _context.Spents.Add(newSpent);
            }
            _context.SaveChanges();
        }
    }
}
