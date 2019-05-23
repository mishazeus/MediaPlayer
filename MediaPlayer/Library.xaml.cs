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
using System.IO;
using Microsoft.Win32;
using Mono.Ssdp;
using Mono.Upnp;
using Client = Mono.Ssdp.Client;
using System.Net.Sockets;

namespace MediaPlayer
{
    /// <summary>
    /// Логика взаимодействия для Library.xaml
    /// </summary>
    public partial class Library : Page
    {
        public Library()
        {
            InitializeComponent();

                 OpenFileDialog openFileDialog = new OpenFileDialog();
                 if (openFileDialog.ShowDialog() == true) {
                   string fileName = openFileDialog.FileName; 
               text.Text = fileName; }


            SQLiteConnection db = new SQLiteConnection();

                try
                {
                    db.ConnectionString = "Data Source=\"" + "C:\\Users\\Михаил\\source\\repos\\MediaPlayer\\MediaPlayer\\Resurses\\film.db" + "\"";
                    db.Open();
                    try
                    {
                        SQLiteCommand cmdSelect = db.CreateCommand();
                    SQLiteCommand nameSelect = db.CreateCommand();
                    SQLiteCommand pathLogoSelect = db.CreateCommand();
                    

                    cmdSelect.CommandText = "SELECT filmID FROM Film;";
                    nameSelect.CommandText = "SELECT name FROM Film;";
                    pathLogoSelect.CommandText = "SELECT ImageLogo FROM Film;";
                        SQLiteDataReader reader = cmdSelect.ExecuteReader();
                        StringBuilder sb = new StringBuilder();
                        for (int colCtr = 0; colCtr < reader.FieldCount; ++colCtr)
                        {
                            // Add Seperator (If After First Column)
                            if (colCtr > 0) sb.Append("|");

                            // Add Column Name
                            sb.Append(reader.GetName(colCtr));
                        }
                        sb.AppendLine();
                        sb.Append("~~~~~~~~~~~~");
                        sb.AppendLine();
                        while (reader.Read())
                        {
                            for (int colCtr = 0; colCtr < reader.FieldCount; ++colCtr)
                            {
                                // Add Seperator (If After First Column)
                                if (colCtr > 0) sb.Append("|");

                                // Add Column Text
                                sb.Append(reader.GetValue(colCtr).ToString());
                            }
                            sb.AppendLine();
                        }

                       // text.Text = sb.ToString();   
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Error Executing SQL: " + e.ToString(), "Exception While Displaying MyTable ...");
                    }
                    db.Close();


            }
                finally
                {
                    // delete(IDisposable)db;
                }
            
        }

        private void createFilmElements() {
            Image image = new Image();
            BitmapImage bm1 = new BitmapImage();
            bm1.BeginInit();
            bm1.UriSource = new Uri("D:/фильмы/POSTERS/iron_man.jpg", UriKind.Relative);
            bm1.CacheOption = BitmapCacheOption.OnLoad;
            bm1.EndInit();
            image.Source = bm1;
            image.Width = 300;
            image.Height = 300;
            Grid.SetColumn(image, 1);
            Grid.SetRow(image, 1);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
