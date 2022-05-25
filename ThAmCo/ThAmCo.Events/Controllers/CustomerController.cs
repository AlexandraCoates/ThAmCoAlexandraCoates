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

    public class CustomerController : Controller
    {
        private readonly EventsDbContext _context;

        public CustomerController(EventsDbContext dbContext)
        {
            _context = dbContext;
        }


        // Gets a list of existing customers
        public async Task<ActionResult<IEnumerable<Customer>>> Index()
        {
            return View(await _context.Customers.ToListAsync());
        }


        // Gets a specific customer
        public async Task<ActionResult<Customer>> Details(int? id)
        {
            var Customers = await _context.Customers.FirstOrDefaultAsync(c => c.CustomerId == id);
            if (Customers == null)
            {
                return NotFound();
            }

            var Events = await _context.GuestBookings
                .Where(g => g.CustomerId == id)
                .Include(g => g.eventClass)
                .ToListAsync();
            if(Events != null)
            {
                Customers.Bookings = Events;
            }
            return View(Customers);
        }

        // ????
        public IActionResult Create()
        {
            return View();
        }

       // Create a new customer
       [HttpPost]
       [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NameFirst,NameLast,Address,PostCode,Email,Phone")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));

        }

        // Creates the edit view for a specific customer
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // Edits a specific customer
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerId,NameFirst,NameLast,Address,PostCode,Email,Phone,Attendance")] Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if(!CustomerExists(customer.CustomerId))
                    {
                        return NotFound();
                    }
                    else 
                    {
                        throw;
                    }
                }
            }
            return View(customer);
        }

        // Creates the delete view for a specific customer
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // Deletes a specific customer
        // TODO: Soft Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.CustomerId == id);
        }
    }
}
