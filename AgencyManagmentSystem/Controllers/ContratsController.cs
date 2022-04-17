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
    public class ContratsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContratsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Contrats
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Contrat.Include(c => c.Agents).Include(c => c.Maid);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Contrats/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contrat = await _context.Contrat
                .Include(c => c.Agents)
                .Include(c => c.Maid)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contrat == null)
            {
                return NotFound();
            }

            return View(contrat);
        }

        // GET: Contrats/Create
        public IActionResult Create()
        {
            ViewData["AgentsId"] = new SelectList(_context.Agents, "Id", "Agency_Name");
            ViewData["MaidId"] = new SelectList(_context.Maid, "Id", "Address");
            return View();
        }

        // POST: Contrats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MaidId,AgentsId,Employer_Name,Employer_City,National_Id,Employer_Telephone,Employer_email")] Contrat contrat)
        {
            if (ModelState.IsValid)
            {
                contrat.Id = Guid.NewGuid();
                _context.Add(contrat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AgentsId"] = new SelectList(_context.Agents, "Id", "Agency_Name", contrat.AgentsId);
            ViewData["MaidId"] = new SelectList(_context.Maid, "Id", "Address", contrat.MaidId);
            return View(contrat);
        }

        // GET: Contrats/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contrat = await _context.Contrat.FindAsync(id);
            if (contrat == null)
            {
                return NotFound();
            }
            ViewData["AgentsId"] = new SelectList(_context.Agents, "Id", "Agency_Name", contrat.AgentsId);
            ViewData["MaidId"] = new SelectList(_context.Maid, "Id", "Address", contrat.MaidId);
            return View(contrat);
        }

        // POST: Contrats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,MaidId,AgentsId,Employer_Name,Employer_City,National_Id,Employer_Telephone,Employer_email")] Contrat contrat)
        {
            if (id != contrat.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contrat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContratExists(contrat.Id))
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
            ViewData["AgentsId"] = new SelectList(_context.Agents, "Id", "Agency_Name", contrat.AgentsId);
            ViewData["MaidId"] = new SelectList(_context.Maid, "Id", "Address", contrat.MaidId);
            return View(contrat);
        }

        // GET: Contrats/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contrat = await _context.Contrat
                .Include(c => c.Agents)
                .Include(c => c.Maid)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contrat == null)
            {
                return NotFound();
            }

            return View(contrat);
        }

        // POST: Contrats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var contrat = await _context.Contrat.FindAsync(id);
            _context.Contrat.Remove(contrat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContratExists(Guid id)
        {
            return _context.Contrat.Any(e => e.Id == id);
        }
    }
}
