using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Documents;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace MediaPlayer
{
    /// <summary>
    /// Логика взаимодействия для AboutFilm.xaml
    /// </summary>
    public partial class AboutFilm : Page
    {
        string standartPath = Directory.GetCurrentDirectory().ToString();
        string Path;

        string PathFilm;
        public delegate void SendEvent(bool trig, string Path);
        public static event SendEvent onNameSend;
        
        public AboutFilm(Film film)
        {
            InitializeComponent();
            Path = Directory.GetParent(standartPath).ToString();
            DataContext = film;

            fYear.Text = film.Year;
         //   fCountry.Text = V($"SELECT Country FROM Location WHERE {film.StudioID};");
            fName.Text = film.Name;
        //    fStudio.Text = V($"SELECT Name FROM Studio WHERE {film.StudioID};");
        //    fProducer.Text = V($"SELECT Name || ' ' || LastName FROM Producer WHERE filmID = {film.FilmID};");
            fDirector.Text = film.DirectorID;
            fRating.Text = film.ratingID;
            PathFilm = film.PathFilm;
            //aText.Text = "";

        
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {  
            onNameSend(true, PathFilm);
        }

        string V(string command) // для одиночных записей
        {
            SQLiteConnection db = new SQLiteConnection();
            string r = "";
            try
            {
                //C:\\Users\\Михаил\\source\\repos\\MediaPlayer\\MediaPlayer\\Resurses\\film.db
                db.ConnectionString = "Data Source=\"" + Directory.GetParent(Path).ToString() + "\\Resurses\\film.db" + "\"";
                //C:\\Users\\Mikhail\\Source\\Repos\\mishazeus\\MediaPlayer\\MediaPlayer\\Resurses\\film.db
                db.Open();
                try
                {
                    SQLiteCommand cmdSelect = db.CreateCommand();

                    cmdSelect.CommandText = command;
                    SQLiteDataReader reader = cmdSelect.ExecuteReader();

                    return reader.GetValue(0).ToString();

                }
                catch (Exception e)
                {
                    MessageBox.Show("Error Executing SQL: " + e.ToString(), "Exception While Displaying MyTable ...");
                }
                db.Close();
            }
            catch (System.Data.SQLite.SQLiteException)
            {
            }
            finally
            {
                //   delete(IDisposable)db;
            }
            return "";
        }


    }
}
