using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SpentCalculator.Services;
using SpentCalculator.Models;

namespace SpentCalculator.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SpentController : ControllerBase
    {
        private SpentDbContext _context;

        public SpentController(SpentDbContext injectedDbContext)
        {
            _context = injectedDbContext;
        }

        [HttpGet]
        public IEnumerable<Spent> GetAllSpents()
        {
            return _context.Spents;
        }

        [HttpPost]
        public IEnumerable<Spent> FilterSpents([FromBody] IEnumerable<FilterCriteria> criterias)
        {
            IEnumerable<Spent> filteredResults; 
            if (criterias.Count() == 0)
            {
                filteredResults = _context.Spents;
            }
            else
            {
                var filter = new Filter<Spent> { Criterias = criterias };
                var spentFilterService = new FilterService<Spent>(filter);
                filteredResults = spentFilterService.ApplyFilter(_context.Spents);
            }
            return filteredResults;

        }

        [HttpPut]
        public void AddSpent([FromBody] Spent newSpent)
        {
            _context.Spents.Add(newSpent);
        }
    }
}
