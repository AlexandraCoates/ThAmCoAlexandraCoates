using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ThAmCo.Events.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ThAmCo.Events.Controllers
{

    public class StaffingController : Controller
    {
        private readonly EventsDbContext _context;

        public StaffingController(EventsDbContext dbContext)
        {
            _context = dbContext;
        }

        //Gets a list of existing Staffing
        public async Task<ActionResult<IEnumerable<Staffing>>> Index()
        {
            var staffingContext = _context.Staffings
                .Include(s => s.staff)
                .Include(s => s.eventClass);
            return View(await staffingContext.ToListAsync());
        }

        //Gets a specific staff member
        public async Task<ActionResult<Staffing>> Details(int? id)
        {
            var Staffing = await _context.Staffings
                .Include(s => s.staff)
                .FirstOrDefaultAsync(s => s.StaffingId == id);
            if (Staffing == null)
            {
                return NotFound();
            }
            return View(Staffing);
        }

        // Create view for staff members
        public IActionResult Create()
        {
            ViewBag.EventId = new SelectList(_context.Events, "EventId", "EventTitle");
            ViewBag.StaffId = new SelectList(_context.Staffs, "StaffId", "NameFirst");
            return View();
        }

        //Create a new staff member
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StaffingId,StaffId,EventId,staff,eventClass")] Staffing staffing)
        {
            if (ModelState.IsValid)
            {
                _context.Add(staffing);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        // Creates the edit view for a specific staff member
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffing = await _context.Staffings.FindAsync(id);
            if (staffing == null)
            {
                return NotFound();
            }
            ViewBag.EventId = new SelectList(_context.Events, "EventId", "EventTitle");
            ViewBag.StaffId = new SelectList(_context.Staffs, "StaffId", "NameFirst");
            return View(staffing);
        }

        // Edits a specific guest booking
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StaffingId,StaffId,EventId,staff,eventClass")] Staffing staffing)
        {
            if (id != staffing.StaffingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(staffing);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaffingExists(staffing.StaffId))
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
            return View(staffing);
        }

        // Creates the delete view for a specific staff member
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff = await _context.Staffings
                .Include(s => s.eventClass)
                .Include(s => s.staff)
                .FirstOrDefaultAsync(s => s.StaffingId == id);
            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }

        // Deletes a specific staff member
        // TODO: Soft Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var staffing = await _context.Staffings.FindAsync(id);
            _context.Staffings.Remove(staffing);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StaffingExists(int id)
        {
            return _context.Staffings.Any(e => e.StaffingId == id);
        }

    }
}