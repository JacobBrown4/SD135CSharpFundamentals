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
    public class ProductController : ApiController
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        // C
        [HttpPost]
        public async Task<IHttpActionResult> PostProductAsync(Product model)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(model);
                await _context.SaveChangesAsync();

                return Ok($"You created and saved {model.ProductName}!");
            }
            return BadRequest(ModelState);
        }

        // R
        [HttpGet]
        public async Task<IHttpActionResult> GetProductsAsync()
        {
           var products = await _context.Products.ToListAsync();
            if (products.Count > 0)
                return Ok(products);

            return BadRequest("No products in the database");
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetProductByIdAsync(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product != null)
                return Ok(product);

            return NotFound();
        }
    }
}
