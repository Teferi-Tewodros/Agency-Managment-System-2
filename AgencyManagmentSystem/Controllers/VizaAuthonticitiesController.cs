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
    public class VizaAuthonticitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VizaAuthonticitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: VizaAuthonticities
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.VizaAuthonticity.Include(v => v.Maid);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: VizaAuthonticities/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vizaAuthonticity = await _context.VizaAuthonticity
                .Include(v => v.Maid)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vizaAuthonticity == null)
            {
                return NotFound();
            }

            return View(vizaAuthonticity);
        }

        // GET: VizaAuthonticities/Create
        public IActionResult Create()
        {
            ViewData["MaidId"] = new SelectList(_context.Maid, "Id", "Address");
            return View();
        }

        // POST: VizaAuthonticities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MaidId,Date,Discription")] VizaAuthonticity vizaAuthonticity)
        {
            if (ModelState.IsValid)
            {
                vizaAuthonticity.Id = Guid.NewGuid();
                _context.Add(vizaAuthonticity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaidId"] = new SelectList(_context.Maid, "Id", "Address", vizaAuthonticity.MaidId);
            return View(vizaAuthonticity);
        }

        // GET: VizaAuthonticities/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vizaAuthonticity = await _context.VizaAuthonticity.FindAsync(id);
            if (vizaAuthonticity == null)
            {
                return NotFound();
            }
            ViewData["MaidId"] = new SelectList(_context.Maid, "Id", "Address", vizaAuthonticity.MaidId);
            return View(vizaAuthonticity);
        }

        // POST: VizaAuthonticities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,MaidId,Date,Discription")] VizaAuthonticity vizaAuthonticity)
        {
            if (id != vizaAuthonticity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vizaAuthonticity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VizaAuthonticityExists(vizaAuthonticity.Id))
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
            ViewData["MaidId"] = new SelectList(_context.Maid, "Id", "Address", vizaAuthonticity.MaidId);
            return View(vizaAuthonticity);
        }

        // GET: VizaAuthonticities/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vizaAuthonticity = await _context.VizaAuthonticity
                .Include(v => v.Maid)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vizaAuthonticity == null)
            {
                return NotFound();
            }

            return View(vizaAuthonticity);
        }

        // POST: VizaAuthonticities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var vizaAuthonticity = await _context.VizaAuthonticity.FindAsync(id);
            _context.VizaAuthonticity.Remove(vizaAuthonticity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VizaAuthonticityExists(Guid id)
        {
            return _context.VizaAuthonticity.Any(e => e.Id == id);
        }
    }
}
