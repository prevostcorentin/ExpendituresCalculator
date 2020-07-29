using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloMVCWorld.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Controllers.HelloMVCWorld
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            var spent = new List<Spent> {
                new Spent { Amount = 10, Name = "Random" },
                new Spent { Amount = 10, Name = "Random" },
                new Spent { Amount = 10, Name = "Random" },
                new Spent { Amount = 10, Name = "Random" },
            };
            return View(spent);
        }
    }
}
