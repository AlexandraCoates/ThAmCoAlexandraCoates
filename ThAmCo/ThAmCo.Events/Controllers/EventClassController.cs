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
    public class EventClassController : Controller
    {
        private readonly EventsDbContext _context;

        public EventClassController(EventsDbContext dbContext)
        {
            _context = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventClass>>> GetEvents()
        {
            return await _context.EventClass.ToListAsync();
        }

        [HttpGet("{EventId}")]
        public async Task<ActionResult<Customer>> GetEvents(int EventId)
        {
            var Events = await _context.Events.FindAsync(EventId);
            if (Events == null)
            {
                return NotFound();
            }
            return Events;
        }

        [HttpPut("{EventId}")]
        public async Task<IActionResult> PutEvents(int EventId, EventClass eventClass)
        {
            if (EventId != eventClass.EventId)
            {
                return BadRequest();
            }
            _context.Entry(eventClass).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(EventId))
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
        public async Task<ActionResult<EventClass>> PostEvents(EventClass eventClass)
        {
            _context.EventClass.Add(eventClass);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetEvents", new { EventClass = eventClass.EventId }, eventClass);
        }

        [HttpDelete("{EventId}")]
        public async Task<ActionResult<EventClass>> DeleteEvent(int EventId)
        {
            var eventClass = await _context.EventClass.FindAsync(EventId);
            if (eventClass == null)
            {
                return NotFound();
            }

            _context.EventClass.Remove(eventClass);
            await _context.SaveChangesAsync();

            return eventClass;
        }

        private bool EventExists(int id)
        {
            return _context.EventClass.Any(e => e.EventId == id);
        }

    }
}