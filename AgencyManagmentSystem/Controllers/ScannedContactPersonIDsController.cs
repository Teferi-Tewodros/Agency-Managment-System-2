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
    public class ScannedContactPersonIDsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ScannedContactPersonIDsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ScannedContactPersonIDs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ScannedContactPersonID.Include(s => s.Maid);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ScannedContactPersonIDs/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scannedContactPersonID = await _context.ScannedContactPersonID
                .Include(s => s.Maid)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (scannedContactPersonID == null)
            {
                return NotFound();
            }

            return View(scannedContactPersonID);
        }

        // GET: ScannedContactPersonIDs/Create
        public IActionResult Create()
        {
            ViewData["MaidId"] = new SelectList(_context.Maid, "Id", "Address");
            return View();
        }

        // POST: ScannedContactPersonIDs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MaidId,DataFiles,FileType,Discription")] ScannedContactPersonID scannedContactPersonID)
        {
            if (ModelState.IsValid)
            {
                scannedContactPersonID.Id = Guid.NewGuid();
                _context.Add(scannedContactPersonID);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaidId"] = new SelectList(_context.Maid, "Id", "Address", scannedContactPersonID.MaidId);
            return View(scannedContactPersonID);
        }

        // GET: ScannedContactPersonIDs/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scannedContactPersonID = await _context.ScannedContactPersonID.FindAsync(id);
            if (scannedContactPersonID == null)
            {
                return NotFound();
            }
            ViewData["MaidId"] = new SelectList(_context.Maid, "Id", "Address", scannedContactPersonID.MaidId);
            return View(scannedContactPersonID);
        }

        // POST: ScannedContactPersonIDs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,MaidId,DataFiles,FileType,Discription")] ScannedContactPersonID scannedContactPersonID)
        {
            if (id != scannedContactPersonID.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(scannedContactPersonID);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScannedContactPersonIDExists(scannedContactPersonID.Id))
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
            ViewData["MaidId"] = new SelectList(_context.Maid, "Id", "Address", scannedContactPersonID.MaidId);
            return View(scannedContactPersonID);
        }

        // GET: ScannedContactPersonIDs/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scannedContactPersonID = await _context.ScannedContactPersonID
                .Include(s => s.Maid)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (scannedContactPersonID == null)
            {
                return NotFound();
            }

            return View(scannedContactPersonID);
        }

        // POST: ScannedContactPersonIDs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var scannedContactPersonID = await _context.ScannedContactPersonID.FindAsync(id);
            _context.ScannedContactPersonID.Remove(scannedContactPersonID);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScannedContactPersonIDExists(Guid id)
        {
            return _context.ScannedContactPersonID.Any(e => e.Id == id);
        }
    }
}
