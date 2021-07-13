using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MilitaryDistrictAPI.Models.scaffolded;

namespace MilitaryDistrictAPI.Controllers.scaffolded
{
    public class OccupationsController : Controller
    {
        private readonly MilitaryDistrict2Context _context;

        public OccupationsController(MilitaryDistrict2Context context)
        {
            _context = context;
        }

        // GET: Occupations
        public async Task<IActionResult> Index()
        {
            return View(await _context.Occupations.ToListAsync());
        }

        // GET: Occupations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var occupation = await _context.Occupations
                .FirstOrDefaultAsync(m => m.OccupationId == id);
            if (occupation == null)
            {
                return NotFound();
            }

            return View(occupation);
        }

        // GET: Occupations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Occupations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OccupationId,Name")] Occupation occupation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(occupation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(occupation);
        }

        // GET: Occupations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var occupation = await _context.Occupations.FindAsync(id);
            if (occupation == null)
            {
                return NotFound();
            }
            return View(occupation);
        }

        // POST: Occupations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OccupationId,Name")] Occupation occupation)
        {
            if (id != occupation.OccupationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(occupation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OccupationExists(occupation.OccupationId))
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
            return View(occupation);
        }

        // GET: Occupations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var occupation = await _context.Occupations
                .FirstOrDefaultAsync(m => m.OccupationId == id);
            if (occupation == null)
            {
                return NotFound();
            }

            return View(occupation);
        }

        // POST: Occupations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var occupation = await _context.Occupations.FindAsync(id);
            _context.Occupations.Remove(occupation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OccupationExists(int id)
        {
            return _context.Occupations.Any(e => e.OccupationId == id);
        }
    }
}
