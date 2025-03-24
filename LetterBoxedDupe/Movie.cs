using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetterBoxedDupe
{
    public class Movie
    {
        public string MovieTitle { get; set; }
        public string Description { get; set; }
        public string PosterUrl { get; set; }

        public List<string> Reviews { get; set; }

        public Movie(string movietitle, string description, string posterUrl)
        {
            MovieTitle = movietitle;
            Description = description;
            PosterUrl = posterUrl;
            Reviews = new List<string>();
        }

        public void AddReview(string review)
        {
            Reviews.Add(review);
        }


    }
}
