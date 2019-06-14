using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaPlayer
{
    class Operator
    {
        public string OperatorID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string FilmID { get; set; }



        public Operator(string directorid, string name, string lastname, string filmid)
        {
            OperatorID = directorid;
            Name = name;
            LastName = lastname;
            FilmID = filmid;

        }

        public Operator()
        {
            OperatorID = "";
            Name = "";
            LastName = "";
            FilmID = "";

        }
    }
}
