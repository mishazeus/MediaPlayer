using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaPlayer
{
    class Screenwriter
    {
        public string ScreenwriterID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string FilmID { get; set; }
       


        public Screenwriter(string directorid, string name, string lastname, string filmid)
        {
            ScreenwriterID = directorid;
            Name = name;
            LastName = lastname;
            FilmID = filmid;

        }

        public Screenwriter()
        {
            ScreenwriterID = "";
            Name = "";
            LastName = "";
            FilmID = "";

        }
    }
}
