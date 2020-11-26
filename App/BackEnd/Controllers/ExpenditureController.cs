using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ExpendituresCalculator.Services;
using ExpendituresCalculator.Models;

namespace ExpendituresCalculator.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ExpenditureController : ControllerBase
    {
        private ExpendituresCalculatorDbContext _context;

        public ExpenditureController(ExpendituresCalculatorDbContext injectedDbContext)
        {
            _context = injectedDbContext;
        }

        [HttpGet]
        public IEnumerable<Expenditure> GetAllSpents()
        {
            return _context.Expenditures;
        }

        [HttpPost]
        public IEnumerable<Expenditure> FilterSpents(IEnumerable<FilterCriteria> criterias)
        {
            IEnumerable<Expenditure> filteredResults;
            if (criterias.Count() == 0)
            {
                filteredResults = _context.Expenditures;
            }
            else
            {
                var filter = FilterFactory<Expenditure>.Create(criterias);
                var spentFilterService = new FilterService<Expenditure>(filter);
                filteredResults = spentFilterService.ApplyFilter(_context.Expenditures);
            }
            return filteredResults;

        }

        [HttpPut]
        public void AddSpent(Expenditure newSpent)
        {
            if (_context.Expenditures.Any(s => s.ExpenditureId == newSpent.ExpenditureId))
            {
                _context.Expenditures.Update(newSpent);
            }
            else
            {
                _context.Expenditures.Add(newSpent);
            }
            _context.SaveChanges();
        }
    }
}
