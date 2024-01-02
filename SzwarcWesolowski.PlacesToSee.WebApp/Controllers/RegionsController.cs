using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using SzwarcWesolowski.PlacesToSee.Interfaces;
using SzwarcWesolowski.PlacesToSee.WebApp.Models;
using SzwarcWesolowski.PlacesToSee.BLC;

namespace SzwarcWesolowski.PlacesToSee.WebApp.Controllers
{
    public class RegionsController : Controller
    {
        private readonly IDAO _context;

        public RegionsController()
        {
            _context = ExternalDAOManager.GetDAOInstance();
        }

        // GET: Regions
        public IActionResult Index()
        {
            return View(_context.GetRegions().ToList());
        }

        // GET: Regions/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var region = _context.GetRegions()
                .FirstOrDefault(m => m.Id == id);
            if (region == null)
            {
                return NotFound();
            }

            return View(region);
        }

        // GET: Regions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Regions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,PhotoUrl")] Region regionModel)
        {
            var region = _context.CreateRegion(regionModel.Name, regionModel.PhotoUrl);
            if (ModelState.IsValid)
            {
                _context.AddRegion(region);
                return RedirectToAction(nameof(Index));
            }
            return View(regionModel);
        }

        // GET: Regions/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var region = _context.GetRegions()
                .FirstOrDefault(m => m.Id == id);
            if (region == null)
            {
                return NotFound();
            }
            return View(new Region(region));
        }

        // POST: Regions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,PhotoUrl")] Region regionModel)
        {
            if (id != regionModel.Id)
            {
                return NotFound();
            }

            var region = _context.GetRegions()
                .FirstOrDefault(m => m.Id == id)!;
            if (ModelState.IsValid)
            {
                try
                {
                    regionModel.ApplyTo(region);
                    _context.UpdateRegion(region);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegionExists(region.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(regionModel);
        }

        // GET: Regions/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var region = _context.GetRegions()
                .FirstOrDefault(m => m.Id == id);
            if (region == null)
            {
                return NotFound();
            }

            return View(region);
        }

        // POST: Regions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var region = _context.GetRegions()
                .FirstOrDefault(m => m.Id == id);
            if (region != null)
            {
                _context.RemoveRegion(region);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool RegionExists(int id)
        {
            return _context.GetRegions().Any(e => e.Id == id);
        }
    }
}
