using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MilitaryDistrictAPI.Models.Filter;
using MilitaryDistrictAPI.Models.scaffolded;
using MilitaryDistrictAPI.Models.ViewModels;
using Org.BouncyCastle.Crypto.Tls;

namespace MilitaryDistrictAPI.Controllers.scaffolded
{
    public class SoldiersController : Controller
    {
        private readonly MilitaryDistrict2Context _context;

        public SoldiersController(MilitaryDistrict2Context context)
        {
            _context = context;
        }

        // GET: Soldiers
        public async Task<IActionResult> Index()
        {
            var militaryDistrict2Context = _context.Soldiers
                .Include(s => s.Leader)
                .Include(s => s.MilitaryRank)
                .Include(s => s.RankInfo)
                .Include(s => s.ServingSubunit)
                .Include(s => s.ServingUnit);

            var view = new SoldiersFilterView
            {
                // Filter = new FilterSoldier(),
                Soldiers = await militaryDistrict2Context.ToListAsync()
            };

            return View(view);

            // return View(await militaryDistrict2Context.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> FilterSoldiers(SoldiersFilterView view)
        {

            var filter = view.Filter;

            bool FilterSoldiers(Soldier s)
            {
                var flag = true;

                if (filter.UnitName != null)
                {
                    if (s.ServingUnit != null)
                    {
                        flag = flag && s.ServingUnit.UnitNumber == filter.UnitName;
                    }
                    else
                    {
                        flag = false;
                    }
                }
                
                if (filter.SubUnitId != null)
                {
                    flag = flag && (s.ServingSubunitId == filter.SubUnitId);
                }
                
                if (filter.LeaderName != null)
                {
                    if (s.Leader != null)
                    {
                        flag = flag && (s.Leader.Name == filter.LeaderName);
                    }
                    else
                    {
                        flag = false;
                    }
                }

                if (filter.RankName != null)
                {
                    if (s.MilitaryRank != null)
                    {
                        flag = flag && (s.MilitaryRank.Name == filter.RankName);
                    }
                    else
                    {
                        flag = false;
                    }
                }
                
                return flag;
            }

            var militaryDistrict2Context = _context.Soldiers
                .Include(s => s.Leader)
                .Include(s => s.MilitaryRank)
                .Include(s => s.RankInfo)
                .Include(s => s.ServingSubunit)
                .Include(s => s.ServingUnit)
                .AsEnumerable()
                .Where(FilterSoldiers).ToList();
            

            return View("Index",new SoldiersFilterView
                {
                    Filter = filter,
                    Soldiers = militaryDistrict2Context
                });
        }


        // GET: Soldiers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var soldier = await _context.Soldiers
                .Include(s => s.Leader)
                .Include(s => s.MilitaryRank)
                .Include(s => s.RankInfo)
                .Include(s => s.ServingSubunit)
                .Include(s => s.ServingUnit)
                .Include(s => s.Occupations)
                .FirstOrDefaultAsync(m => m.SoldierId == id);
            
            if (soldier == null)
            {
                return NotFound();
            }

            return View(soldier);
        }

        // GET: Soldiers/Create
        public IActionResult Create()
        {
            ViewData["LeaderId"] = new SelectList(_context.Soldiers, "SoldierId", "SoldierId");
            ViewData["MilitaryRankId"] = new SelectList(_context.MilitaryRanks, "MilitaryRankId", "Name");
            ViewData["RankInfoId"] = new SelectList(_context.SoldierRankInfos, "RecordId", "RecordId");
            ViewData["ServingSubunitId"] = new SelectList(_context.Subunits, "SubunitId", "SubunitId");
            ViewData["ServingUnitId"] = new SelectList(_context.Units, "UnitId", "UnitNumber");
            ViewData["Occupations"] = new MultiSelectList(_context.Occupations,"OccupationId","Name");

            return View();
        }

