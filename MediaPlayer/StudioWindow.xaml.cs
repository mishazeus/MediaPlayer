﻿using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
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
using System.Windows.Shapes;

namespace MediaPlayer
{
    /// <summary>
    /// Логика взаимодействия для StudioWindow.xaml
    /// </summary>
    public partial class StudioWindow : Window
    {
        string standartPath = Directory.GetCurrentDirectory().ToString();
        string Path;
        public delegate void SendStudio(bool trig);
        public static event SendStudio onNameStudio;

        HashSet<Location> col2 = new HashSet<Location>();
        Studio studio;

        public StudioWindow(string col1, string titleName, HashSet<Location> list )
        {
            InitializeComponent();
            Path = Directory.GetParent(standartPath).ToString();
            studioWindow.Title = titleName;
            studio = new Studio();
            c1.Text = col1;
            c2.Text = "countryID";
            col2 = list;
            Col2.ItemsSource = col2;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (Col1.Text != "" && Col2.Text != "")
            {
                V($"INSERT INTO 'main'.'{Title}'('{c1.Text}','{c2.Text}') VALUES ('{Col1.Text}', '{studio.CountryID}');");
                onNameStudio(true);
                this.Close();
            }
        }

        void V(string command)
        {
            SQLiteConnection db = new SQLiteConnection();
            try
            {

                db.ConnectionString = "Data Source=\"" + Directory.GetParent(Path).ToString() + "\\Resurses\\filmdatabase.db" + "\"";

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

        string P(string command)
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

        private void Studio_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (Location s in col2) {
                if (Col2.SelectedItem == s) {
                    studio.CountryID  = s.CountryID;
                }
            }
        }
    }
}
