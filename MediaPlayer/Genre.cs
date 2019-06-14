using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaPlayer
{
    class Genre
    {
        public string GenreID { get; set; }
        public string Genres { get; set; }


        public Genre(string genreid, string genre)
        {
            GenreID = genreid;
            Genres = genre;

        }

        public Genre()
        {
            GenreID = "";
            Genres = "";

        }
    }
}
