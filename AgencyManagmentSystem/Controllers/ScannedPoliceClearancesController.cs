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
    public class ScannedPoliceClearancesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ScannedPoliceClearancesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ScannedPoliceClearances
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ScannedPoliceClearance.Include(s => s.Maid);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ScannedPoliceClearances/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scannedPoliceClearance = await _context.ScannedPoliceClearance
                .Include(s => s.Maid)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (scannedPoliceClearance == null)
            {
                return NotFound();
            }

            return View(scannedPoliceClearance);
        }

        // GET: ScannedPoliceClearances/Create
        public IActionResult Create()
        {
            ViewData["MaidId"] = new SelectList(_context.Maid, "Id", "Address");
            return View();
        }

        // POST: ScannedPoliceClearances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MaidId,DataFiles,FileType,Discription")] ScannedPoliceClearance scannedPoliceClearance)
        {
            if (ModelState.IsValid)
            {
                scannedPoliceClearance.Id = Guid.NewGuid();
                _context.Add(scannedPoliceClearance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaidId"] = new SelectList(_context.Maid, "Id", "Address", scannedPoliceClearance.MaidId);
            return View(scannedPoliceClearance);
        }

        // GET: ScannedPoliceClearances/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scannedPoliceClearance = await _context.ScannedPoliceClearance.FindAsync(id);
            if (scannedPoliceClearance == null)
            {
                return NotFound();
            }
            ViewData["MaidId"] = new SelectList(_context.Maid, "Id", "Address", scannedPoliceClearance.MaidId);
            return View(scannedPoliceClearance);
        }

        // POST: ScannedPoliceClearances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,MaidId,DataFiles,FileType,Discription")] ScannedPoliceClearance scannedPoliceClearance)
        {
            if (id != scannedPoliceClearance.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(scannedPoliceClearance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScannedPoliceClearanceExists(scannedPoliceClearance.Id))
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
            ViewData["MaidId"] = new SelectList(_context.Maid, "Id", "Address", scannedPoliceClearance.MaidId);
            return View(scannedPoliceClearance);
        }

        // GET: ScannedPoliceClearances/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scannedPoliceClearance = await _context.ScannedPoliceClearance
                .Include(s => s.Maid)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (scannedPoliceClearance == null)
            {
                return NotFound();
            }

            return View(scannedPoliceClearance);
        }

        // POST: ScannedPoliceClearances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var scannedPoliceClearance = await _context.ScannedPoliceClearance.FindAsync(id);
            _context.ScannedPoliceClearance.Remove(scannedPoliceClearance);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScannedPoliceClearanceExists(Guid id)
        {
            return _context.ScannedPoliceClearance.Any(e => e.Id == id);
        }
    }
}
