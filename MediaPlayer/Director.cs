using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaPlayer
{
    class Director
    {
        public string DirectorID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string YearOfBorn { get; set; }
       

        public Director(string directorid, string name, string lastname, string yearofborn)
        {
            DirectorID = directorid;
            Name = name; 
            LastName = lastname;
            YearOfBorn = yearofborn;
           
        }
    }

}
