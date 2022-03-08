using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_StreamingContent_Repository.Content
{
    public class Show : StreamingContent
    {

        public Show() { }
        public Show(string title, string description, double stars, MaturityRating maturity, GenreType type) : base(title, description, stars, maturity, type) { }
        public Show(string title, string description, double stars, MaturityRating maturity, GenreType type, int numberOfSeasons, List<Episode> episodes) : this(title, description, stars, maturity, type)
        {
            Episodes = episodes;
            NumberOfSeasons = numberOfSeasons;
        }

        public List<Episode> Episodes { get; set; }
        public int NumberOfSeasons { get; set; }
        public double AverageRunTime
        {
            get
            {
                if (Episodes.Count() != 0)
                {
                    double averageTotal = 0;
                    foreach (Episode episode in Episodes) // This list property is accessible and can be worked through
                    {
                        averageTotal += episode.RunTime;
                    }
                    return averageTotal / Episodes.Count();
                }
                else
                {
                    return 0d;
                }
            }
        }
    }

    public class Episode
    {
        public string Title { get; set; }
        public double RunTime { get; set; }
        public int SeasonNumber { get; set; }
        public int EpisodeNumber { get; set; }

    }
}
