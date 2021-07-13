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
    public class WeaponsController : Controller
    {
        private readonly MilitaryDistrict2Context _context;

        public WeaponsController(MilitaryDistrict2Context context)
        {
            _context = context;
        }

        // GET: Weapons
        public async Task<IActionResult> Index()
        {
            var military_district_2Context = _context.Weapons.Include(w => w.WeaponCategory);
            return View(await military_district_2Context.ToListAsync());
        }

        // GET: Weapons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weapon = await _context.Weapons
                .Include(w => w.WeaponCategory)
                .FirstOrDefaultAsync(m => m.WeaponId == id);
            if (weapon == null)
            {
                return NotFound();
            }

            return View(weapon);
        }

        // GET: Weapons/Create
        public IActionResult Create()
        {
            ViewData["WeaponCategoryId"] = new SelectList(_context.WeaponCategories, "WeaponCategoryId", "Name");
            return View();
        }

        // POST: Weapons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WeaponId,WeaponCategoryId,Name,Amount")] Weapon weapon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(weapon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["WeaponCategoryId"] = new SelectList(_context.WeaponCategories, "WeaponCategoryId", "Name", weapon.WeaponCategoryId);
            return View(weapon);
        }

        // GET: Weapons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weapon = await _context.Weapons.FindAsync(id);
            if (weapon == null)
            {
                return NotFound();
            }
            ViewData["WeaponCategoryId"] = new SelectList(_context.WeaponCategories, "WeaponCategoryId", "Name", weapon.WeaponCategoryId);
            return View(weapon);
        }

        // POST: Weapons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WeaponId,WeaponCategoryId,Name,Amount")] Weapon weapon)
        {
            if (id != weapon.WeaponId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(weapon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WeaponExists(weapon.WeaponId))
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
            ViewData["WeaponCategoryId"] = new SelectList(_context.WeaponCategories, "WeaponCategoryId", "Name", weapon.WeaponCategoryId);
            return View(weapon);
        }

        // GET: Weapons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weapon = await _context.Weapons
                .Include(w => w.WeaponCategory)
                .FirstOrDefaultAsync(m => m.WeaponId == id);
            if (weapon == null)
            {
                return NotFound();
            }

            return View(weapon);
        }

        // POST: Weapons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var weapon = await _context.Weapons.FindAsync(id);
            _context.Weapons.Remove(weapon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WeaponExists(int id)
        {
            return _context.Weapons.Any(e => e.WeaponId == id);
        }
    }
}
