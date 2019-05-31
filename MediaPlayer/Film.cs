using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaPlayer
{
    class Film
    {
       public string FilmID { get; set; }
       public string Name { get; set; }
       public string DirectorID { get; set; }
       public string StudioID { get; set; }
       public string Duratiom { get; set; }
       public string PathLogo { get; set; }
       public string ratingID { get; set; }
       public string PathFilm { get; set; }

        public Film(string filmid, string name, string directorid, string studioid, string duratiom , string pathlogo, string ratingid, string pathfilm) {
            FilmID = filmid;
            Name = name;
            DirectorID = directorid;
            StudioID = studioid;
            Duratiom = duratiom;
            PathLogo = pathlogo;
            ratingID = ratingid;
            PathFilm = pathfilm;
        }

    }
}
