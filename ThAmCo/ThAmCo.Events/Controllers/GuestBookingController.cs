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
    //[Route("api/[controller]")]
    //[ApiController]
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
            //var guestBookingContext = _context.Events.Include(g => g.EventId);
            //guestBookingContext = _context.Events.Include(g => g.CustomerId);
            return View(await _context.GuestBookings.ToListAsync());
        }

        // Gets a specific Guest Booking
        public async Task<ActionResult<IEnumerable<GuestBooking>>> Details(int? id)
        {
            var GuestBookings = await _context.GuestBookings.FirstOrDefaultAsync(g => g.GuestBookingId == id);
            if (GuestBookings == null)
            {
                return NotFound();
            }
            return View(GuestBookings);
        }

        public IActionResult Create()
        {
            return View();
        }

        // Create New Guest Booking
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Customer, EventClass")] GuestBooking guestBooking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(guestBooking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        //    [HttpGet]
        //    public async Task<ActionResult<IEnumerable<GuestBooking>>> GetGuestBookings()
        //    {
        //        return await _context.GuestBookings.ToListAsync();
        //    }

        //    [HttpGet("{GuestBookingId}")]
        //    public async Task<ActionResult<GuestBooking>> GetGuestBookings(int GuestBookingId)
        //    {
        //        var GuestBookings = await _context.GuestBookings.FindAsync(GuestBookingId);
        //        if (GuestBookings == null)
        //        {
        //            return NotFound();
        //        }
        //        return GuestBookings;
        //    }

        //    [HttpPut("{GuestBookingId}")]
        //    public async Task<IActionResult> PutGuestBookings(int GuestBookingId, GuestBooking guestBooking)
        //    {
        //        if (GuestBookingId != guestBooking.CustomerId)
        //        {
        //            return BadRequest();
        //        }
        //        _context.Entry(guestBooking).State = EntityState.Modified;

        //        try
        //        {
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!GuestBookingExists(GuestBookingId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return NoContent();
        //    }

        //    [HttpPost]
        //    public async Task<ActionResult<GuestBooking>> PostFoodBookings(GuestBooking guestBooking)
        //    {
        //        _context.GuestBookings.Add(guestBooking);
        //        await _context.SaveChangesAsync();
        //        return CreatedAtAction("GetGuestBooking", new { GuestBooking = guestBooking.GuestBookingId }, guestBooking);
        //    }

        //    [HttpDelete("{GuestBookingId}")]
        //    public async Task<ActionResult<GuestBooking>> DeleteGuestBooking(int GuestBookingId)
        //    {
        //        var guestBooking = await _context.GuestBookings.FindAsync(GuestBookingId);
        //        if (guestBooking == null)
        //        {
        //            return NotFound();
        //        }

        //        _context.GuestBookings.Remove(guestBooking);
        //        await _context.SaveChangesAsync();

        //        return guestBooking;
        //    }

        //    private bool GuestBookingExists(int id)
        //    {
        //        return _context.GuestBookings.Any(e => e.GuestBookingId == id);
        //    }

        //}
    }
}