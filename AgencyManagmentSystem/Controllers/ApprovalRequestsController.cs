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
    public class ApprovalRequestsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ApprovalRequestsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ApprovalRequests
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ApprovalRequest.Include(a => a.Maid);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ApprovalRequests/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var approvalRequest = await _context.ApprovalRequest
                .Include(a => a.Maid)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (approvalRequest == null)
            {
                return NotFound();
            }

            return View(approvalRequest);
        }

        // GET: ApprovalRequests/Create
        public IActionResult Create()
        {
            ViewData["MaidId"] = new SelectList(_context.Maid, "Id", "Address");
            return View();
        }

        // POST: ApprovalRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MaidId,Date,Discription")] ApprovalRequest approvalRequest)
        {
            if (ModelState.IsValid)
            {
                approvalRequest.Id = Guid.NewGuid();
                _context.Add(approvalRequest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaidId"] = new SelectList(_context.Maid, "Id", "Address", approvalRequest.MaidId);
            return View(approvalRequest);
        }

        // GET: ApprovalRequests/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var approvalRequest = await _context.ApprovalRequest.FindAsync(id);
            if (approvalRequest == null)
            {
                return NotFound();
            }
            ViewData["MaidId"] = new SelectList(_context.Maid, "Id", "Address", approvalRequest.MaidId);
            return View(approvalRequest);
        }

        // POST: ApprovalRequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,MaidId,Date,Discription")] ApprovalRequest approvalRequest)
        {
            if (id != approvalRequest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(approvalRequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApprovalRequestExists(approvalRequest.Id))
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
            ViewData["MaidId"] = new SelectList(_context.Maid, "Id", "Address", approvalRequest.MaidId);
            return View(approvalRequest);
        }

        // GET: ApprovalRequests/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var approvalRequest = await _context.ApprovalRequest
                .Include(a => a.Maid)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (approvalRequest == null)
            {
                return NotFound();
            }

            return View(approvalRequest);
        }

        // POST: ApprovalRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var approvalRequest = await _context.ApprovalRequest.FindAsync(id);
            _context.ApprovalRequest.Remove(approvalRequest);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApprovalRequestExists(Guid id)
        {
            return _context.ApprovalRequest.Any(e => e.Id == id);
        }
    }
}
