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

        // U
        [HttpPut]
        public async Task<IHttpActionResult> UpdateProductAsync([FromUri] int id, [FromBody] Product updatedProduct)
        {
            if (ModelState.IsValid)
            {
                var product = await _context.Products.FindAsync(id);

                if(product != null)
                {

                    product.ProductName = updatedProduct.ProductName;
                    product.UPC = updatedProduct.UPC;
                    product.Quantity = updatedProduct.Quantity;
                    product.Price = updatedProduct.Price;

                    await _context.SaveChangesAsync();
                    return Ok("Product updated");

                }
                return NotFound();

            }
            return BadRequest(ModelState);
        }

        // D

        [HttpDelete]
        public async Task<IHttpActionResult> DeleteProductAsync([FromUri] int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
               return NotFound();

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return Ok($"Product {product.ProductName} deleted.");
        }
    }
}
