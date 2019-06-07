using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace MediaPlayer
{
    /// <summary>
    /// Логика взаимодействия для AboutFilm.xaml
    /// </summary>
    public partial class AboutFilm : Page
    {
        string PathFilm;
        public delegate void SendEvent(bool trig, string Path);
        public static event SendEvent onNameSend;
        
        public AboutFilm(Film film)
        {
            InitializeComponent();
            DataContext = film;
            //fYear.Text = film.;
            fName.Text = film.Name;
            fDirector.Text = film.DirectorID;
            fRating.Text = film.ratingID;
            PathFilm = film.PathFilm;
            //aText.Text = "";

            //    filmPath.Replace('\\', '\');
            //D:\фильмы\Железный человек.mkv  
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {  
            onNameSend(true, PathFilm);
        }

       
    }
}
