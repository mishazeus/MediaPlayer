using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaPlayer
{
    public class Film
    {
       public string FilmID { get; set; }
       public string Name { get; set; }
       public string DirectorID { get; set; }
       public string StudioID { get; set; }
       public string Duratiom { get; set; }
       public string PathLogo { get; set; }
       public string RatingID { get; set; }
       public string PathFilm { get; set; }
       public string Year { get; set; }
       public string Budget { get; set; }
       public string ProducerID { get; set; }
       public string ScreenwriterID { get; set; }
       public string EditorID { get; set; }
       public string ComposerID { get; set; }
       public string OperatorID { get; set; }


        public Film()
        {
            FilmID = "";
            Name = "";
            DirectorID = "";
            StudioID = "";
            Duratiom = "";
            PathLogo = "";
            RatingID = "";
            PathFilm = "";
            Year = "";
            Budget = "";
            ProducerID = "";
            ScreenwriterID = "";
            EditorID = "";
            ComposerID = "";
            OperatorID = "";

    }

    }
}
