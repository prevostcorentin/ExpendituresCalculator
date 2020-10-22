using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft;
using Newtonsoft.Json.Linq;
using SpentCalculator.Services;
using SpentCalculator.Models;
using Newtonsoft.Json;

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
            var filter = new Filter<Spent> { Criterias = criterias };
            var spentFilterService = new FilterService<Spent>(filter);
            IEnumerable<Spent> filteredResults = spentFilterService.ApplyFilter(_context.Spents);
            return filteredResults;
        }

        [HttpPut]
        public void AddSpent([FromBody] Spent newSpent)
        {
            _context.Spents.Add(newSpent);
        }
    }
}
