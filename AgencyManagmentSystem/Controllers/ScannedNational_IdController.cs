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
    public class ScannedNational_IdController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ScannedNational_IdController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ScannedNational_Id
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ScannedNational_Id.Include(s => s.Maid);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ScannedNational_Id/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scannedNational_Id = await _context.ScannedNational_Id
                .Include(s => s.Maid)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (scannedNational_Id == null)
            {
                return NotFound();
            }

            return View(scannedNational_Id);
        }

        // GET: ScannedNational_Id/Create
        public IActionResult Create()
        {
            ViewData["MaidId"] = new SelectList(_context.Maid, "Id", "Address");
            return View();
        }

        // POST: ScannedNational_Id/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MaidId,DataFiles,FileType,Discription")] ScannedNational_Id scannedNational_Id)
        {
            if (ModelState.IsValid)
            {
                scannedNational_Id.Id = Guid.NewGuid();
                _context.Add(scannedNational_Id);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaidId"] = new SelectList(_context.Maid, "Id", "Address", scannedNational_Id.MaidId);
            return View(scannedNational_Id);
        }

        // GET: ScannedNational_Id/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scannedNational_Id = await _context.ScannedNational_Id.FindAsync(id);
            if (scannedNational_Id == null)
            {
                return NotFound();
            }
            ViewData["MaidId"] = new SelectList(_context.Maid, "Id", "Address", scannedNational_Id.MaidId);
            return View(scannedNational_Id);
        }

        // POST: ScannedNational_Id/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,MaidId,DataFiles,FileType,Discription")] ScannedNational_Id scannedNational_Id)
        {
            if (id != scannedNational_Id.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(scannedNational_Id);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScannedNational_IdExists(scannedNational_Id.Id))
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
            ViewData["MaidId"] = new SelectList(_context.Maid, "Id", "Address", scannedNational_Id.MaidId);
            return View(scannedNational_Id);
        }

        // GET: ScannedNational_Id/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scannedNational_Id = await _context.ScannedNational_Id
                .Include(s => s.Maid)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (scannedNational_Id == null)
            {
                return NotFound();
            }

            return View(scannedNational_Id);
        }

        // POST: ScannedNational_Id/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var scannedNational_Id = await _context.ScannedNational_Id.FindAsync(id);
            _context.ScannedNational_Id.Remove(scannedNational_Id);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScannedNational_IdExists(Guid id)
        {
            return _context.ScannedNational_Id.Any(e => e.Id == id);
        }
    }
}
