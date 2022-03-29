using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _11_RestaurantRater.Models
{
    public class Restaurant
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        public double AverageFoodScore
        {
            get
            {
                double totalAverageRating = 0;
                foreach(Rating rating in Ratings)
                {
                    totalAverageRating += rating.FoodScore;
                }

                return (Ratings.Count > 0) ? totalAverageRating / Ratings.Count : 0;
            }
        }
        public double AverageEnvironmentScore
        {
            get
            {
                double total = 0;
                foreach(Rating rating in Ratings)
                {
                    total += rating.EnvironmentScore;
                }

                return (Ratings.Count > 0) ? total / Ratings.Count : 0;
            }
        }
        public double AverageCleanlinessScore
        {
            get
            {
                double total = 0;
                foreach(Rating rating in Ratings)
                {
                    total += rating.CleanlinessScore;
                }
                return (Ratings.Count > 0) ? total / Ratings.Count : 0;
            }
        }
        public double AverageRating
        {
            get
            {
                double total = Ratings.Select(r => r.AverageRating).Sum();
                return (Ratings.Count > 0) ? total / Ratings.Count : 0;
            }
        }
        public virtual List<Rating> Ratings { get; set; } = new List<Rating>();
    }
}