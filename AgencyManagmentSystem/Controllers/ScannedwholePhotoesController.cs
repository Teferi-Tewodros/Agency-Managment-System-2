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
    public class ScannedwholePhotoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ScannedwholePhotoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ScannedwholePhotoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ScannedwholePhoto.Include(s => s.Maid);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ScannedwholePhotoes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scannedwholePhoto = await _context.ScannedwholePhoto
                .Include(s => s.Maid)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (scannedwholePhoto == null)
            {
                return NotFound();
            }

            return View(scannedwholePhoto);
        }

        // GET: ScannedwholePhotoes/Create
        public IActionResult Create()
        {
            ViewData["MaidId"] = new SelectList(_context.Maid, "Id", "Address");
            return View();
        }

        // POST: ScannedwholePhotoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MaidId,DataFiles,FileType,Discription")] ScannedwholePhoto scannedwholePhoto)
        {
            if (ModelState.IsValid)
            {
                scannedwholePhoto.Id = Guid.NewGuid();
                _context.Add(scannedwholePhoto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaidId"] = new SelectList(_context.Maid, "Id", "Address", scannedwholePhoto.MaidId);
            return View(scannedwholePhoto);
        }

        // GET: ScannedwholePhotoes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scannedwholePhoto = await _context.ScannedwholePhoto.FindAsync(id);
            if (scannedwholePhoto == null)
            {
                return NotFound();
            }
            ViewData["MaidId"] = new SelectList(_context.Maid, "Id", "Address", scannedwholePhoto.MaidId);
            return View(scannedwholePhoto);
        }

        // POST: ScannedwholePhotoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,MaidId,DataFiles,FileType,Discription")] ScannedwholePhoto scannedwholePhoto)
        {
            if (id != scannedwholePhoto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(scannedwholePhoto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScannedwholePhotoExists(scannedwholePhoto.Id))
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
            ViewData["MaidId"] = new SelectList(_context.Maid, "Id", "Address", scannedwholePhoto.MaidId);
            return View(scannedwholePhoto);
        }

        // GET: ScannedwholePhotoes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scannedwholePhoto = await _context.ScannedwholePhoto
                .Include(s => s.Maid)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (scannedwholePhoto == null)
            {
                return NotFound();
            }

            return View(scannedwholePhoto);
        }

        // POST: ScannedwholePhotoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var scannedwholePhoto = await _context.ScannedwholePhoto.FindAsync(id);
            _context.ScannedwholePhoto.Remove(scannedwholePhoto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScannedwholePhotoExists(Guid id)
        {
            return _context.ScannedwholePhoto.Any(e => e.Id == id);
        }
    }
}
