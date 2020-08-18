using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using EasySpents;
using EasySpents.Models;
using EasySpents.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HelloMVCWorld.Controllers
{
    public class SpentController : Controller
    {
        private SpentContext _context;
        private Services.FilterService _filterService;

        public SpentController(SpentContext injectedContext, Services.FilterService injectedFilterService)
        {
            _context = injectedContext;
            _filterService = injectedFilterService;
        }

        // GET: Spent
        public ActionResult Index()
        {
            ICollection<FilterCriteria> criterias = new List<FilterCriteria>
            {
                new FilterCriteria { Name = "Name", Value = "Socks" }
            };
            IEnumerable<Spent> filteredSpents = _filterService.Apply(criterias, _context.Spents);
            return View(filteredSpents);
        }

        // GET: Spent/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Spent/Create
        public ActionResult Create()
        {
            return View();
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
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Spent/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
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