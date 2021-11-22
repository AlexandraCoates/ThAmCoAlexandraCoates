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
    public class FoodItemController : Controller
    {
        private readonly CateringDbContext _context;

        public FoodItemController(CateringDbContext dbContext)
        {
            _context = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodItem>>> GetFoodItems()
        {
            return await _context.FoodItems.ToListAsync();
        }

        [HttpGet("{FoodItemId}")]
        public async Task<ActionResult<FoodItem>> GetFoodItems(int FoodItemId)
        {
            var FoodItems = await _context.FoodItems.FindAsync(FoodItemId);
            if (FoodItems == null)
            {
                return NotFound();
            }
            return FoodItems;
        }

        [HttpPut("{FoodItemId}")]
        public async Task<IActionResult> PutFoodItem(int FoodItemId, FoodItem foodItem)
        {
            if (FoodItemId != foodItem.FoodItemId)
            {
                return BadRequest();
            }
            _context.Entry(foodItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodItemExists(FoodItemId))
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
        public async Task<ActionResult<FoodItem>> PostFoodItems(FoodItem foodItem)
        {
            _context.FoodItems.Add(foodItem);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetFoodItems", new { FoodItemId = foodItem.FoodItemId }, foodItem);
        }

        [HttpDelete("{FoodItemId}")]
        public async Task<ActionResult<FoodItem>> DeleteFoodItem(int FoodItemId)
        {
            var foodItem = await _context.FoodItems.FindAsync(FoodItemId);
            if (foodItem == null)
            {
                return NotFound();
            }

            _context.FoodItems.Remove(foodItem);
            await _context.SaveChangesAsync();

            return foodItem;
        }

        private bool FoodItemExists(int id)
        {
            return _context.FoodItems.Any(e => e.FoodItemId == id);
        }

    }
}
