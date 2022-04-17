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
    public class BioDatasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BioDatasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BioDatas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.BioData.Include(b => b.Maid);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: BioDatas/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bioData = await _context.BioData
                .Include(b => b.Maid)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bioData == null)
            {
                return NotFound();
            }

            return View(bioData);
        }

        // GET: BioDatas/Create
        public IActionResult Create()
        {
            ViewData["MaidId"] = new SelectList(_context.Maid, "Id", "Address");
            return View();
        }

        // POST: BioDatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MaidId,Date,Discription")] BioData bioData)
        {
            if (ModelState.IsValid)
            {
                bioData.Id = Guid.NewGuid();
                _context.Add(bioData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaidId"] = new SelectList(_context.Maid, "Id", "Address", bioData.MaidId);
            return View(bioData);
        }

        // GET: BioDatas/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bioData = await _context.BioData.FindAsync(id);
            if (bioData == null)
            {
                return NotFound();
            }
            ViewData["MaidId"] = new SelectList(_context.Maid, "Id", "Address", bioData.MaidId);
            return View(bioData);
        }

        // POST: BioDatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,MaidId,Date,Discription")] BioData bioData)
        {
            if (id != bioData.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bioData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BioDataExists(bioData.Id))
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
            ViewData["MaidId"] = new SelectList(_context.Maid, "Id", "Address", bioData.MaidId);
            return View(bioData);
        }

        // GET: BioDatas/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bioData = await _context.BioData
                .Include(b => b.Maid)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bioData == null)
            {
                return NotFound();
            }

            return View(bioData);
        }

        // POST: BioDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var bioData = await _context.BioData.FindAsync(id);
            _context.BioData.Remove(bioData);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BioDataExists(Guid id)
        {
            return _context.BioData.Any(e => e.Id == id);
        }
    }
}
