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
    public class MaidAdressesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MaidAdressesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MaidAdresses
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.MaidAdress.Include(m => m.Maid);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: MaidAdresses/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maidAdress = await _context.MaidAdress
                .Include(m => m.Maid)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (maidAdress == null)
            {
                return NotFound();
            }

            return View(maidAdress);
        }

        // GET: MaidAdresses/Create
        public IActionResult Create()
        {
            ViewData["MaidId"] = new SelectList(_context.Maid, "Id", "Address");
            return View();
        }

        // POST: MaidAdresses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MaidId,Region,Zone,Wereda,Kebele,City,SubCity,House_No")] MaidAdress maidAdress)
        {
            if (ModelState.IsValid)
            {
                maidAdress.Id = Guid.NewGuid();
                _context.Add(maidAdress);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaidId"] = new SelectList(_context.Maid, "Id", "Address", maidAdress.MaidId);
            return View(maidAdress);
        }

        // GET: MaidAdresses/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maidAdress = await _context.MaidAdress.FindAsync(id);
            if (maidAdress == null)
            {
                return NotFound();
            }
            ViewData["MaidId"] = new SelectList(_context.Maid, "Id", "Address", maidAdress.MaidId);
            return View(maidAdress);
        }

        // POST: MaidAdresses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,MaidId,Region,Zone,Wereda,Kebele,City,SubCity,House_No")] MaidAdress maidAdress)
        {
            if (id != maidAdress.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(maidAdress);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaidAdressExists(maidAdress.Id))
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
            ViewData["MaidId"] = new SelectList(_context.Maid, "Id", "Address", maidAdress.MaidId);
            return View(maidAdress);
        }

        // GET: MaidAdresses/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maidAdress = await _context.MaidAdress
                .Include(m => m.Maid)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (maidAdress == null)
            {
                return NotFound();
            }

            return View(maidAdress);
        }

        // POST: MaidAdresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var maidAdress = await _context.MaidAdress.FindAsync(id);
            _context.MaidAdress.Remove(maidAdress);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaidAdressExists(Guid id)
        {
            return _context.MaidAdress.Any(e => e.Id == id);
        }
    }
}
