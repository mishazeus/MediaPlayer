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

        public delegate void SendClose(bool trig);
        public static event SendClose onNameClose;
        Film fil;
        
        public AboutFilm(Film film)
        {
            InitializeComponent();
            Path = Directory.GetParent(standartPath).ToString();
            fil = new Film();
            fil = film;
            DataContext = fil;
            fCountry.Text = V($"SELECT Country FROM Location WHERE countryID = {V($"SELECT countryID FROM Studio WHERE studioID = {film.StudioID};")};");
            fYear.Text = fil.Year;
            fScreenwriter.Text = fil.ScreenwriterID;
            fStudio.Text = V($"SELECT Name FROM Studio WHERE studioID = {fil.StudioID}");
            fProducer.Text = fil.ProducerID;
            fOperator.Text = fil.OperatorID;
            fComposer.Text = fil.ComposerID;
            fTime.Text = fil.Duratiom;
            fEditor.Text = fil.EditorID;
            fName.Text = fil.Name;
            fDirector.Text = fil.DirectorID;
            fBudget.Text = fil.Budget;

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

            fGenre.Text = f(P($"SELECT genreID FROM ListGenre WHERE filmID = {fil.FilmID};"));
            
            fRating.Text = fil.RatingID;
            PathFilm = fil.PathFilm;
            aText.Text = "В главных ролях:\n"+a(P($"SELECT actorID FROM ListActor WHERE filmID = {fil.FilmID};"));
        
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
                //C:\\Users\\Михаил\\source\\repos\\MediaPlayer\\MediaPlayer\\Resurses\\filmdatabase.db
                db.ConnectionString = "Data Source=\"" + Directory.GetParent(Path).ToString() + "\\Resurses\\filmdatabase.db" + "\"";
                //C:\\Users\\Mikhail\\Source\\Repos\\mishazeus\\MediaPlayer\\MediaPlayer\\Resurses\\filmdatabase.db
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
                //C:\\Users\\Михаил\\source\\repos\\MediaPlayer\\MediaPlayer\\Resurses\\filmdatabase.db
                db.ConnectionString = "Data Source=\"" + Directory.GetParent(Path).ToString() + "\\Resurses\\filmdatabase.db" + "\"";
                //C:\\Users\\Mikhail\\Source\\Repos\\mishazeus\\MediaPlayer\\MediaPlayer\\Resurses\\filmdatabase.db
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

        void BD(string command)
        {
            SQLiteConnection db = new SQLiteConnection();
            string r = "";
            try
            {
                //C:\\Users\\Михаил\\source\\repos\\MediaPlayer\\MediaPlayer\\Resurses\\filmdatabase.db
                db.ConnectionString = "Data Source=\"" + Directory.GetParent(Path).ToString() + "\\Resurses\\filmdatabase.db" + "\"";
                //C:\\Users\\Mikhail\\Source\\Repos\\mishazeus\\MediaPlayer\\MediaPlayer\\Resurses\\filmdatabase.db
                db.Open();
                try
                {
                    SQLiteCommand cmdSelect = db.CreateCommand();

                    cmdSelect.CommandText = command;

                    SQLiteDataReader reader = cmdSelect.ExecuteReader();
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

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            BD($"DELETE FROM ListGenre WHERE filmID = {fil.FilmID};");
            BD($"DELETE FROM ListActor WHERE filmID = {fil.FilmID};");
            BD($"DELETE FROM Film WHERE filmID = {fil.FilmID};");
            onNameClose(true);

        }
    }
}
