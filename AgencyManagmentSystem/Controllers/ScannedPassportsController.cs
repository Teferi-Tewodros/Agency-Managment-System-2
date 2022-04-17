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
    public class ScannedPassportsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ScannedPassportsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ScannedPassports
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ScannedPassport.Include(s => s.Maid);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ScannedPassports/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scannedPassport = await _context.ScannedPassport
                .Include(s => s.Maid)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (scannedPassport == null)
            {
                return NotFound();
            }

            return View(scannedPassport);
        }

        // GET: ScannedPassports/Create
        public IActionResult Create()
        {
            ViewData["MaidId"] = new SelectList(_context.Maid, "Id", "Address");
            return View();
        }

        // POST: ScannedPassports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MaidId,DataFiles,FileType,Discription")] ScannedPassport scannedPassport)
        {
            if (ModelState.IsValid)
            {
                scannedPassport.Id = Guid.NewGuid();
                _context.Add(scannedPassport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaidId"] = new SelectList(_context.Maid, "Id", "Address", scannedPassport.MaidId);
            return View(scannedPassport);
        }

        // GET: ScannedPassports/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scannedPassport = await _context.ScannedPassport.FindAsync(id);
            if (scannedPassport == null)
            {
                return NotFound();
            }
            ViewData["MaidId"] = new SelectList(_context.Maid, "Id", "Address", scannedPassport.MaidId);
            return View(scannedPassport);
        }

        // POST: ScannedPassports/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,MaidId,DataFiles,FileType,Discription")] ScannedPassport scannedPassport)
        {
            if (id != scannedPassport.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(scannedPassport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScannedPassportExists(scannedPassport.Id))
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
            ViewData["MaidId"] = new SelectList(_context.Maid, "Id", "Address", scannedPassport.MaidId);
            return View(scannedPassport);
        }

        // GET: ScannedPassports/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scannedPassport = await _context.ScannedPassport
                .Include(s => s.Maid)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (scannedPassport == null)
            {
                return NotFound();
            }

            return View(scannedPassport);
        }

        // POST: ScannedPassports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var scannedPassport = await _context.ScannedPassport.FindAsync(id);
            _context.ScannedPassport.Remove(scannedPassport);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScannedPassportExists(Guid id)
        {
            return _context.ScannedPassport.Any(e => e.Id == id);
        }
    }
}
