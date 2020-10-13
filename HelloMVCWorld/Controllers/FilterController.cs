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
using ExpendituresCalculator.Services;
using ExpendituresCalculator.Models;
using Newtonsoft.Json;

namespace ExpendituresCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilterController : ControllerBase
    {
        private SpentDbContext _context;

        public FilterController(SpentDbContext injectedDbContext)
        {
            _context = injectedDbContext;
        }

        [HttpPost]
        [Route("Spents")]
        public String FilterSpents([FromBody] JObject json)
        {
            try
            {
                var filter = new Filter<Spent>();
                filter.Criterias = JsonTransformer.JObjectToFilterCriterias(json);
                var spentFilterService = new FilterService<Spent>(filter);
                IEnumerable<Spent> filteredResults = spentFilterService.ApplyFilter(_context.Spents);
                String resultJson = JsonTransformer.SerializeObject(filteredResults);
                return resultJson;
            }
            catch(Exceptions.InvalidCriteriaException)
            {
                String resultJson = JsonTransformer.SerializeObject(_context.Spents);
                return resultJson;
            }
        }
    }
}
