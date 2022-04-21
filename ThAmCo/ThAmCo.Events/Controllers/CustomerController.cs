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

        //[HttpPost]
        //public async Task<ActionResult<Customer>> PostFoodBookings(Customer customer)
        //{
        //    _context.Customers.Add(customer);
        //    await _context.SaveChangesAsync();
        //    return CreatedAtAction("GetCustomer", new { Customer = customer.CustomerId }, customer);
        //}

        //[HttpDelete("{CustomerId}")]
        //public async Task<ActionResult<Customer>> DeleteCustomer(int CustomerId)
        //{
        //    var customer = await _context.Customers.FindAsync(CustomerId);
        //    if (customer == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Customers.Remove(customer);
        //    await _context.SaveChangesAsync();

        //    return customer;
        //}

        //private bool CustomerExists(int id)
        //{
        //    return _context.Customers.Any(e => e.CustomerId == id);
        //}

    }
}
