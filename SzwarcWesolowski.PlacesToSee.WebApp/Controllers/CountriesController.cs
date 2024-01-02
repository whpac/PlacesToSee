using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using SzwarcWesolowski.PlacesToSee.BLC;
using SzwarcWesolowski.PlacesToSee.Interfaces;
using SzwarcWesolowski.PlacesToSee.WebApp.Models;

namespace SzwarcWesolowski.PlacesToSee.WebApp.Controllers
{
    public class CountriesController : Controller
    {
        private readonly IDAO _context;

        public CountriesController()
        {
            _context = ExternalDAOManager.GetDAOInstance();
        }

        // GET: Countries
        public IActionResult Index()
        {
            return View(_context.GetCountries().ToList());
        }

        // GET: Countries/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = _context.GetCountries()
                .FirstOrDefault(m => m.Id == id);
            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

        // GET: Countries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Countries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,FlagUrl")] Country countryModel)
        {
            var country = _context.CreateCountry(countryModel.Name, countryModel.FlagUrl);
            if (ModelState.IsValid)
            {
                _context.AddCountry(country);
                return RedirectToAction(nameof(Index));
            }
            return View(countryModel);
        }

        // GET: Countries/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = _context.GetCountries()
                .FirstOrDefault(m => m.Id == id);
            if (country == null)
            {
                return NotFound();
            }
            return View(new Country(country));
        }

        // POST: Countries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,FlagUrl")] Country countryModel)
        {
            if (id != countryModel.Id)
            {
                return NotFound();
            }

            var country = _context.GetCountries()
                .FirstOrDefault(m => m.Id == id)!;
            if (ModelState.IsValid)
            {
                try
                {
                    countryModel.ApplyTo(country);
                    _context.UpdateCountry(country);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CountryExists(country.Id))
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
            return View(countryModel);
        }

        // GET: Countries/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = _context.GetCountries()
                .FirstOrDefault(m => m.Id == id);
            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

        // POST: Countries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var country = _context.GetCountries()
                .FirstOrDefault(m => m.Id == id);
            if (country != null)
            {
                _context.RemoveCountry(country);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool CountryExists(int id)
        {
            return _context.GetCountries().Any(e => e.Id == id);
        }
    }
}
