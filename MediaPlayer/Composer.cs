using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaPlayer
{
    class Composer
    {
        public string ComposerID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string FilmID { get; set; }


        public Composer(string composerid, string name, string lastname, string filmid)
        {
            ComposerID = composerid;
            Name = name;
            LastName = lastname;
            FilmID = filmid;

        }

        public Composer()
        {
            ComposerID = "";
            Name = "";
            LastName = "";
            FilmID = "";
        }
    }
}
