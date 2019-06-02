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
        List<Film> films;

        public MainWindow()
        {
            InitializeComponent();
            WindowState = WindowState.Normal;
            WindowState = WindowState.Maximized;


            //frame.height = system.windows.systemparameters.primaryscreenheight;
            //frame.width = system.windows.systemparameters.primaryscreenwidth;


            films = new List<Film>();

            CinemaList.ItemsSource = BD("SELECT * FROM Film;", films);
            DataContext = this;

        }

        List<Film> BD(string command, List<Film> list) {
            SQLiteConnection db = new SQLiteConnection();

            string filmid=""; string name=""; string directorid=""; string studioid=""; string duratiom=""; string pathlogo=""; string ratingid=""; string pathfilm="";

            try
            {
                db.ConnectionString = "Data Source=\"" + "C:\\Users\\Михаил\\source\\repos\\MediaPlayer\\MediaPlayer\\Resurses\\film.db" + "\"";
                db.Open();
                try
                {
                    SQLiteCommand cmdSelect = db.CreateCommand();

                    cmdSelect.CommandText = command ;
                    
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
                                case 2: { directorid = reader.GetValue(colCtr).ToString(); } break;
                                case 3: { studioid = reader.GetValue(colCtr).ToString(); } break;
                                case 4: { duratiom = reader.GetValue(colCtr).ToString(); } break;
                                case 7: { pathlogo = reader.GetValue(colCtr).ToString(); } break;
                                case 6: { ratingid = reader.GetValue(colCtr).ToString(); } break;
                                case 5: { pathfilm = reader.GetValue(colCtr).ToString(); } break;    
                            }
                        }
                        film = new Film(filmid, name, directorid, studioid, duratiom, pathlogo, ratingid, pathfilm);
                        list.Add(film);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error Executing SQL: " + e.ToString(), "Exception While Displaying MyTable ...");
                }
                db.Close();
            }
            finally
            {
              //   delete(IDisposable)db;
            }
            return list;
        }

        private void CinemaList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            frame.Navigate(new AboutFilm(films[CinemaList.SelectedIndex]));
        }

        private void SettingsBT_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new settings());
        }
    }
}
