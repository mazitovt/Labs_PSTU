using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MilitaryDistrictAPI.Models.scaffolded;
using MilitaryDistrictAPI.Models.ViewModels;

namespace MilitaryDistrictAPI.Controllers.scaffolded
{
    public class UnitsController : Controller
    {
        private readonly MilitaryDistrict2Context _context;

        public UnitsController(MilitaryDistrict2Context context)
        {
            _context = context;
        }

        // GET: Units
        public async Task<IActionResult> Index()
        {
            var military_district_2Context = _context.Units
                .Include(u => u.Leader)
                .Include(u => u.ParentUnit)
                .Include(u => u.UnitType);
            
            return View(new FilterUnitView
            {
                Units = await military_district_2Context.ToListAsync()
            });
        }
        
        
        [HttpPost]
        public async Task<IActionResult> FilterUnits(FilterUnitView view)
        {

            var filter = view.Filter;

            bool FilterUnits(Unit u)
            {
                var flag = true;

                if (filter.UnitTypeName != null)
                {
                    if (u.UnitType != null)
                    {
                        flag = u.UnitType.Name == filter.UnitTypeName;
                    }
                    else
                    {
                        flag = false;
                    }
                }

                if (filter.ParentUnitNumber != null)
                {
                    if (u.ParentUnit != null)
                    {
                        flag = flag && (u.ParentUnit.UnitNumber == filter.ParentUnitNumber);
                    }
                    else
                    {
                        flag = false;
                    }
  
                }

                if (filter.LeaderName != null)
                {
                    if (u.Leader != null)
                    {
                        flag = flag && (u.Leader.Name == filter.LeaderName);
                    }
                    else
                    {
                        flag = false;
                    }
                }

                return flag;
            }

            var units = _context.Units
                    .Include(u => u.Leader)
                    .Include(u => u.ParentUnit)
                    .Include(u => u.UnitType)
                    .AsEnumerable()
                    .Where(FilterUnits).ToList();
            

            return View("Index",new FilterUnitView
            {
                Filter = filter,
                Units = units
            });
        }


        // GET: Units/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unit = await _context.Units
                .Include(u => u.Leader)
                .Include(u => u.ParentUnit)
                .Include(u => u.UnitType)
                .FirstOrDefaultAsync(m => m.UnitId == id);
            if (unit == null)
            {
                return NotFound();
            }

            return View(unit);
        }

        // GET: Units/Create
        public IActionResult Create()
        {
            var officerSoldiers = _context.Soldiers.Where(s => s.MilitaryRank.CommandHigherUnit);
            
            ViewData["LeaderId"] = new SelectList(officerSoldiers, "SoldierId", "Name");
            ViewData["ParentUnitId"] = new SelectList(_context.Units, "UnitId", "UnitNumber");
            ViewData["UnitTypeId"] = new SelectList(_context.UnitTypes, "UnitTypeId", "Name");
            return View();
        }

        // POST: Units/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UnitId,UnitTypeId,UnitNumber,Name,ParentUnitId,LeaderId")] Unit unit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(unit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LeaderId"] = new SelectList(_context.Soldiers, "SoldierId", "SoldierId", unit.LeaderId);
            ViewData["ParentUnitId"] = new SelectList(_context.Units, "UnitId", "UnitNumber", unit.ParentUnitId);
            ViewData["UnitTypeId"] = new SelectList(_context.UnitTypes, "UnitTypeId", "Name", unit.UnitTypeId);
            return View(unit);
        }

        // GET: Units/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unit = await _context.Units.FindAsync(id);
            if (unit == null)
            {
                return NotFound();
            }
            ViewData["LeaderId"] = new SelectList(_context.Soldiers, "SoldierId", "SoldierId", unit.LeaderId);
            ViewData["ParentUnitId"] = new SelectList(_context.Units, "UnitId", "UnitNumber", unit.ParentUnitId);
            ViewData["UnitTypeId"] = new SelectList(_context.UnitTypes, "UnitTypeId", "Name", unit.UnitTypeId);
            return View(unit);
        }

        // POST: Units/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UnitId,UnitTypeId,UnitNumber,Name,ParentUnitId,LeaderId")] Unit unit)
        {
            if (id != unit.UnitId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnitExists(unit.UnitId))
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
            ViewData["LeaderId"] = new SelectList(_context.Soldiers, "SoldierId", "SoldierId", unit.LeaderId);
            ViewData["ParentUnitId"] = new SelectList(_context.Units, "UnitId", "UnitNumber", unit.ParentUnitId);
            ViewData["UnitTypeId"] = new SelectList(_context.UnitTypes, "UnitTypeId", "Name", unit.UnitTypeId);
            return View(unit);
        }

        // GET: Units/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unit = await _context.Units
                .Include(u => u.Leader)
                .Include(u => u.ParentUnit)
                .Include(u => u.UnitType)
                .FirstOrDefaultAsync(m => m.UnitId == id);
            if (unit == null)
            {
                return NotFound();
            }

            return View(unit);
        }

        // POST: Units/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var unit = await _context.Units.FindAsync(id);
            _context.Units.Remove(unit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UnitExists(int id)
        {
            return _context.Units.Any(e => e.UnitId == id);
        }
    }
}
