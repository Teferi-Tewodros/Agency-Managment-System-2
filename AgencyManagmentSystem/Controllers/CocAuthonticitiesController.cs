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
    public class CocAuthonticitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CocAuthonticitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CocAuthonticities
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CocAuthonticity.Include(c => c.Maid);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CocAuthonticities/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cocAuthonticity = await _context.CocAuthonticity
                .Include(c => c.Maid)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cocAuthonticity == null)
            {
                return NotFound();
            }

            return View(cocAuthonticity);
        }

        // GET: CocAuthonticities/Create
        public IActionResult Create()
        {
            ViewData["MaidId"] = new SelectList(_context.Maid, "Id", "Address");
            return View();
        }

        // POST: CocAuthonticities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MaidId,Date,Discription")] CocAuthonticity cocAuthonticity)
        {
            if (ModelState.IsValid)
            {
                cocAuthonticity.Id = Guid.NewGuid();
                _context.Add(cocAuthonticity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaidId"] = new SelectList(_context.Maid, "Id", "Address", cocAuthonticity.MaidId);
            return View(cocAuthonticity);
        }

        // GET: CocAuthonticities/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cocAuthonticity = await _context.CocAuthonticity.FindAsync(id);
            if (cocAuthonticity == null)
            {
                return NotFound();
            }
            ViewData["MaidId"] = new SelectList(_context.Maid, "Id", "Address", cocAuthonticity.MaidId);
            return View(cocAuthonticity);
        }

        // POST: CocAuthonticities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,MaidId,Date,Discription")] CocAuthonticity cocAuthonticity)
        {
            if (id != cocAuthonticity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cocAuthonticity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CocAuthonticityExists(cocAuthonticity.Id))
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
            ViewData["MaidId"] = new SelectList(_context.Maid, "Id", "Address", cocAuthonticity.MaidId);
            return View(cocAuthonticity);
        }

        // GET: CocAuthonticities/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cocAuthonticity = await _context.CocAuthonticity
                .Include(c => c.Maid)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cocAuthonticity == null)
            {
                return NotFound();
            }

            return View(cocAuthonticity);
        }

        // POST: CocAuthonticities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var cocAuthonticity = await _context.CocAuthonticity.FindAsync(id);
            _context.CocAuthonticity.Remove(cocAuthonticity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CocAuthonticityExists(Guid id)
        {
            return _context.CocAuthonticity.Any(e => e.Id == id);
        }
    }
}
