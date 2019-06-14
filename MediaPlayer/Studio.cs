using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaPlayer
{
    class Studio
    {
        public string StudioID { get; set; }
        public string Name { get; set; }
        public string CountryID { get; set; }
        

        public Studio(string studioid, string name, Location location)
        {
            StudioID = studioid;
            Name = name;
            CountryID = location.CountryID; 
            
        }

        public Studio()
        {
            StudioID = "";
            Name = "";
            CountryID = "";

        }
    }
}
