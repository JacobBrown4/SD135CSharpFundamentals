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
    public class RatingController : ApiController
    {
        private readonly RestaurantDbContext _context = new RestaurantDbContext();

        [HttpPost]
        public async Task<IHttpActionResult> CreateRating(Rating model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Check the restaurant exists
            var restaurant = await _context.Restaurants.FindAsync(model.RestaurantId);
            if (restaurant == null)
                return BadRequest($"The targeted restaurant with an Id of {model.RestaurantId} does not exist.");

            _context.Ratings.Add(model);
            if (await _context.SaveChangesAsync() == 1)
                return Ok($"You rated {restaurant.Name} successfully!");

            return InternalServerError();
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetRatingById(int id)
        {
            Rating rating = await _context.Ratings.FirstOrDefaultAsync(r => r.Id == id);

            if (rating != null)
            {
                return Ok(rating);
            }
            return NotFound();
        }
        [HttpGet]
        public async Task<IHttpActionResult> GetAllRatings()
        {
            return Ok(await _context.Ratings.ToListAsync());
        }

        [HttpPut]
        public async Task<IHttpActionResult> UpdateRating([FromUri] int id, [FromBody] Rating updatedRating)
        {
            if (ModelState.IsValid)
            {
                Rating rating = await _context.Ratings.FindAsync(id);
                if(rating != null)
                {
                    rating.FoodScore = updatedRating.FoodScore;
                    rating.EnvironmentScore = updatedRating.EnvironmentScore;
                    rating.CleanlinessScore = updatedRating.CleanlinessScore;

                    await _context.SaveChangesAsync();
                    return Ok("Rating updated");
                }
                return NotFound();
            }
            return BadRequest(ModelState);
        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeleteRatingById(int id)
        {
            Rating entity = await _context.Ratings.FindAsync(id);
            if (entity == null)
                return NotFound();

            _context.Ratings.Remove(entity);

            if (await _context.SaveChangesAsync() == 1)
                return Ok("The rating was deleted");

            return InternalServerError();
        }
    }
}


