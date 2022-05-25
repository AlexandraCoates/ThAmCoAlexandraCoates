using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.EntityFrameworkCore;
using ThAmCo.Events.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ThAmCo.Events.Controllers
{

    public class GuestBookingController : Controller
    {
        private readonly EventsDbContext _context;

        public GuestBookingController(EventsDbContext dbContext)
        {
            _context = dbContext;
        }

        // Gets a list of exisiting guest bookings 
        public async Task<ActionResult<IEnumerable<GuestBooking>>> Index()
        {
            var guestBookingContext = _context.GuestBookings.Include(g => g.Customer)
                .Include(g => g.eventClass);
            return View(await guestBookingContext.ToListAsync());
        }

        // Gets a specific Guest Booking
        public async Task<ActionResult<IEnumerable<GuestBooking>>> Details(int? id)
        {
            var GuestBookings = await _context.GuestBookings.Include(g => g.Customer)
                .Include(g => g.eventClass)
                .FirstOrDefaultAsync(g => g.GuestBookingId == id);
            if (GuestBookings == null)
            {
                return NotFound();
            }
            return View(GuestBookings);
        }

        public IActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(_context.Customers, "CustomerId", "NameFirst");
            ViewBag.EventId = new SelectList(_context.Events, "EventId", "EventTitle");
            return View();
        }

        // Create New Guest Booking
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId, EventId, attended")] GuestBooking guestBooking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(guestBooking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        // Get a specific guest booking for the edit view
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.GuestBookings.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }

            ViewBag.CustomerId = new SelectList(_context.Customers, "CustomerId", "NameFirst");
            ViewBag.EventId = new SelectList(_context.Events, "EventId", "EventTitle");
            return View(booking);
        }

        // Edits a specific guest booking
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GuestBookingId,EventId,CustomerId,attendance")] GuestBooking booking, string returnUrl)
        {
            if (id != booking.GuestBookingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(booking);
                    await _context.SaveChangesAsync();
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingExists(booking.GuestBookingId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                
            }
            return View(booking);
        }

        // Creates the delete view for a specific guest booking
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.GuestBookings
                .Include(g => g.eventClass)
                .Include(g => g.Customer)
                .FirstOrDefaultAsync(g => g.GuestBookingId == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // Deletes a specific guest booking
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.GuestBookings.FindAsync(id);
            _context.GuestBookings.Remove(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool BookingExists(int id)
        {
            return _context.GuestBookings.Any(e => e.GuestBookingId == id);
        }


        //}
    }
}