        // POST: Soldiers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SoldierId,ServingUnitId,ServingSubunitId,MilitaryRankId,Name,RankInfoId,LeaderId, Occupations")] Soldier soldier)
        {
            var occupationIds = Request.Form["Occop"].Select(int.Parse).ToList();
            var selectedOccupations = _context.Occupations.Where(o => occupationIds.Contains(o.OccupationId));
            soldier.Occupations.AddRange(selectedOccupations);
            
            if (ModelState.IsValid)
            {
                _context.Add(soldier);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LeaderId"] = new SelectList(_context.Soldiers, "SoldierId", "SoldierId", soldier.LeaderId);
            ViewData["MilitaryRankId"] = new SelectList(_context.MilitaryRanks, "MilitaryRankId", "Name", soldier.MilitaryRankId);
            ViewData["RankInfoId"] = new SelectList(_context.SoldierRankInfos, "RecordId", "RecordId", soldier.RankInfoId);
            ViewData["ServingSubunitId"] = new SelectList(_context.Subunits, "SubunitId", "SubunitId", soldier.ServingSubunitId);
            ViewData["ServingUnitId"] = new SelectList(_context.Units, "UnitId", "UnitNumber", soldier.ServingUnitId);
            ViewData["Occupations"] = new MultiSelectList(_context.Occupations, "OccupationId", "Name",soldier.Occupations);
            
            return View(soldier);
        }

        // GET: Soldiers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var soldier = _context.Soldiers.Include(s => s.Occupations).FirstOrDefaultAsync(s => s.SoldierId == id).Result;

            if (soldier == null)
            {
                return NotFound();
            }
            
            ViewData["LeaderId"] = new SelectList(_context.Soldiers, "SoldierId", "SoldierId", soldier.LeaderId);
            ViewData["MilitaryRankId"] = new SelectList(_context.MilitaryRanks, "MilitaryRankId", "Name", soldier.MilitaryRankId);
            ViewData["RankInfoId"] = new SelectList(_context.SoldierRankInfos, "RecordId", "RecordId", soldier.RankInfoId);
            ViewData["ServingSubunitId"] = new SelectList(_context.Subunits, "SubunitId", "SubunitId", soldier.ServingSubunitId);
            ViewData["ServingUnitId"] = new SelectList(_context.Units, "UnitId", "UnitNumber", soldier.ServingUnitId);
            ViewData["Occupations"] = new MultiSelectList(_context.Occupations, "OccupationId", "Name", soldier.Occupations.Select(o => o.OccupationId));
            
            return View(soldier);
        }

        // POST: Soldiers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SoldierId,ServingUnitId,ServingSubunitId,MilitaryRankId,Name,RankInfoId,LeaderId, Occupations")] Soldier soldier)
        {
            if (id != soldier.SoldierId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(soldier);
                    await _context.SaveChangesAsync();
                    
                    var occupationIds = Request.Form["Occupations"].Select(int.Parse).ToList();
                    var selectedOccupations = _context.Occupations.Where(o => occupationIds.Contains(o.OccupationId));
                    soldier = _context.Soldiers.Include(s => s.Occupations).FirstOrDefault(s => s.SoldierId == id);
                    soldier.Occupations.Clear();
                    soldier.Occupations.AddRange(selectedOccupations);
                    
                    _context.Update(soldier);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SoldierExists(soldier.SoldierId))
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
            ViewData["LeaderId"] = new SelectList(_context.Soldiers, "SoldierId", "SoldierId", soldier.LeaderId);
            ViewData["MilitaryRankId"] = new SelectList(_context.MilitaryRanks, "MilitaryRankId", "Name", soldier.MilitaryRankId);
            ViewData["RankInfoId"] = new SelectList(_context.SoldierRankInfos, "RecordId", "RecordId", soldier.RankInfoId);
            ViewData["ServingSubunitId"] = new SelectList(_context.Subunits, "SubunitId", "SubunitId", soldier.ServingSubunitId);
            ViewData["ServingUnitId"] = new SelectList(_context.Units, "UnitId", "UnitNumber", soldier.ServingUnitId);
            ViewData["Occupations"] = new MultiSelectList(_context.Occupations, "OccupationId", "Name", soldier.Occupations.Select(o => o.OccupationId));
            return View(soldier);
        }

        // GET: Soldiers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var soldier = await _context.Soldiers
                .Include(s => s.Leader)
                .Include(s => s.MilitaryRank)
                .Include(s => s.RankInfo)
                .Include(s => s.ServingSubunit)
                .Include(s => s.ServingUnit)
                .FirstOrDefaultAsync(m => m.SoldierId == id);
            if (soldier == null)
            {
                return NotFound();
            }

            return View(soldier);
        }

        // POST: Soldiers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var soldier = await _context.Soldiers.FindAsync(id);
            _context.Soldiers.Remove(soldier);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SoldierExists(int id)
        {
            return _context.Soldiers.Any(e => e.SoldierId == id);
        }
    }
}
