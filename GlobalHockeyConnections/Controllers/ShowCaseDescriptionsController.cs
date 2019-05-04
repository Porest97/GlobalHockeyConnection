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
    public class ShowCaseDescriptionsController : Controller
    {
        private readonly GlobalHockeyConnectionsContext _context;

        public ShowCaseDescriptionsController(GlobalHockeyConnectionsContext context)
        {
            _context = context;
        }

        // GET: ShowCaseDescriptions
        public async Task<IActionResult> Index()
        {
            return View(await _context.ShowCaseDescription.ToListAsync());
        }

        // GET: ShowCaseDescriptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var showCaseDescription = await _context.ShowCaseDescription
                .FirstOrDefaultAsync(m => m.Id == id);
            if (showCaseDescription == null)
            {
                return NotFound();
            }

            return View(showCaseDescription);
        }

        // GET: ShowCaseDescriptions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ShowCaseDescriptions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ShowCaseInfo")] ShowCaseDescription showCaseDescription)
        {
            if (ModelState.IsValid)
            {
                _context.Add(showCaseDescription);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(showCaseDescription);
        }

        // GET: ShowCaseDescriptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var showCaseDescription = await _context.ShowCaseDescription.FindAsync(id);
            if (showCaseDescription == null)
            {
                return NotFound();
            }
            return View(showCaseDescription);
        }

        // POST: ShowCaseDescriptions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ShowCaseInfo")] ShowCaseDescription showCaseDescription)
        {
            if (id != showCaseDescription.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(showCaseDescription);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShowCaseDescriptionExists(showCaseDescription.Id))
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
            return View(showCaseDescription);
        }

        // GET: ShowCaseDescriptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var showCaseDescription = await _context.ShowCaseDescription
                .FirstOrDefaultAsync(m => m.Id == id);
            if (showCaseDescription == null)
            {
                return NotFound();
            }

            return View(showCaseDescription);
        }

        // POST: ShowCaseDescriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var showCaseDescription = await _context.ShowCaseDescription.FindAsync(id);
            _context.ShowCaseDescription.Remove(showCaseDescription);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShowCaseDescriptionExists(int id)
        {
            return _context.ShowCaseDescription.Any(e => e.Id == id);
        }
    }
}
