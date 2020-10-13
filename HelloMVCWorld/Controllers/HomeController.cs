using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpendituresCalculator;
using ExpendituresCalculator.Models;
using ExpendituresCalculator.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Controllers.HelloMVCWorld
{
    public class HomeController : Controller
    {
        private SpentDbContext _context;

        public HomeController(SpentDbContext injectedContext)
        {
            _context = injectedContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
