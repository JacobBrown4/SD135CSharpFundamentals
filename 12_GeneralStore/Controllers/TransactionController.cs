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
    public class TransactionController : ApiController
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        [HttpPost]
        public async Task<IHttpActionResult> PostTransactionAsync(Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                // Checking FK's are valid
                var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == transaction.ProductId);
                var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == transaction.CustomerId);
                if (product == null && customer == null)
                    return BadRequest("Invalid Product and Customer Id");
                else if (product == null)
                    return BadRequest("That customer Id doesn't exist");
                else if (customer == null)
                    return BadRequest("That product Id doesn't exist");
                // Checking logistics
                if (transaction.Quantity > product.Quantity)
                    return BadRequest($"There are only {product.Quantity} left in stock");

                product.Quantity -= transaction.Quantity; // Take away from inventory transaction amount.

                transaction.DateOfTransaction = DateTime.Now;
                _context.Transactions.Add(transaction);

                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest(ModelState);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAllTransactionsAsync()
        {
            return Ok(await _context.Transactions.ToListAsync());
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetTransactionByIdAsync(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction == null)
                return NotFound();

            return Ok(transaction);
        }

        [HttpPut]
        public async Task<IHttpActionResult> UpdateTransactionAsync([FromUri] int id, [FromBody] Transaction updatedTransaction)
        {
            if (ModelState.IsValid)
            {
                var transaction = await _context.Transactions.FindAsync(id);
                if (transaction != null)
                {
                    if (transaction.CustomerId != updatedTransaction.CustomerId)
                    {
                        var customer = await _context.Customers.FindAsync(id);
                        if (customer == null)
                            return BadRequest("A customer doesn't exist by that Id");
                        transaction.CustomerId = updatedTransaction.CustomerId;
                    }

                    var product = await _context.Products.FindAsync(updatedTransaction.ProductId);
                    if (product == null)
                        return BadRequest("A product doesn't exist by that Id");

                    transaction.Product.Quantity += transaction.Quantity;
                    if (updatedTransaction.Quantity > product.Quantity)
                    {
                        return BadRequest($"There are only {product.Quantity} of those in stock");
                    }
                    product.Quantity -= updatedTransaction.Quantity;


                    transaction.Quantity = updatedTransaction.Quantity;
                    transaction.ProductId = updatedTransaction.ProductId;

                    int changes = await _context.SaveChangesAsync();
                    return Ok($"Transaction updated! {changes} saved");

                }
                return NotFound();

            }
            return BadRequest(ModelState);
        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeleteTransactionAsync([FromUri] int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);

            if (transaction == null)
                return NotFound();

            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
