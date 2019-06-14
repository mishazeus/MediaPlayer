﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaPlayer
{
   public class Actor
    {
        public string ActorID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string YearOfBorn { get; set; }

        public Actor(string actorid, string name, string lastname, string yearofborn)
        {
            ActorID = actorid;
            Name = name;
            LastName = lastname;
            YearOfBorn = yearofborn;

        }

        public Actor()
        {
            ActorID = "";
            Name = "";
            LastName = "";
            YearOfBorn = "";
        }
    }
}
