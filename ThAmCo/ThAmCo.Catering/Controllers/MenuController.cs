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
    public class MenuController : Controller
    {
        private readonly CateringDbContext _context;

        public MenuController(CateringDbContext dbContext)
        {
            _context = dbContext;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Menu>>> GetMenus()
        {
            return await _context.Menus.ToListAsync();
        }

        [HttpGet("{MenuId}")]
        public async Task<ActionResult<Menu>> GetMenus(int MenuId)
        {
            var Menus = await _context.Menus.FindAsync(MenuId);
            if (Menus == null)
            {
                return NotFound();
            }
            return Menus;
        }

        [HttpPut("{MenuId}")]
        public async Task<IActionResult> PutMenu(int MenuId, Menu menu)
        {
            if (MenuId != menu.MenuId)
            {
                return BadRequest();
            }
            _context.Entry(menu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuExists(MenuId))
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
        public async Task<ActionResult<Menu>> PostMenu(Menu menu)
        {
            _context.Menus.Add(menu);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetMenu", new { Menu = menu.MenuId }, menu);
        }

        [HttpDelete("{MenuId}")]
        public async Task<ActionResult<Menu>> DeleteMenu(int MenuId)
        {
            var menu = await _context.Menus.FindAsync(MenuId);
            if (menu == null)
            {
                return NotFound();
            }

            _context.Menus.Remove(menu);
            await _context.SaveChangesAsync();

            return menu;
        }

        private bool MenuExists(int id)
        {
            return _context.Menus.Any(e => e.MenuId == id);
        }

    }
}
