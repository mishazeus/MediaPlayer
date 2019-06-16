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
using System.Data.SQLite;
using System.Threading;
using System.IO;
using System.Xml;
using System.Diagnostics;
using System.Collections;
using System.Net;
using System.Net.Sockets;

namespace MediaPlayer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        string standartPath = Directory.GetCurrentDirectory().ToString();
        string Path;

        List<Film> films;


        public MainWindow()
        {
       
            InitializeComponent();
            
            WindowState = WindowState.Normal;
            WindowState = WindowState.Maximized;

            Path = Directory.GetParent(standartPath).ToString();

            films = new List<Film>();

            CinemaList.ItemsSource = BD("SELECT * FROM Film;", films);
            DataContext = this;
            AboutFilm.onNameSend += Page1_onNameSend;
        }

        void Page1_onNameSend(bool tr, string Path)
        {
            if (tr == true) {
                frame.Navigate(new PlayFilm(Path));
                frame.Background = Brushes.Black;
            }
            
        }

        List<Film> BD(string command, List<Film> list) {
            SQLiteConnection db = new SQLiteConnection();

            string filmid=""; string name=""; string directorid=""; string studioid=""; string duratiom=""; string pathlogo=""; string ratingid=""; string pathfilm=""; string year = ""; string budget = "";

            try
            {
                
                db.ConnectionString = "Data Source=\"" + Directory.GetParent(Path).ToString()+"\\Resurses\\film.db" + "\"";
         
                db.Open();
                try
                {
                    SQLiteCommand cmdSelect = db.CreateCommand();
                    cmdSelect.CommandText = command;
                    SQLiteDataReader reader = cmdSelect.ExecuteReader();

                    while (reader.Read())
                    {
                        Film film;
                        for (int colCtr = 0; colCtr < reader.FieldCount; ++colCtr)
                        {
                            switch (colCtr)
                            {
                                case 0: { filmid = reader.GetValue(colCtr).ToString(); } break;
                                case 1: { name = reader.GetValue(colCtr).ToString(); } break;
                                case 2: { directorid = reader.GetValue(colCtr).ToString();
                                        int bufferid = Convert.ToInt32(directorid);
                         directorid = P($"SELECT Name||' '||LastName FROM Director WHERE directorID = {bufferid};");
                                    } break;
                                case 3: { studioid = reader.GetValue(colCtr).ToString(); } break;
                                case 4: { duratiom = reader.GetValue(colCtr).ToString(); } break;
                                case 7: { pathlogo = reader.GetValue(colCtr).ToString(); } break;
                                case 6: { ratingid = reader.GetValue(colCtr).ToString();
                                        int bufferid = Convert.ToInt32(ratingid);
                                        ratingid = P($"SELECT rating FROM Rating WHERE ratingID = {bufferid};");
                                    } break;
                                case 5: { pathfilm = reader.GetValue(colCtr).ToString(); } break;
                                case 8: { year = reader.GetValue(colCtr).ToString(); } break;
                                case 9: { budget = reader.GetValue(colCtr).ToString(); } break;
                            }
                        }
                        
                        film = new Film(filmid, name, directorid, studioid, duratiom, pathlogo, ratingid, pathfilm, year, budget);

                        list.Add(film);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error Executing SQL: " + e.ToString(), "Exception While Displaying MyTable ...");
                }
                db.Close();
            }
            catch (System.Data.SQLite.SQLiteException) {

            }
            finally
            {
                //   delete(IDisposable)db;
            }
            return list;
        }

        string P(string command) {
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
                    while (reader.Read()) {
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

        private void CinemaList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            frame.Navigate(new AboutFilm(films[CinemaList.SelectedIndex]));
            frame.Background = Brushes.White;
        }

        private void SettingsBT_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new settings());
            frame.Background = Brushes.White;
        }

        private void SearchBT_Click(object sender, RoutedEventArgs e)
        {
            string SearchRequest = SearchTB.Text;
            if (SearchRequest != "")
            {
                List<Film> findFilms = new List<Film>();

                foreach (Film film in films)
                {
                    if (GoodRequest(film, SearchRequest) != -1)
                    {
                        findFilms.Add(film);
                    }
                }

                CinemaList.ItemsSource = findFilms;
                DataContext = this;
            }
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        int GoodRequest(Film film, string request) {
            if (film.Name.Equals(request)) { return Convert.ToInt32(film.FilmID); }
            if (film.DirectorID.Equals(request)) { return Convert.ToInt32(film.FilmID); }
            if (film.Duratiom.Equals(request)) { return Convert.ToInt32(film.FilmID); }
            if (film.Year.Equals(request)) { return Convert.ToInt32(film.FilmID); }
            if (film.StudioID.Equals(request)) { return Convert.ToInt32(film.FilmID); }
            if (film.ratingID.Equals(request)) { return Convert.ToInt32(film.FilmID); }
            if (film.Budget.Equals(request)) { return Convert.ToInt32(film.FilmID); }

            return -1;
        }

    }
}
