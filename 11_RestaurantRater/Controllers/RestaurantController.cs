using _11_RestaurantRater.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace _11_RestaurantRater.Controllers
{
    public class RestaurantController : ApiController
    {
        private readonly RestaurantDbContext _context = new RestaurantDbContext();

        // Post (Create)
        [HttpPost]
        public async Task<IHttpActionResult> PostRestaurant(Restaurant model)
        {
            if (ModelState.IsValid)
            {
                _context.Restaurants.Add(model);
                await _context.SaveChangesAsync();

                return Ok(); // 200 Ok!
            }

            return BadRequest(ModelState); // 500
        }

        // Get (Read)
        // Get All
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            List<Restaurant> restaurants = await _context.Restaurants.ToListAsync();
            return Ok(restaurants);
        }
        // Get By Id
        [HttpGet]
        public async Task<IHttpActionResult> GetById(int id) //Resturant/2
        {
            Restaurant restaurant = await _context.Restaurants.FindAsync(id);
            if (restaurant != null)
            {
                return Ok(restaurant);
            }
            return NotFound(); // 404
        }


        // Put (Update)
        [HttpPut]
        public async Task<IHttpActionResult> UpdateRestaurant([FromUri] int id, [FromBody] Restaurant model) // Restaurant/2 Plus body
        {
            if (ModelState.IsValid)
            {
                Restaurant restaurant = await _context.Restaurants.FindAsync(id);

                if (restaurant != null)
                {
                    restaurant.Name = model.Name;
                    restaurant.Address = model.Address;
                    restaurant.Rating = model.Rating;

                    await _context.SaveChangesAsync();

                    return Ok(); // 200
                }
                return NotFound(); // 404
            }
            return BadRequest(ModelState); // 500
        }

        // Delete (Delete)

        [HttpDelete]
        public async Task<IHttpActionResult> DeleteRestaurantById(int id)
        {
            Restaurant restaurant = await _context.Restaurants.FindAsync(id);

            if (restaurant == null)
                return NotFound(); // 404

            _context.Restaurants.Remove(restaurant);

            if (await _context.SaveChangesAsync() == 1)
                return Ok(); // 200

            return InternalServerError(); // 503
        }
    }
}
