using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ThAmCo.Catering.Data;

namespace ThAmCo.Catering.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodBookingController : Controller
    {
        private readonly CateringDbContext _context;

        public FoodBookingController(CateringDbContext dbContext)
        {
            _context = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodBooking>>> GetFoodBookings()
        {
            return await _context.FoodBookings.ToListAsync();
        }

        [HttpGet("{FoodBookingId}")]
        public async Task<ActionResult<FoodBooking>> GetFoodBookings(int FoodBookingId)
        {
            var FoodBookings = await _context.FoodBookings.FindAsync(FoodBookingId);
            if (FoodBookings == null)
            {
                return NotFound();
            }
            return FoodBookings;
        }

        [HttpPut("{FoodBookingId}")]
        public async Task<IActionResult> PutFoodBooking(int FoodBookingId, FoodBooking foodBooking)
        {
            if (FoodBookingId != foodBooking.FoodBookingId)
            {
                return BadRequest();
            }
            _context.Entry(foodBooking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodBookingExists(FoodBookingId))
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
        public async Task<ActionResult<FoodBooking>> PostFoodBookings(FoodBooking foodBooking)
        {
            _context.FoodBookings.Add(foodBooking);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetFoodBooking", new { FoodBooking = foodBooking.FoodBookingId }, foodBooking);
        }

        [HttpDelete("{FoodBookingId}")]
        public async Task<ActionResult<FoodBooking>> DeleteFoodBooking(int FoodBookingId)
        {
            var foodbooking = await _context.FoodBookings.FindAsync(FoodBookingId);
            if (foodbooking == null)
            {
                return NotFound();
            }

            _context.FoodBookings.Remove(foodbooking);
            await _context.SaveChangesAsync();

            return foodbooking;
        }

        private bool FoodBookingExists(int id)
        {
            return _context.FoodBookings.Any(e => e.FoodBookingId == id);
        }

    }
}