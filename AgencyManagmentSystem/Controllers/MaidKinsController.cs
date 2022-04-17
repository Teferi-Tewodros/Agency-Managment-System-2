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
    public class MaidKinsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MaidKinsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MaidKins
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.MaidKin.Include(m => m.Maid);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: MaidKins/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maidKin = await _context.MaidKin
                .Include(m => m.Maid)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (maidKin == null)
            {
                return NotFound();
            }

            return View(maidKin);
        }

        // GET: MaidKins/Create
        public IActionResult Create()
        {
            ViewData["MaidId"] = new SelectList(_context.Maid, "Id", "Address");
            return View();
        }

        // POST: MaidKins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MaidId,Relative_name,Relative_kinship,Relative_phone,Relative_address,Relative_Id")] MaidKin maidKin)
        {
            if (ModelState.IsValid)
            {
                maidKin.Id = Guid.NewGuid();
                _context.Add(maidKin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaidId"] = new SelectList(_context.Maid, "Id", "Address", maidKin.MaidId);
            return View(maidKin);
        }

        // GET: MaidKins/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maidKin = await _context.MaidKin.FindAsync(id);
            if (maidKin == null)
            {
                return NotFound();
            }
            ViewData["MaidId"] = new SelectList(_context.Maid, "Id", "Address", maidKin.MaidId);
            return View(maidKin);
        }

        // POST: MaidKins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,MaidId,Relative_name,Relative_kinship,Relative_phone,Relative_address,Relative_Id")] MaidKin maidKin)
        {
            if (id != maidKin.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(maidKin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaidKinExists(maidKin.Id))
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
            ViewData["MaidId"] = new SelectList(_context.Maid, "Id", "Address", maidKin.MaidId);
            return View(maidKin);
        }

        // GET: MaidKins/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maidKin = await _context.MaidKin
                .Include(m => m.Maid)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (maidKin == null)
            {
                return NotFound();
            }

            return View(maidKin);
        }

        // POST: MaidKins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var maidKin = await _context.MaidKin.FindAsync(id);
            _context.MaidKin.Remove(maidKin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaidKinExists(Guid id)
        {
            return _context.MaidKin.Any(e => e.Id == id);
        }
    }
}
