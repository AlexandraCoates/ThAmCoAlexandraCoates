using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ThAmCo.Events.Data;

namespace ThAmCo.Events.Controllers
{
    public class StaffController : Controller
    {
        private readonly EventsDbContext _context;

        public StaffController(EventsDbContext dbContext)
        {
            _context = dbContext;
        }

        //Gets a list of existing Staff
        public async Task<ActionResult<IEnumerable<Staff>>> Index()
        {
            return View(await _context.Staffs.ToListAsync());
        }

        //Gets a specific staff member
        public async Task<ActionResult<Staff>> Details(int? id)
        {
            var Staffs = await _context.Staffs.FirstOrDefaultAsync(s => s.StaffId == id);
            if (Staffs == null)
            {
                return NotFound();
            }

            IEnumerable<Staffing> Staffing = new List<Staffing>();
            Staffing = await _context.Staffings
                .Include(s => s.eventClass)
                .Where(s => s.StaffId == id)
                .Where(s => s.eventClass.EventDate > DateTime.Now)               
                .ToListAsync();

            ViewBag.Staffing = Staffing;
            return View(Staffs);
        }

        // Create view for staff members
        public IActionResult Create()
        {
            return View();
        }

        //Create a new staff member
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NameFirst, NameLast, Address, PostCode, Email, Phone, FirstAider")] Staff staff)
        {
            if (ModelState.IsValid)
            {
                _context.Add(staff);
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

            var staff = await _context.Staffs.FindAsync(id);
            if (staff == null)
            {
                return NotFound();
            }
            return View(staff);
        }

        // Edits a specific guest booking
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StaffId,NameFirst,NameLast,Address,PostCode,Email,Phone,FirstAider")] Staff staff)
        {
            if (id != staff.StaffId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(staff);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaffExists(staff.StaffId))
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
            return View(staff);
        }

        // Creates the delete view for a specific staff member
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff = await _context.Staffs.FirstOrDefaultAsync(c => c.StaffId == id);
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
            var staff = await _context.Staffs.FindAsync(id);
            _context.Staffs.Remove(staff);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Checks to see if a staff member exists
        private bool StaffExists(int id)
        {
            return _context.Staffs.Any(e => e.StaffId == id);
        }
    }
}
