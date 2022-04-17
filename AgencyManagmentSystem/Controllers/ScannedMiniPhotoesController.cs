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
    public class ScannedMiniPhotoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ScannedMiniPhotoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ScannedMiniPhotoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ScannedMiniPhoto.Include(s => s.Maid);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ScannedMiniPhotoes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scannedMiniPhoto = await _context.ScannedMiniPhoto
                .Include(s => s.Maid)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (scannedMiniPhoto == null)
            {
                return NotFound();
            }

            return View(scannedMiniPhoto);
        }

        // GET: ScannedMiniPhotoes/Create
        public IActionResult Create()
        {
            ViewData["MaidId"] = new SelectList(_context.Maid, "Id", "Address");
            return View();
        }

        // POST: ScannedMiniPhotoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MaidId,DataFiles,FileType,Discription")] ScannedMiniPhoto scannedMiniPhoto)
        {
            if (ModelState.IsValid)
            {
                scannedMiniPhoto.Id = Guid.NewGuid();
                _context.Add(scannedMiniPhoto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaidId"] = new SelectList(_context.Maid, "Id", "Address", scannedMiniPhoto.MaidId);
            return View(scannedMiniPhoto);
        }

        // GET: ScannedMiniPhotoes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scannedMiniPhoto = await _context.ScannedMiniPhoto.FindAsync(id);
            if (scannedMiniPhoto == null)
            {
                return NotFound();
            }
            ViewData["MaidId"] = new SelectList(_context.Maid, "Id", "Address", scannedMiniPhoto.MaidId);
            return View(scannedMiniPhoto);
        }

        // POST: ScannedMiniPhotoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,MaidId,DataFiles,FileType,Discription")] ScannedMiniPhoto scannedMiniPhoto)
        {
            if (id != scannedMiniPhoto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(scannedMiniPhoto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScannedMiniPhotoExists(scannedMiniPhoto.Id))
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
            ViewData["MaidId"] = new SelectList(_context.Maid, "Id", "Address", scannedMiniPhoto.MaidId);
            return View(scannedMiniPhoto);
        }

        // GET: ScannedMiniPhotoes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scannedMiniPhoto = await _context.ScannedMiniPhoto
                .Include(s => s.Maid)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (scannedMiniPhoto == null)
            {
                return NotFound();
            }

            return View(scannedMiniPhoto);
        }

        // POST: ScannedMiniPhotoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var scannedMiniPhoto = await _context.ScannedMiniPhoto.FindAsync(id);
            _context.ScannedMiniPhoto.Remove(scannedMiniPhoto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScannedMiniPhotoExists(Guid id)
        {
            return _context.ScannedMiniPhoto.Any(e => e.Id == id);
        }
    }
}
