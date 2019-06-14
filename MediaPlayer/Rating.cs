using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaPlayer
{
    class Rating
    {
        public string RatingID { get; set; }
        public string Ratings { get; set; }


        public Rating(string ratingid, string rating)
        {
            RatingID = ratingid;
            Ratings = rating;

        }

        public Rating()
        {
            RatingID = "";
            Ratings = "";

        }
    }
}
