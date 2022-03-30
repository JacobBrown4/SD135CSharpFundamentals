using _12_GeneralStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace _12_GeneralStore.Controllers
{
    public class SalesController : ApiController
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        public async Task<IHttpActionResult> GetCustomerPurchases(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
                return NotFound();

            var transactions = _context.Transactions.Where(t => t.CustomerId == id);

            CustomerPurchase purchases = new CustomerPurchase();
            purchases.CustomerName = customer.FirstName + " " + customer.LastName;
            purchases.TotalSpent = transactions.ToList().Select(g => g.Total).Sum();
            purchases.Products = transactions.Select(p => p.Product.ProductName).Distinct().ToList();

            return Ok(purchases);

        }
    }
}
