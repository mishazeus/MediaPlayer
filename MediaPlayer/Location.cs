using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaPlayer
{
   public class Location
    {
        public string CountryID { get; set; }
        public string Country { get; set; }
       

        public Location(string countryid, string country)
        {
            CountryID = countryid; 
            Country = country;  

        }

        public Location()
        {
            CountryID = "";
            Country = "";

        }
    }
}
