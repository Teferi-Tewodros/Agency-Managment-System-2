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
    public class ScannedCocsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ScannedCocsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ScannedCocs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ScannedCoc.Include(s => s.Maid);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ScannedCocs/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scannedCoc = await _context.ScannedCoc
                .Include(s => s.Maid)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (scannedCoc == null)
            {
                return NotFound();
            }

            return View(scannedCoc);
        }

        // GET: ScannedCocs/Create
        public IActionResult Create()
        {
            ViewData["MaidId"] = new SelectList(_context.Maid, "Id", "Address");
            return View();
        }

        // POST: ScannedCocs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MaidId,DataFiles,FileType,Discription")] ScannedCoc scannedCoc)
        {
            if (ModelState.IsValid)
            {
                scannedCoc.Id = Guid.NewGuid();
                _context.Add(scannedCoc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaidId"] = new SelectList(_context.Maid, "Id", "Address", scannedCoc.MaidId);
            return View(scannedCoc);
        }

        // GET: ScannedCocs/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scannedCoc = await _context.ScannedCoc.FindAsync(id);
            if (scannedCoc == null)
            {
                return NotFound();
            }
            ViewData["MaidId"] = new SelectList(_context.Maid, "Id", "Address", scannedCoc.MaidId);
            return View(scannedCoc);
        }

        // POST: ScannedCocs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,MaidId,DataFiles,FileType,Discription")] ScannedCoc scannedCoc)
        {
            if (id != scannedCoc.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(scannedCoc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScannedCocExists(scannedCoc.Id))
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
            ViewData["MaidId"] = new SelectList(_context.Maid, "Id", "Address", scannedCoc.MaidId);
            return View(scannedCoc);
        }

        // GET: ScannedCocs/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scannedCoc = await _context.ScannedCoc
                .Include(s => s.Maid)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (scannedCoc == null)
            {
                return NotFound();
            }

            return View(scannedCoc);
        }

        // POST: ScannedCocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var scannedCoc = await _context.ScannedCoc.FindAsync(id);
            _context.ScannedCoc.Remove(scannedCoc);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScannedCocExists(Guid id)
        {
            return _context.ScannedCoc.Any(e => e.Id == id);
        }
    }
}
