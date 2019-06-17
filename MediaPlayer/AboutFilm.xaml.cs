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
            fCountry.Text = V($"SELECT Country FROM Location WHERE countryID = {V($"SELECT countryID FROM Studio  WHERE studioID = {film.StudioID};")};");
            fYear.Text = film.Year;
            fScreenwriter.Text = V($"SELECT Name||' '||LastName FROM Screenwriter WHERE filmID = {film.FilmID};");
            fStudio.Text = V($"SELECT Name FROM Studio WHERE studioID = {film.StudioID};");
            fProducer.Text = V($"SELECT Name||' '||LastName FROM Producer WHERE filmID = {film.FilmID};");
            fOperator.Text = V($"SELECT Name||' '||LastName FROM Operator WHERE filmID = {film.FilmID};");
            fComposer.Text = V($"SELECT Name||' '||LastName FROM Composer WHERE filmID = {film.FilmID};");
            fTime.Text = film.Duratiom;
            fEditor.Text = V($"SELECT Name||' '||LastName FROM Editor WHERE filmID = {film.FilmID};");
            fName.Text = film.Name;
            fDirector.Text = film.DirectorID;
            fBudget.Text = film.Budget;

           string f(List<string> list){
                string s = "";
                
                foreach (string i in list) {
                    s = s + $"{V($"SELECT genre FROM Genre WHERE genreID = {i}")}"+" "; 
                }

                return s;
            }

            string a(List<string> list)
            {
                string s = "";

                foreach (string i in list)
                {
                    s = s + $"{V($"SELECT Name ||' '|| LastName FROM Actor WHERE actorID = {i}")}" + "\n";
                }

                return s;
            }

            fGenre.Text = f(P($"SELECT genreID FROM ListGenre WHERE filmID = {film.FilmID};"));
             //V($"SELECT genre FROM Genre WHERE genreID = {V($"SELECT genreID FROM ListGenre WHERE filmID = {film.FilmID};")};");
            fRating.Text = film.ratingID;
            PathFilm = film.PathFilm;
            aText.Text = "В главных ролях:\n"+a(P($"SELECT actorID FROM ListActor WHERE filmID = {film.FilmID};"));
        
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
                    while (reader.Read())
                    {
                        r = reader.GetValue(0).ToString();
                    }


                    return r;

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

        List<string> P(string command) // для одиночных записей
        {
            SQLiteConnection db = new SQLiteConnection();
            string r = "";
            List<string> more = new List<string>();
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

                   

                    while (reader.Read())
                    {
                        for (int colCtr = 0; colCtr < reader.FieldCount; ++colCtr)
                        {
                            more.Add(reader.GetValue(0).ToString());  
                        }
                          
                    }


                    return more;

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
            return more;
        }


    }
}
