using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using EF = SzwarcWesolowski.PlacesToSee.DAO.EntityFramework;
using SzwarcWesolowski.PlacesToSee.Interfaces;
using SzwarcWesolowski.PlacesToSee.WebApp.Models;

namespace SzwarcWesolowski.PlacesToSee.WebApp.Controllers
{
    public class PlacesController : Controller
    {
        private readonly IDAO _context;

        public PlacesController()
        {
            _context = new EF.EntityFrameworkDatabase();
        }

        // GET: Places
        public IActionResult Index()
        {
            return View(_context.GetPlaces().ToList());
        }

        // GET: Places/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var place = _context.GetPlaces()
                .FirstOrDefault(m => m.Id == id);
            if (place == null)
            {
                return NotFound();
            }

            return View(new Place(place, _context));
        }

        // GET: Places/Create
        public IActionResult Create()
        {
            return View(new Place() { Dao = _context });
        }

        // POST: Places/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,PlaceType,Latitude,Longitude,CountryId,RegionId")] Place placeModel)
        {
            if (ModelState.IsValid)
            {
                var country = _context.GetCountries().FirstOrDefault(c => c.Id ==  placeModel.CountryId);
                var region = _context.GetRegions().FirstOrDefault(r => r.Id ==  placeModel.RegionId);
                var place = _context.CreatePlace(placeModel.Name, placeModel.PlaceType, placeModel.Location,
                    country, region);

                _context.AddPlace(place);
                return RedirectToAction(nameof(Index));
            }
            return View(placeModel);
        }

        // GET: Places/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var place = _context.GetPlaces()
                .FirstOrDefault(m => m.Id == id);
            if (place == null)
            {
                return NotFound();
            }
            return View(new Place(place, _context));
        }

        // POST: Places/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,PlaceType,Latitude,Longitude,CountryId,RegionId")] Place placeModel)
        {
            placeModel.Dao = _context;
            if (id != placeModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var place = _context.GetPlaces()
                    .FirstOrDefault(m => m.Id == id)!;
                try
                {
                    var country = _context.GetCountries().FirstOrDefault(c => c.Id == placeModel.CountryId);
                    var region = _context.GetRegions().FirstOrDefault(r => r.Id == placeModel.RegionId);
                    placeModel.Country = country;
                    placeModel.Region = region;

                    placeModel.ApplyTo(place);
                    _context.UpdatePlace(place);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlaceExists(place.Id))
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
            return View(placeModel);
        }

        // GET: Places/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var place = _context.GetPlaces()
                .FirstOrDefault(m => m.Id == id);
            if (place == null)
            {
                return NotFound();
            }

            return View(place);
        }

        // POST: Places/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var place = _context.GetPlaces()
                .FirstOrDefault(m => m.Id == id);
            if (place != null)
            {
                _context.RemovePlace(place);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool PlaceExists(int id)
        {
            return _context.GetPlaces().Any(e => e.Id == id);
        }
    }
}
