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
    public class SubunitTypesController : Controller
    {
        private readonly MilitaryDistrict2Context _context;

        public SubunitTypesController(MilitaryDistrict2Context context)
        {
            _context = context;
        }

        // GET: SubunitTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.SubunitTypes.ToListAsync());
        }

        // GET: SubunitTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subunitType = await _context.SubunitTypes
                .FirstOrDefaultAsync(m => m.SubunitTypeId == id);
            if (subunitType == null)
            {
                return NotFound();
            }

            return View(subunitType);
        }

        // GET: SubunitTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SubunitTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SubunitTypeId,Name")] SubunitType subunitType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subunitType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(subunitType);
        }

        // GET: SubunitTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subunitType = await _context.SubunitTypes.FindAsync(id);
            if (subunitType == null)
            {
                return NotFound();
            }
            return View(subunitType);
        }

        // POST: SubunitTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SubunitTypeId,Name")] SubunitType subunitType)
        {
            if (id != subunitType.SubunitTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subunitType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubunitTypeExists(subunitType.SubunitTypeId))
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
            return View(subunitType);
        }

        // GET: SubunitTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subunitType = await _context.SubunitTypes
                .FirstOrDefaultAsync(m => m.SubunitTypeId == id);
            if (subunitType == null)
            {
                return NotFound();
            }

            return View(subunitType);
        }

        // POST: SubunitTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subunitType = await _context.SubunitTypes.FindAsync(id);
            _context.SubunitTypes.Remove(subunitType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubunitTypeExists(int id)
        {
            return _context.SubunitTypes.Any(e => e.SubunitTypeId == id);
        }
    }
}
