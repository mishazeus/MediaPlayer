using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaPlayer
{
    class Producer
    {
        public string ProducerID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }


        public Producer(string producerid, string name, string lastname, string filmid)
        {
            ProducerID = producerid;
            Name = name;
            LastName = lastname;
           

        }

        public Producer()
        {
            ProducerID = "";
            Name = "";
            LastName = "";
           

        }
    }
}
