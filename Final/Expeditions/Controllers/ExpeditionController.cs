using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Expeditions.Models;

namespace Expeditions.Controllers
{
    public class ExpeditionController : Controller
    {
        private readonly ExpeditionDbContext _context;

        public ExpeditionController(ExpeditionDbContext context)
        {
            _context = context;
        }

        // GET: Expedition
        public async Task<IActionResult> Index()
        {
            var expeditionDbContext = _context.Expeditions.Include(e => e.Peak).Include(e => e.TrekkingAgency).OrderByDescending(d => d.StartDate).Take(50);
            return View(await expeditionDbContext.ToListAsync());
        }

        // GET: Expedition/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expedition = await _context.Expeditions
                .Include(e => e.Peak)
                .Include(e => e.TrekkingAgency)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (expedition == null)
            {
                return NotFound();
            }

            return View(expedition);
        }

        // GET: Expedition/Create
        public IActionResult Create()
        {
            ViewData["PeakId"] = new SelectList(_context.Peaks, "Id", "Name");
            ViewData["TrekkingAgencyId"] = new SelectList(_context.TrekkingAgencies, "Id", "Name");
            return View();
        }

        // POST: Expedition/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Season,Year,StartDate,TerminationReason,OxygenUsed,PeakId,TrekkingAgencyId")] Expedition expedition)
        {
            if (ModelState.IsValid)
            {
                _context.Add(expedition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PeakId"] = new SelectList(_context.Peaks, "Id", "Name", expedition.PeakId);
            ViewData["TrekkingAgencyId"] = new SelectList(_context.TrekkingAgencies, "Id", "Id", expedition.TrekkingAgencyId);
            return View(expedition);
        }

        // GET: Expedition/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expedition = await _context.Expeditions.FindAsync(id);
            if (expedition == null)
            {
                return NotFound();
            }
            ViewData["PeakId"] = new SelectList(_context.Peaks, "Id", "Name", expedition.PeakId);
            ViewData["TrekkingAgencyId"] = new SelectList(_context.TrekkingAgencies, "Id", "Id", expedition.TrekkingAgencyId);
            return View(expedition);
        }

        // POST: Expedition/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Season,Year,StartDate,TerminationReason,OxygenUsed,PeakId,TrekkingAgencyId")] Expedition expedition)
        {
            if (id != expedition.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(expedition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpeditionExists(expedition.Id))
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
            ViewData["PeakId"] = new SelectList(_context.Peaks, "Id", "Name", expedition.PeakId);
            ViewData["TrekkingAgencyId"] = new SelectList(_context.TrekkingAgencies, "Id", "Id", expedition.TrekkingAgencyId);
            return View(expedition);
        }

        // GET: Expedition/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expedition = await _context.Expeditions
                .Include(e => e.Peak)
                .Include(e => e.TrekkingAgency)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (expedition == null)
            {
                return NotFound();
            }

            return View(expedition);
        }

        // POST: Expedition/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var expedition = await _context.Expeditions.FindAsync(id);
            _context.Expeditions.Remove(expedition);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpeditionExists(int id)
        {
            return _context.Expeditions.Any(e => e.Id == id);
        }
        public IActionResult NewExpedition()
        {
            ViewData["PeakId"] = new SelectList(_context.Peaks, "Id", "Name");
            ViewData["TrekkingAgencyId"] = new SelectList(_context.TrekkingAgencies, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult NewExpedition(Expedition e)
        {
            string date = e.StartDate.ToString().Substring(0,2);
            if (date == "03" || date == "04" || date == "05")
            {
                e.Season = "Spring";
            }
            else if (date == "06" || date == "07" || date == "08")
            {
                e.Season = "Summer";
            }
            else if (date == "09" || date == "10" || date == "11")
            {
                e.Season = "Autumn";
            }
            else
            {
                e.Season = "Winter";
            }
            e.Year = e.StartDate.Year;
            e.Peak = _context.Peaks.Find(e.PeakId);
            e.TrekkingAgency = _context.TrekkingAgencies.Find(e.TrekkingAgencyId);

            _context.Add(e);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
