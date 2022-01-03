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
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly EventsDbContext _context;

        public CustomerController(EventsDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        [HttpGet("{CustomerId}")]
        public async Task<ActionResult<Customer>> GetCustomers(int CustomerId)
        {
            var Customers = await _context.Customers.FindAsync(CustomerId);
            if (Customers == null)
            {
                return NotFound();
            }
            return Customers;
        }

        [HttpPut("{CustomerId}")]
        public async Task<IActionResult> PutCustomers(int CustomerId, Customer customer)
        {
            if (CustomerId != customer.CustomerId)
            {
                return BadRequest();
            }
            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(CustomerId))
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
        public async Task<ActionResult<Customer>> PostFoodBookings(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetCustomer", new { Customer = customer.CustomerId }, customer);
        }

        [HttpDelete("{CustomerId}")]
        public async Task<ActionResult<Customer>> DeleteCustomer(int CustomerId)
        {
            var customer = await _context.Customers.FindAsync(CustomerId);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return customer;
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.CustomerId == id);
        }

    }
}
