using _12_GeneralStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace _12_GeneralStore.Controllers
{
    public class CustomerController : ApiController
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        // C
        [HttpPost]
        public async Task<IHttpActionResult> PostCustomerAsync(Customer model)
        {
            if (ModelState.IsValid)
            {
                _context.Customers.Add(model);
                await _context.SaveChangesAsync();

                return Ok($"You created and saved {model.FirstName}!");
            }
            return BadRequest(ModelState);
        }

        // R
        [HttpGet]
        public async Task<IHttpActionResult> GetCustomersAsync()
        {
            var customers = await _context.Customers.ToListAsync();
            if (customers.Count > 0)
                return Ok(customers);

            return BadRequest("No customers in the database");
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetCustomerByIdAsync(int id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(p => p.Id == id);
            if (customer != null)
                return Ok(customer);

            return NotFound();
        }

        // U
        [HttpPut]
        public async Task<IHttpActionResult> UpdateCustomer([FromUri] int id, [FromBody] Customer updatedCustomer)
        {
            if (ModelState.IsValid)
            {
                var customer = await _context.Customers.FindAsync(id);

                if(customer != null)
                {
                    customer.FirstName = updatedCustomer.FirstName;
                    customer.LastName = updatedCustomer.LastName;
                    await _context.SaveChangesAsync();
                    return Ok();
                }
                return NotFound();
            }
            return BadRequest(ModelState);
        }
        // D
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteCustomerByIdAsync([FromUri] int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
                return NotFound();

            _context.Customers.Remove(customer);

            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
