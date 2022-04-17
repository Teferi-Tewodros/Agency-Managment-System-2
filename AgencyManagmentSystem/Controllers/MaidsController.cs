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
    public class MaidsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MaidsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Maids
        public async Task<IActionResult> Index()
        {
            return View(await _context.Maid.ToListAsync());
        }

        // GET: Maids/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maid = await _context.Maid
                .FirstOrDefaultAsync(m => m.Id == id);
            if (maid == null)
            {
                return NotFound();
            }

            return View(maid);
        }

        // GET: Maids/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Maids/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SurName,GIVEN_NAMES,Birthday,Gender,Marital_status,Religion,Job,Nationality,Qualifications,Experience,Experience_Country,Passport_NO,City,Address,Mobile,Country,Passport_issue_place,Passport_issue_date,Passport_expire,IsSelected,IsRejected,TimeStamp")] Maid maid)
        {
            if (ModelState.IsValid)
            {
                maid.Id = Guid.NewGuid();
                _context.Add(maid);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(maid);
        }

        // GET: Maids/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maid = await _context.Maid.FindAsync(id);
            if (maid == null)
            {
                return NotFound();
            }
            return View(maid);
        }

        // POST: Maids/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,SurName,GIVEN_NAMES,Birthday,Gender,Marital_status,Religion,Job,Nationality,Qualifications,Experience,Experience_Country,Passport_NO,City,Address,Mobile,Country,Passport_issue_place,Passport_issue_date,Passport_expire,IsSelected,IsRejected,TimeStamp")] Maid maid)
        {
            if (id != maid.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(maid);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaidExists(maid.Id))
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
            return View(maid);
        }

        // GET: Maids/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maid = await _context.Maid
                .FirstOrDefaultAsync(m => m.Id == id);
            if (maid == null)
            {
                return NotFound();
            }

            return View(maid);
        }

        // POST: Maids/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var maid = await _context.Maid.FindAsync(id);
            _context.Maid.Remove(maid);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaidExists(Guid id)
        {
            return _context.Maid.Any(e => e.Id == id);
        }
    }
}
