using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaPlayer
{
    class Editor
    {
        public string EditorID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string FilmID { get; set; }


        public Editor(string editorid, string name, string lastname, string filmid)
        {
            EditorID = editorid;
            Name = name;
            LastName = lastname;
            FilmID = filmid;

        }

        public Editor()
        {
            EditorID = "";
            Name = "";
            LastName = "";
            FilmID = "";
        }
    }
}
