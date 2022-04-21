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
            return View(Staffs);
        }

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
    }
}
