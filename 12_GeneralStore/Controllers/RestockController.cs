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
    public class RestockController : ApiController
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        [HttpPut]
        public async Task<IHttpActionResult> RestockProductAsync([FromUri] int id, [FromBody] Restock model)
        {
            if (ModelState.IsValid)
            {
                var product = await _context.Products.FindAsync(id);
                if(product != null)
                {
                    product.Quantity += model.NewStock;
                    await _context.SaveChangesAsync();
                    return Ok($"The new quantity is {product.Quantity}");
                }
                return NotFound();
            }
            return BadRequest(ModelState);
        }


    }
}
