﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MilitaryDistrictAPI.Models.scaffolded;
using MilitaryDistrictAPI.Models.scaffolded;

namespace MilitaryDistrictAPI.Controllers.scaffolded
{
    public class LocationTypesController : Controller
    {
        private readonly MilitaryDistrict2Context _context;

        public LocationTypesController(MilitaryDistrict2Context context)
        {
            _context = context;
        }

        // GET: LocationTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.LocationTypes.ToListAsync());
        }

        // GET: LocationTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locationType = await _context.LocationTypes
                .FirstOrDefaultAsync(m => m.LocationTypeId == id);
            if (locationType == null)
            {
                return NotFound();
            }

            return View(locationType);
        }

        // GET: LocationTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LocationTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LocationTypeId,Name")] LocationType locationType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(locationType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(locationType);
        }

        // GET: LocationTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locationType = await _context.LocationTypes.FindAsync(id);
            if (locationType == null)
            {
                return NotFound();
            }
            return View(locationType);
        }

        // POST: LocationTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LocationTypeId,Name")] LocationType locationType)
        {
            if (id != locationType.LocationTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(locationType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocationTypeExists(locationType.LocationTypeId))
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
            return View(locationType);
        }

        // GET: LocationTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locationType = await _context.LocationTypes
                .FirstOrDefaultAsync(m => m.LocationTypeId == id);
            if (locationType == null)
            {
                return NotFound();
            }

            return View(locationType);
        }

        // POST: LocationTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var locationType = await _context.LocationTypes.FindAsync(id);
            _context.LocationTypes.Remove(locationType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocationTypeExists(int id)
        {
            return _context.LocationTypes.Any(e => e.LocationTypeId == id);
        }
    }
}
