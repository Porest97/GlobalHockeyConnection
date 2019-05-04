using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GlobalHockeyConnections.Models;

namespace GlobalHockeyConnections.Controllers
{
    public class ShowCasesController : Controller
    {
        private readonly GlobalHockeyConnectionsContext _context;

        public ShowCasesController(GlobalHockeyConnectionsContext context)
        {
            _context = context;
        }

        // GET: ShowCases
        public async Task<IActionResult> Index()
        {
            var globalHockeyConnectionsContext = _context.ShowCase.Include(s => s.Location).Include(s => s.Person).Include(s => s.ShowCaseDescription);
            return View(await globalHockeyConnectionsContext.ToListAsync());
        }

        // GET: ShowCases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var showCase = await _context.ShowCase
                .Include(s => s.Location)
                .Include(s => s.Person)
                .Include(s => s.ShowCaseDescription)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (showCase == null)
            {
                return NotFound();
            }

            return View(showCase);
        }

        // GET: ShowCases/Create
        public IActionResult Create()
        {
            ViewData["LocationId"] = new SelectList(_context.Location, "Id", "LocationString");
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName");
            ViewData["ShowCaseDescriptionId"] = new SelectList(_context.ShowCaseDescription, "Id", "ShowCaseInfo");
            return View();
        }

        // POST: ShowCases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SwocaseName,LocationId,ShowCaseDescriptionId,PersonId")] ShowCase showCase)
        {
            if (ModelState.IsValid)
            {
                _context.Add(showCase);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocationId"] = new SelectList(_context.Location, "Id", "LocationString", showCase.LocationId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", showCase.PersonId);
            ViewData["ShowCaseDescriptionId"] = new SelectList(_context.ShowCaseDescription, "Id", "ShowCaseInfo", showCase.ShowCaseDescriptionId);
            return View(showCase);
        }

        // GET: ShowCases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var showCase = await _context.ShowCase.FindAsync(id);
            if (showCase == null)
            {
                return NotFound();
            }
            ViewData["LocationId"] = new SelectList(_context.Location, "Id", "LocationString", showCase.LocationId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", showCase.PersonId);
            ViewData["ShowCaseDescriptionId"] = new SelectList(_context.ShowCaseDescription, "Id", "ShowCaseInfo", showCase.ShowCaseDescriptionId);
            return View(showCase);
        }

        // POST: ShowCases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SwocaseName,LocationId,ShowCaseDescriptionId,PersonId")] ShowCase showCase)
        {
            if (id != showCase.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(showCase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShowCaseExists(showCase.Id))
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
            ViewData["LocationId"] = new SelectList(_context.Location, "Id", "LocationString", showCase.LocationId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", showCase.PersonId);
            ViewData["ShowCaseDescriptionId"] = new SelectList(_context.ShowCaseDescription, "Id", "ShowCaseInfo", showCase.ShowCaseDescriptionId);
            return View(showCase);
        }

        // GET: ShowCases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var showCase = await _context.ShowCase
                .Include(s => s.Location)
                .Include(s => s.Person)
                .Include(s => s.ShowCaseDescription)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (showCase == null)
            {
                return NotFound();
            }

            return View(showCase);
        }

        // POST: ShowCases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var showCase = await _context.ShowCase.FindAsync(id);
            _context.ShowCase.Remove(showCase);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShowCaseExists(int id)
        {
            return _context.ShowCase.Any(e => e.Id == id);
        }
    }
}
