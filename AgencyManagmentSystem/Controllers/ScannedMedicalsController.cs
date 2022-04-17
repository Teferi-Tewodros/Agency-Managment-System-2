#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgencyMAnagmentSystem.Models;
using AgencyManagmentSystem.Data;

namespace AgencyManagmentSystem.Controllers
{
    public class ScannedMedicalsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ScannedMedicalsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ScannedMedicals
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ScannedMedical.Include(s => s.Maid);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ScannedMedicals/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scannedMedical = await _context.ScannedMedical
                .Include(s => s.Maid)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (scannedMedical == null)
            {
                return NotFound();
            }

            return View(scannedMedical);
        }

        // GET: ScannedMedicals/Create
        public IActionResult Create()
        {
            ViewData["MaidId"] = new SelectList(_context.Maid, "Id", "Address");
            return View();
        }

        // POST: ScannedMedicals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MaidId,DataFiles,FileType,Discription")] ScannedMedical scannedMedical)
        {
            if (ModelState.IsValid)
            {
                scannedMedical.Id = Guid.NewGuid();
                _context.Add(scannedMedical);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaidId"] = new SelectList(_context.Maid, "Id", "Address", scannedMedical.MaidId);
            return View(scannedMedical);
        }

        // GET: ScannedMedicals/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scannedMedical = await _context.ScannedMedical.FindAsync(id);
            if (scannedMedical == null)
            {
                return NotFound();
            }
            ViewData["MaidId"] = new SelectList(_context.Maid, "Id", "Address", scannedMedical.MaidId);
            return View(scannedMedical);
        }

        // POST: ScannedMedicals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,MaidId,DataFiles,FileType,Discription")] ScannedMedical scannedMedical)
        {
            if (id != scannedMedical.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(scannedMedical);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScannedMedicalExists(scannedMedical.Id))
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
            ViewData["MaidId"] = new SelectList(_context.Maid, "Id", "Address", scannedMedical.MaidId);
            return View(scannedMedical);
        }

        // GET: ScannedMedicals/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scannedMedical = await _context.ScannedMedical
                .Include(s => s.Maid)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (scannedMedical == null)
            {
                return NotFound();
            }

            return View(scannedMedical);
        }

        // POST: ScannedMedicals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var scannedMedical = await _context.ScannedMedical.FindAsync(id);
            _context.ScannedMedical.Remove(scannedMedical);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScannedMedicalExists(Guid id)
        {
            return _context.ScannedMedical.Any(e => e.Id == id);
        }
    }
}
