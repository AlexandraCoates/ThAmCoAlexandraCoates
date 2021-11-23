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
    public class MenuFoodItemController : Controller
    {
        private readonly CateringDbContext _context;

        public MenuFoodItemController(CateringDbContext dbContext)
        {
            _context = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuFoodItem>>> GetMenuFoodItems()
        {
            return await _context.MenuFoodItems.ToListAsync();
        }

        [HttpGet("{MenuFoodItemId}")]
        public async Task<ActionResult<MenuFoodItem>> GetMenuFoodItems(int MenuFoodItemId)
        {
            var MenuFoodItem = await _context.MenuFoodItems.FindAsync(MenuFoodItemId);
            if (MenuFoodItem == null)
            {
                return NotFound();
            }
            return MenuFoodItem;
        }

        [HttpPut("{MenuFoodItemId}")]
        public async Task<IActionResult> PutMenuFoodItem(int MenuFoodItemId, MenuFoodItem menuFoodItem)
        {
            if (MenuFoodItemId != menuFoodItem.FoodItemId)
            {
                return BadRequest();
            }
            _context.Entry(menuFoodItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuFoodItemExists(MenuFoodItemId))
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
        public async Task<ActionResult<MenuFoodItem>> PostMenuFoodItem(MenuFoodItem menuFoodItem)
        {
            _context.MenuFoodItems.Add(menuFoodItem);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetMenuFoodItem", new { MenuFoodItem = menuFoodItem.FoodItemId }, menuFoodItem);
        }

        [HttpDelete("{FoodItemId}")]
        public async Task<ActionResult<MenuFoodItem>> DeleteMenuFoodItem(int MenuFoodItemId)
        {
            var menuFoodItem = await _context.MenuFoodItems.FindAsync(MenuFoodItemId);
            if (menuFoodItem == null)
            {
                return NotFound();
            }

            _context.MenuFoodItems.Remove(menuFoodItem);
            await _context.SaveChangesAsync();

            return menuFoodItem;
        }

        private bool MenuFoodItemExists(int id)
        {
            return _context.MenuFoodItems.Any(e => e.MenuId == id);
        }

    }
}