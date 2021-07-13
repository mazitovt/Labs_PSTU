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
    public class WeaponCategoriesController : Controller
    {
        private readonly MilitaryDistrict2Context _context;

        public WeaponCategoriesController(MilitaryDistrict2Context context)
        {
            _context = context;
        }

        // GET: WeaponCategories
        public async Task<IActionResult> Index()
        {
            var military_district_2Context = _context.WeaponCategories.Include(w => w.Unit);
            return View(await military_district_2Context.ToListAsync());
        }

        // GET: WeaponCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weaponCategory = await _context.WeaponCategories
                .Include(w => w.Unit)
                .FirstOrDefaultAsync(m => m.WeaponCategoryId == id);
            if (weaponCategory == null)
            {
                return NotFound();
            }

            return View(weaponCategory);
        }

        // GET: WeaponCategories/Create
        public IActionResult Create()
        {
            ViewData["UnitId"] = new SelectList(_context.Units, "UnitId", "UnitNumber");
            return View();
        }

        // POST: WeaponCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WeaponCategoryId,UnitId,Name")] WeaponCategory weaponCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(weaponCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UnitId"] = new SelectList(_context.Units, "UnitId", "UnitNumber", weaponCategory.UnitId);
            return View(weaponCategory);
        }

        // GET: WeaponCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weaponCategory = await _context.WeaponCategories.FindAsync(id);
            if (weaponCategory == null)
            {
                return NotFound();
            }
            ViewData["UnitId"] = new SelectList(_context.Units, "UnitId", "UnitNumber", weaponCategory.UnitId);
            return View(weaponCategory);
        }

        // POST: WeaponCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WeaponCategoryId,UnitId,Name")] WeaponCategory weaponCategory)
        {
            if (id != weaponCategory.WeaponCategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(weaponCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WeaponCategoryExists(weaponCategory.WeaponCategoryId))
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
            ViewData["UnitId"] = new SelectList(_context.Units, "UnitId", "UnitNumber", weaponCategory.UnitId);
            return View(weaponCategory);
        }

        // GET: WeaponCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weaponCategory = await _context.WeaponCategories
                .Include(w => w.Unit)
                .FirstOrDefaultAsync(m => m.WeaponCategoryId == id);
            if (weaponCategory == null)
            {
                return NotFound();
            }

            return View(weaponCategory);
        }

        // POST: WeaponCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var weaponCategory = await _context.WeaponCategories.FindAsync(id);
            _context.WeaponCategories.Remove(weaponCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WeaponCategoryExists(int id)
        {
            return _context.WeaponCategories.Any(e => e.WeaponCategoryId == id);
        }
    }
}
