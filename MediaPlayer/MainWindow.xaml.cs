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

            try
            {
                
                db.ConnectionString = "Data Source=\"" + Directory.GetParent(Path).ToString()+"\\Resurses\\filmdatabase.db" + "\"";
         
                db.Open();
                try
                {
                    SQLiteCommand cmdSelect = db.CreateCommand();
                    cmdSelect.CommandText = command;
                    SQLiteDataReader reader = cmdSelect.ExecuteReader();

                    while (reader.Read())
                    {
                        Film film = new Film();
                        for (int colCtr = 0; colCtr < reader.FieldCount; ++colCtr)
                        {
                            switch (colCtr)
                            {
                                case 0: { film.FilmID = reader.GetValue(colCtr).ToString(); } break;
                                case 1: { film.Name = reader.GetValue(colCtr).ToString(); } break;
                                case 2: { film.DirectorID = reader.GetValue(colCtr).ToString();
                                 film.DirectorID = P($"SELECT Name||' '||LastName FROM Director WHERE directorID = {Convert.ToInt32(film.DirectorID)};");
                                    } break;
                                case 3: { film.StudioID = reader.GetValue(colCtr).ToString();   
                                    } break;
                                case 4: { film.Duratiom = reader.GetValue(colCtr).ToString(); } break;
                                case 7: { film.PathLogo = reader.GetValue(colCtr).ToString(); } break;
                                case 6: { film.RatingID = reader.GetValue(colCtr).ToString();
                                     film.RatingID = P($"SELECT rating FROM Rating WHERE ratingID = {Convert.ToInt32(film.RatingID)};");
                                    } break;
                                case 5: { film.PathFilm = reader.GetValue(colCtr).ToString(); } break;
                                case 8: { film.Year = reader.GetValue(colCtr).ToString(); } break;
                                case 9: { film.Budget = reader.GetValue(colCtr).ToString(); } break;
                                case 10: { film.ProducerID = reader.GetValue(colCtr).ToString();
                                        film.ProducerID = P($"SELECT Name||' '||LastName FROM Producer WHERE producerID = {Convert.ToInt32(film.ProducerID)};");
                                    } break;
                                case 11: { film.ScreenwriterID = reader.GetValue(colCtr).ToString();
                                        film.ScreenwriterID = P($"SELECT Name||' '||LastName FROM Screenwriter WHERE screenwriterID = {Convert.ToInt32(film.ScreenwriterID)};");
                                    } break;
                                case 12: { film.EditorID = reader.GetValue(colCtr).ToString();
                                        film.EditorID = P($"SELECT Name||' '||LastName FROM Editor WHERE editorID = {Convert.ToInt32(film.EditorID)};");
                                    } break;
                                case 13: { film.ComposerID = reader.GetValue(colCtr).ToString();
                                        film.ComposerID = P($"SELECT Name||' '||LastName FROM Composer WHERE composerID = {Convert.ToInt32(film.ComposerID)};");
                                    } break;
                                case 14: { film.OperatorID = reader.GetValue(colCtr).ToString();
                                        film.OperatorID = P($"SELECT Name||' '||LastName FROM Operator WHERE operatorID = {Convert.ToInt32(film.OperatorID)};");
                                    } break;
                            }
                        }

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
                //C:\\Users\\Михаил\\source\\repos\\MediaPlayer\\MediaPlayer\\Resurses\\filmdatabase.db
                db.ConnectionString = "Data Source=\"" + Directory.GetParent(Path).ToString() + "\\Resurses\\filmdatabase.db" + "\"";
                //C:\\Users\\Mikhail\\Source\\Repos\\mishazeus\\MediaPlayer\\MediaPlayer\\Resurses\\filmdatabase.db
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
            else {
                CinemaList.ItemsSource = films;
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
            if (film.RatingID.Equals(request)) { return Convert.ToInt32(film.FilmID); }
            if (film.Budget.Equals(request)) { return Convert.ToInt32(film.FilmID); }
            if (film.ProducerID.Equals(request)) { return Convert.ToInt32(film.FilmID); }
            if (film.ScreenwriterID.Equals(request)) { return Convert.ToInt32(film.FilmID); }
            if (film.EditorID.Equals(request)) { return Convert.ToInt32(film.FilmID); }
            if (film.ComposerID.Equals(request)) { return Convert.ToInt32(film.FilmID); }
            if (film.OperatorID.Equals(request)) { return Convert.ToInt32(film.FilmID); }

            return -1;
        }

    }
}
