using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ThAmCo.Events.Data;
using ThAmCo.Events.Models;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ThAmCo.Events.Controllers
{

    public class EventClassController : Controller
    {
        private readonly EventsDbContext _context;

        HttpClient client;

        public EventClassController(EventsDbContext dbContext)
        {
            _context = dbContext;

            client = new HttpClient();
            client.BaseAddress = new System.Uri("https://localhost:5002");
            client.DefaultRequestHeaders.Accept.ParseAdd("application/json");
        }

        //Gets a list of existing events
        public async Task<ActionResult<IEnumerable<EventClass>>> Index()
        {
            var Events = await _context.Events
                .Include(e => e.Bookings)
                .ToListAsync();

            var EventsExpired = await _context.Events
                .Where(e => e.EventDate < DateTime.Now)
                .Include(e => e.Bookings)
                .ToListAsync();

            var EventsUpcoming = await _context.Events
                .Where(e => e.EventDate > DateTime.Now)
                .Include(e => e.Bookings)
                .ToListAsync();

            var Bookings = await _context.GuestBookings.ToListAsync();
            ViewBag.Bookings = Bookings;
            ViewBag.Upcoming = EventsUpcoming;
            ViewBag.Expired = EventsExpired;
            return View(Events);
        }

        //Gets a specific event
        public async Task<ActionResult<EventClass>>Details(int? id)
        {
            var Events = await _context.Events
                .Include(e => e.Staffing)
                .FirstOrDefaultAsync(e => e.EventId == id);
            
            if (Events == null)
            {
                return NotFound();
            }


            IEnumerable<Staffing> Staffing = new List<Staffing>();
            Staffing = await _context.Staffings
                .Where(s => s.EventId == id)
                .Include(s => s.staff)
                .ToListAsync();
            Events.Staffing = Staffing;

            IEnumerable<GuestBooking> Bookings = new List<GuestBooking>();
            Bookings = await _context.GuestBookings
                .Where(g => g.EventId == id)
                .Include(g => g.Customer)
                .ToListAsync();
            Events.Bookings = Bookings;
            ViewBag.GuestCount = Bookings.Count();
            return View(Events);
        }


        // Create view for new Events
        // Pulls from the Venues service to get the EventType and puts them in to a ViewBag.
        public async Task<IActionResult>  Create()
        {
            IEnumerable<EventTypeDTO> eventTypes = new List<EventTypeDTO>();
            HttpResponseMessage response = await client.GetAsync("api/EventTypes");
            if(response.IsSuccessStatusCode)
            {
                eventTypes = await response.Content.ReadAsAsync<IEnumerable<EventTypeDTO>>();
            }
            ViewBag.EventTypes = new SelectList(eventTypes, "Id", "Title");
            return View();
        }

        //Create a new event
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create ([Bind("EventType,EventTitle,EventDate")]EventClass eventClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        // Creates the edit view for a specific event
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var events = await _context.Events.FindAsync(id);
            if (events == null)
            {
                return NotFound();
            }
            return View(events);
        }


        // Edits a specific event
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventId,EventTitle,EventType,EventDate")] EventClass events)
        {
            if (id != events.EventId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(events);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(events.EventId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(events);
        }

        // Creates the delete view for a specific Event
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var events = await _context.Events.FirstOrDefaultAsync(c => c.EventId == id);
            if (events == null)
            {
                return NotFound();
            }

            return View(events);
        }

        // Deletes a specific event
        // TODO: Soft Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var events = await _context.Events.FindAsync(id);
            _context.Events.Remove(events);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Checks to see if an event exists
        private bool EventExists(int id)
        {
            return _context.Events.Any(e => e.EventId == id);
        }

    }
}