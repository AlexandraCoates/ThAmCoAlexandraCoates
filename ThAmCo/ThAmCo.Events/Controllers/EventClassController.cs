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

    public class EventClassController : Controller
    {
        private readonly EventsDbContext _context;

        public EventClassController(EventsDbContext dbContext)
        {
            _context = dbContext;
        }

        //Gets a list of existing events
        public async Task<ActionResult<IEnumerable<EventClass>>> Index()
        {
            return View(await _context.Events.ToListAsync());
        }

        //Gets a specific event
        public async Task<ActionResult<EventClass>>Details(int? id)
        {
            var Events = await _context.Events.FirstOrDefaultAsync(e => e.EventId == id);
            if (Events == null)
            {
                return NotFound();
            }
            return View(Events);
        }

        public IActionResult  Create()
        {
            return View();
        }

        //Create a new event
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create ([Bind("EventType")]EventClass eventClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<EventClass>>> GetEvents()
        //{
        //    return await _context.Events.ToListAsync();
        //}

        //[HttpGet("{EventId}")]
        //public async Task<ActionResult<EventClass>> GetEvents(int EventId)
        //{
        //    var Events = await _context.Events.FindAsync(EventId);
        //    if (Events == null)
        //    {
        //        return NotFound();
        //    }
        //    return Events;
        //}

        //[HttpPut("{EventId}")]
        //public async Task<IActionResult> PutEvents(int EventId, EventClass eventClass)
        //{
        //    if (EventId != eventClass.EventId)
        //    {
        //        return BadRequest();
        //    }
        //    _context.Entry(eventClass).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!EventExists(EventId))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }
        //    return NoContent();
        //}

        //[HttpPost]
        //public async Task<ActionResult<EventClass>> PostEvents(EventClass eventClass)
        //{
        //    _context.Events.Add(eventClass);
        //    await _context.SaveChangesAsync();
        //    return CreatedAtAction("GetEvents", new { EventClass = eventClass.EventId }, eventClass);
        //}

        //[HttpDelete("{EventId}")]
        //public async Task<ActionResult<EventClass>> DeleteEvent(int EventId)
        //{
        //    var eventClass = await _context.Events.FindAsync(EventId);
        //    if (eventClass == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Events.Remove(eventClass);
        //    await _context.SaveChangesAsync();

        //    return eventClass;
        //}

        //private bool EventExists(int id)
        //{
        //    return _context.Events.Any(e => e.EventId == id);
        //}

    }
}