using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MediaPlayer
{
    class FilmInfo : INotifyPropertyChanged
    {
        private string filmName;
        

        public int Id { get; set; }

        public string FilmName
        {
            get { return filmName; }
            set
            {
                filmName = value;
                OnPropertyChanged("Название");
            }
        }
        

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    
    }
}
