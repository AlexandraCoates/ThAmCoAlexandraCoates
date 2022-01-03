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
    public class StaffingController : Controller
    {
        private readonly EventsDbContext _context;

        public StaffingController(EventsDbContext dbContext)
        {
            _context = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Staffing>>> GetStaffing()
        {
            return await _context.Staffings.ToListAsync();
        }

        [HttpGet("{StaffingId}")]
        public async Task<ActionResult<Staffing>> GetStaffing(int StaffingId)
        {
            var Staffing = await _context.Staffings.FindAsync(StaffingId);
            if (Staffing == null)
            {
                return NotFound();
            }
            return Staffing;
        }

        [HttpPut("{StaffingId}")]
        public async Task<IActionResult> PutStaffing(int StaffingId, Staffing staffing)
        {
            if (StaffingId != staffing.StaffingId)
            {
                return BadRequest();
            }
            _context.Entry(staffing).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StaffingExists(StaffingId))
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
        public async Task<ActionResult<Staffing>> PostStaffing(Staffing staffing)
        {
            _context.Staffings.Add(staffing);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetStaffing", new { Staffing = staffing.StaffingId }, staffing);
        }

        [HttpDelete("{StaffingId}")]
        public async Task<ActionResult<Staffing>> DeleteStaffing(int StaffingId)
        {
            var staffing = await _context.Staffings.FindAsync(StaffingId);
            if (staffing == null)
            {
                return NotFound();
            }

            _context.Staffings.Remove(staffing);
            await _context.SaveChangesAsync();

            return staffing;
        }

        private bool StaffingExists(int id)
        {
            return _context.Staffings.Any(e => e.StaffingId == id);
        }

    }
}