using System;
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
    public class MilitaryRanksController : Controller
    {
        private readonly MilitaryDistrict2Context _context;

        public MilitaryRanksController(MilitaryDistrict2Context context)
        {
            _context = context;
        }

        // GET: MilitaryRanks
        public async Task<IActionResult> Index()
        {
            return View(await _context.MilitaryRanks.ToListAsync());
        }

        // GET: MilitaryRanks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var militaryRank = await _context.MilitaryRanks
                .FirstOrDefaultAsync(m => m.MilitaryRankId == id);
            if (militaryRank == null)
            {
                return NotFound();
            }

            return View(militaryRank);
        }

        // GET: MilitaryRanks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MilitaryRanks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MilitaryRankId,Name,RankGroup,CommandHigherUnit")] MilitaryRank militaryRank)
        {
            if (ModelState.IsValid)
            {
                _context.Add(militaryRank);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(militaryRank);
        }

        // GET: MilitaryRanks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var militaryRank = await _context.MilitaryRanks.FindAsync(id);
            if (militaryRank == null)
            {
                return NotFound();
            }
            return View(militaryRank);
        }

        // POST: MilitaryRanks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MilitaryRankId,Name,RankGroup,CommandHigherUnit")] MilitaryRank militaryRank)
        {
            if (id != militaryRank.MilitaryRankId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(militaryRank);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MilitaryRankExists(militaryRank.MilitaryRankId))
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
            return View(militaryRank);
        }

        // GET: MilitaryRanks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var militaryRank = await _context.MilitaryRanks
                .FirstOrDefaultAsync(m => m.MilitaryRankId == id);
            if (militaryRank == null)
            {
                return NotFound();
            }

            return View(militaryRank);
        }

        // POST: MilitaryRanks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var militaryRank = await _context.MilitaryRanks.FindAsync(id);
            _context.MilitaryRanks.Remove(militaryRank);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MilitaryRankExists(int id)
        {
            return _context.MilitaryRanks.Any(e => e.MilitaryRankId == id);
        }
    }
}
