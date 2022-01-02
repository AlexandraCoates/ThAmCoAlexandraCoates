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
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : Controller
    {
        private readonly EventsDbContext _context;

        public StaffController(EventsDbContext dbContext)
        {
            _context = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Staff>>> GetStaff()
        {
            return await _context.Staff.ToListAsync();
        }

        [HttpGet("{StaffId}")]
        public async Task<ActionResult<Staff>> GetStaff(int StaffId)
        {
            var Staff = await _context.Staff.FindAsync(StaffId);
            if (Staff == null)
            {
                return NotFound();
            }
            return Staff;
        }

        [HttpPut("{StaffId}")]
        public async Task<IActionResult> PutStaff(int StaffId, Staff staff)
        {
            if (StaffId != staff.StaffId)
            {
                return BadRequest();
            }
            _context.Entry(staff).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StaffExists(StaffId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Staff>> PostStaff(Staff staff)
        {
            _context.FoodBookings.Add(staff);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetStaff", new { Staff = staff.StaffId }, staff);
        }

        [HttpDelete("{StaffId}")]
        public async Task<ActionResult<Staff>> DeleteStaff(int StaffId)
        {
            var staff = await _context.Staff.FindAsync(StaffId);
            if (staff == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(staff);
            await _context.SaveChangesAsync();

            return staff;
        }

        private bool StaffExists(int id)
        {
            return _context.Staff.Any(e => e.StaffId == id);
        }

    }
}
