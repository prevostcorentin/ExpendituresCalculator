using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using ExpendituresCalculator;
using ExpendituresCalculator.Models;
using ExpendituresCalculator.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpendituresCalculator.Controllers
{
    public class SpentController : Controller
    {
        private SpentDbContext _context;
        private Services.FilterService<Spent> _filterService;

        public SpentController(SpentDbContext injectedContext, Services.FilterService<Spent> injectedFilterService)
        {
            _context = injectedContext;
            _filterService = injectedFilterService;
        }

        // GET: Spent
        public ActionResult Index()
        {
            /*
            ICollection<FilterCriteria> criterias = new List<FilterCriteria>
            {
                new FilterCriteria { Name = "Name", Value = "Socks" }
            };
            IEnumerable<Spent> filteredSpents = _filterService.ApplyFilter(criterias, _context.Spents);
            */
            return View(_context.Spents);
        }

        // GET: Spent/Create
        public ActionResult Create()
        {
            Spent spent = new Spent
            {
                SpentId = 1000,
                Amount = 10.0M,
                Name = "Random",
                DateTime = DateTime.Now
            };
            _context.Add(spent);
            _context.SaveChanges();
            return View("Index", _context.Spents);
        }

        // POST: Spent/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Spent/Edit/5
        public ActionResult GetEdit(int id)
        {
            Spent editedSpent = _context.Spents.First(spent => spent.SpentId == id);
            return View(editedSpent);
                
        }

        // POST: Spent/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PostEdit(int id, IFormCollection collection)
        {
            try
            {
                Spent editedSpent = _context.Spents.First(spent => spent.SpentId == id);
                return View(new List<Spent> { editedSpent });
            }
            catch
            {
                return View();
            }
        }

        // GET: Spent/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Spent/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}