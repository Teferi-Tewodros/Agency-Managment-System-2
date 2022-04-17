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
    public class ScannedSignituresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ScannedSignituresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ScannedSignitures
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ScannedSigniture.Include(s => s.Maid);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ScannedSignitures/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scannedSigniture = await _context.ScannedSigniture
                .Include(s => s.Maid)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (scannedSigniture == null)
            {
                return NotFound();
            }

            return View(scannedSigniture);
        }

        // GET: ScannedSignitures/Create
        public IActionResult Create()
        {
            ViewData["MaidId"] = new SelectList(_context.Maid, "Id", "Address");
            return View();
        }

        // POST: ScannedSignitures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MaidId,DataFiles,FileType,Discription")] ScannedSigniture scannedSigniture)
        {
            if (ModelState.IsValid)
            {
                scannedSigniture.Id = Guid.NewGuid();
                _context.Add(scannedSigniture);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaidId"] = new SelectList(_context.Maid, "Id", "Address", scannedSigniture.MaidId);
            return View(scannedSigniture);
        }

        // GET: ScannedSignitures/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scannedSigniture = await _context.ScannedSigniture.FindAsync(id);
            if (scannedSigniture == null)
            {
                return NotFound();
            }
            ViewData["MaidId"] = new SelectList(_context.Maid, "Id", "Address", scannedSigniture.MaidId);
            return View(scannedSigniture);
        }

        // POST: ScannedSignitures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,MaidId,DataFiles,FileType,Discription")] ScannedSigniture scannedSigniture)
        {
            if (id != scannedSigniture.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(scannedSigniture);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScannedSignitureExists(scannedSigniture.Id))
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
            ViewData["MaidId"] = new SelectList(_context.Maid, "Id", "Address", scannedSigniture.MaidId);
            return View(scannedSigniture);
        }

        // GET: ScannedSignitures/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scannedSigniture = await _context.ScannedSigniture
                .Include(s => s.Maid)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (scannedSigniture == null)
            {
                return NotFound();
            }

            return View(scannedSigniture);
        }

        // POST: ScannedSignitures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var scannedSigniture = await _context.ScannedSigniture.FindAsync(id);
            _context.ScannedSigniture.Remove(scannedSigniture);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScannedSignitureExists(Guid id)
        {
            return _context.ScannedSigniture.Any(e => e.Id == id);
        }
    }
}
