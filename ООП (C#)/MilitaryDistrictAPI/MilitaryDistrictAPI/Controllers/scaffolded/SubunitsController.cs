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
    public class SubunitsController : Controller
    {
        private readonly MilitaryDistrict2Context _context;

        public SubunitsController(MilitaryDistrict2Context context)
        {
            _context = context;
        }

        // GET: Subunits
        public async Task<IActionResult> Index()
        {
            var military_district_2Context = _context.Subunits.Include(s => s.Leader).Include(s => s.ParentUnit).Include(s => s.SubunitType);
            return View(await military_district_2Context.ToListAsync());
        }

        // GET: Subunits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subunit = await _context.Subunits
                .Include(s => s.Leader)
                .Include(s => s.ParentUnit)
                .Include(s => s.SubunitType)
                .FirstOrDefaultAsync(m => m.SubunitId == id);
            if (subunit == null)
            {
                return NotFound();
            }

            return View(subunit);
        }

        // GET: Subunits/Create
        public IActionResult Create()
        {
            ViewData["LeaderId"] = new SelectList(_context.Soldiers, "SoldierId", "SoldierId");
            ViewData["ParentUnitId"] = new SelectList(_context.Units, "UnitId", "UnitNumber");
            ViewData["SubunitTypeId"] = new SelectList(_context.SubunitTypes, "SubunitTypeId", "Name");
            return View();
        }

        // POST: Subunits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SubunitId,LeaderId,SubunitTypeId,ParentUnitId,Name")] Subunit subunit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subunit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LeaderId"] = new SelectList(_context.Soldiers, "SoldierId", "SoldierId", subunit.LeaderId);
            ViewData["ParentUnitId"] = new SelectList(_context.Units, "UnitId", "UnitNumber", subunit.ParentUnitId);
            ViewData["SubunitTypeId"] = new SelectList(_context.SubunitTypes, "SubunitTypeId", "Name", subunit.SubunitTypeId);
            return View(subunit);
        }

        // GET: Subunits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subunit = await _context.Subunits.FindAsync(id);
            if (subunit == null)
            {
                return NotFound();
            }
            ViewData["LeaderId"] = new SelectList(_context.Soldiers, "SoldierId", "SoldierId", subunit.LeaderId);
            ViewData["ParentUnitId"] = new SelectList(_context.Units, "UnitId", "UnitNumber", subunit.ParentUnitId);
            ViewData["SubunitTypeId"] = new SelectList(_context.SubunitTypes, "SubunitTypeId", "Name", subunit.SubunitTypeId);
            return View(subunit);
        }

        // POST: Subunits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SubunitId,LeaderId,SubunitTypeId,ParentUnitId,Name")] Subunit subunit)
        {
            if (id != subunit.SubunitId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subunit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubunitExists(subunit.SubunitId))
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
            ViewData["LeaderId"] = new SelectList(_context.Soldiers, "SoldierId", "SoldierId", subunit.LeaderId);
            ViewData["ParentUnitId"] = new SelectList(_context.Units, "UnitId", "UnitNumber", subunit.ParentUnitId);
            ViewData["SubunitTypeId"] = new SelectList(_context.SubunitTypes, "SubunitTypeId", "Name", subunit.SubunitTypeId);
            return View(subunit);
        }

        // GET: Subunits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subunit = await _context.Subunits
                .Include(s => s.Leader)
                .Include(s => s.ParentUnit)
                .Include(s => s.SubunitType)
                .FirstOrDefaultAsync(m => m.SubunitId == id);
            if (subunit == null)
            {
                return NotFound();
            }

            return View(subunit);
        }

        // POST: Subunits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subunit = await _context.Subunits.FindAsync(id);
            _context.Subunits.Remove(subunit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubunitExists(int id)
        {
            return _context.Subunits.Any(e => e.SubunitId == id);
        }
    }
}
