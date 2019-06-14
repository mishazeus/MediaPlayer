using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace MediaPlayer
{
    /// <summary>
    /// Логика взаимодействия для AddFilm.xaml
    /// </summary>
    public partial class AddFilm : Page
    {
        string standartPath = Directory.GetCurrentDirectory().ToString();
        string Path;

        Film film;
        Operator operat;
        List<Operator> operators;
        List<Director> directors;
        Location location;
        List<Location> locations;
        Studio studio;
        List<Studio> studios;
        Rating rating;
        List<Rating> ratings;
        Screenwriter screenwriter;
        List<Screenwriter> screenwriters;
        Producer producer;
        List<Producer> producers;
        Editor editor;
        List<Editor>editors;
        Composer composer;
        List<Composer> composers;
        Genre genre;
        List<Genre> genres;
        Actor actor;
        List<Actor> actors;

        public AddFilm()
        {
            InitializeComponent();
            Path = Directory.GetParent(standartPath).ToString();
            operators = new List<Operator>();
            directors = new List<Director>();
            screenwriters = new List<Screenwriter>();
            locations = new List<Location>();
            ratings = new List<Rating>();
            studios = new List<Studio>();
            producers = new List<Producer>();
            editors = new List<Editor>();
            composers = new List<Composer>();
            genres = new List<Genre>();
            actors = new List<Actor>();
            
            getDirector("SELECT * FROM Director;", directors); 
            getScreenwriter("SELECT * FROM Screenwriter;", screenwriters);
            getOperator("SELECT * FROM Operator;", operators);
            getLocation("SELECT * FROM Location;", locations);
            getRating("SELECT * FROM Rating;", ratings);
            getStudio("SELECT * FROM Studio;", studios);
            getProducer("SELECT * FROM Producer;", producers);
            getEditor("SELECT * FROM Editor;", editors);
            getComposer("SELECT * FROM Composer;", composers);
            getGenre("SELECT * FROM Genre;", genres);
            getActor("SELECT * FROM Actor;", actors);
           
           Director.ItemsSource = directors; 
           Screenwriter.ItemsSource = screenwriters;
           Operator.ItemsSource = operators;
           Country.ItemsSource = locations;
           Rating.ItemsSource = ratings;
           Producer.ItemsSource = producers;
           Studio.ItemsSource = studios;
           Editor.ItemsSource = editors;
           Composer.ItemsSource = composers;
           Genre.ItemsSource = genres;
           //Actor.ItemsSource = actors;

            DataContext = this;

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Year.Text != "" && Country.Text != "" && Studio.Text != "" && Director.Text != "" && Screenwriter.Text != ""
                && Producer.Text != "" && Operator.Text != "" && Composer.Text != "" && Time.Text != "" && Editor.Text != ""
                && Genre.Text != "" && Budget.Text != "" && Rating.Text != "" && Name.Text != "")
            {
                
          //      P($"INSERT INTO 'main'.'Film'('filmName', 'directorID', 'studioID', 'duratiom', 'link', 'ratingID', 'ImageLogo') VALUES('{hgk}', {1}, {2}, '{145 min}', '{6hi/g}', {2}, '{julu/gk}'); ");
            }
            else {
                //r0.Fill = Brushes.Red;
                //r1.Fill = Brushes.Red;
                //r2.Fill = Brushes.Red;
                //r3.Fill = Brushes.Red;
                //r4.Fill = Brushes.Red;
                //r5.Fill = Brushes.Red;
                //r6.Fill = Brushes.Red;
                //r7.Fill = Brushes.Red;
                //r8.Fill = Brushes.Red;
                //r9.Fill = Brushes.Red;
                //r10.Fill = Brushes.Red;
                //r11.Fill = Brushes.Red;
                //r12.Fill = Brushes.Red;
                //r13.Fill = Brushes.Red;

            }
        }

        private void FName_Click(object sender, RoutedEventArgs e)
        {
            if (Name.Text != "")
            {
                r0.Fill = Brushes.Green;
            }
            else { r0.Fill = Brushes.Red; }
        }

        void P(string command)
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

        private void FYear_Click(object sender, RoutedEventArgs e)
        {
            if (Year.Text != "")
            {
                r1.Fill = Brushes.Green;
            }
            else { r1.Fill = Brushes.Red; }
        }

        private void FCountry_Click(object sender, RoutedEventArgs e)
        {
            if (Country.Text != "")
            {
                r2.Fill = Brushes.Green;
            }
            else { r2.Fill = Brushes.Red; }
        }

        private void FStudio_Click(object sender, RoutedEventArgs e)
        {
            if (Studio.Text != "")
            {
                r3.Fill = Brushes.Green;
            }
            else { r3.Fill = Brushes.Red; }
        }

        private void FDirector_Click(object sender, RoutedEventArgs e)
        {
            if (Director.Text != "")
            {
                r4.Fill = Brushes.Green;
            }
            else { r4.Fill = Brushes.Red; }
        }

        private void FScreenwriter_Click(object sender, RoutedEventArgs e)
        {
            if (Screenwriter.Text != "")
            {
                r5.Fill = Brushes.Green;
            }
            else { r5.Fill = Brushes.Red; }
        }

        private void FProducer_Click(object sender, RoutedEventArgs e)
        {
            if (Producer.Text != "")
            {
                r6.Fill = Brushes.Green;
            }
            else { r6.Fill = Brushes.Red; }
        }

        private void FOperator_Click(object sender, RoutedEventArgs e)
        {
            if (Operator.Text != "")
            {
                r7.Fill = Brushes.Green;
            }
            else { r7.Fill = Brushes.Red; }
        }

        private void FComposer_Click(object sender, RoutedEventArgs e)
        {
            if (Composer.Text != "")
            {
                r8.Fill = Brushes.Green;
            }
            else { r8.Fill = Brushes.Red; }
        }

        private void FTime_Click(object sender, RoutedEventArgs e)
        {
            if (Time.Text != "")
            {
                r9.Fill = Brushes.Green;
            }
            else { r9.Fill = Brushes.Red; }
        }

        private void FEditor_Click(object sender, RoutedEventArgs e)
        {
            if (Editor.Text != "")
            {
                r10.Fill = Brushes.Green;
            }
            else { r10.Fill = Brushes.Red; }
        }

        private void FGenre_Click(object sender, RoutedEventArgs e)
        {
            if (Genre.Text != "")
            {
                r11.Fill = Brushes.Green;
            }
            else { r11.Fill = Brushes.Red; }
        }

        private void FBudget_Click(object sender, RoutedEventArgs e)
        {
            if (Budget.Text != "")
            {
                r12.Fill = Brushes.Green;
            }
            else { r12.Fill = Brushes.Red; }
        }

        private void FRating_Click(object sender, RoutedEventArgs e)
        {
            if (Rating.Text != "")
            {
                r13.Fill = Brushes.Green;
            }
            else { r13.Fill = Brushes.Red; }
        }

        private void FPoster_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select a picture";
            openFileDialog.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
            if (openFileDialog.ShowDialog() == true) {
                fPoster.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }
                
        }

        private void FilmPath_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select a film";
            openFileDialog.Filter = "MKV Files (*.mkv)|*.mkv|MP4 Files (*.mp4)|*.mp4|AVI Files (*.avi)|*.avi";
            if (openFileDialog.ShowDialog() == true)
            {
                //insert filmpath
                filmPath.Background = Brushes.Green;
            }
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

        void getDirector(string command, List<Director> list)
        {
            SQLiteConnection db = new SQLiteConnection();
            
            try
            {
                db.ConnectionString = "Data Source=\"" + Directory.GetParent(Path).ToString() + "\\Resurses\\film.db" + "\"";
                
                db.Open();
                try
                {
                    SQLiteCommand cmdSelect = db.CreateCommand();

                    cmdSelect.CommandText = command;
                    SQLiteDataReader reader = cmdSelect.ExecuteReader();

                                while (reader.Read())
                                {
                                  Director director = new Director();
                                    for (int colCtr = 0; colCtr < reader.FieldCount; ++colCtr)
                                    {
                                        switch (colCtr)
                                        {
                                            case 0: {director.DirectorID = reader.GetValue(colCtr).ToString(); } break;
                                            case 1: { director.Name = reader.GetValue(colCtr).ToString(); } break;
                                            case 2: { director.LastName = reader.GetValue(colCtr).ToString(); } break;
                                            case 3: { director.YearOfBorn = reader.GetValue(colCtr).ToString(); } break;
                                           
                                        }
                                    }
                                    list.Add(director);
                                }
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

        void getScreenwriter(string command, List<Screenwriter> list)
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
                        screenwriter = new Screenwriter();
                        for (int colCtr = 0; colCtr < reader.FieldCount; ++colCtr)
                        {
                            switch (colCtr)
                            {
                                case 0: { screenwriter.ScreenwriterID = reader.GetValue(colCtr).ToString(); } break;
                                case 1: { screenwriter.Name = reader.GetValue(colCtr).ToString(); } break;
                                case 2: { screenwriter.LastName = reader.GetValue(colCtr).ToString(); } break;
                                case 3: { screenwriter.FilmID = reader.GetValue(colCtr).ToString(); } break;
                            }
                        }
                        list.Add(screenwriter);
                    }

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

        void getOperator(string command, List<Operator> list)
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
                       operat = new Operator();
                        for (int colCtr = 0; colCtr < reader.FieldCount; ++colCtr)
                        {
                            switch (colCtr)
                            {
                                case 0: { operat.OperatorID = reader.GetValue(colCtr).ToString(); } break;
                                case 1: { operat.Name = reader.GetValue(colCtr).ToString(); } break;
                                case 2: { operat.LastName = reader.GetValue(colCtr).ToString(); } break;
                                case 3: { operat.FilmID = reader.GetValue(colCtr).ToString(); } break;
                            }
                        }
                        list.Add(operat);
                    }

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

        void getLocation(string command, List<Location> list)
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
                        location = new Location();
                        for (int colCtr = 0; colCtr < reader.FieldCount; ++colCtr)
                        {
                            switch (colCtr)
                            {
                                case 0: { location.CountryID = reader.GetValue(colCtr).ToString(); } break;
                                case 1: { location.Country = reader.GetValue(colCtr).ToString(); } break;
                               
                            }
                        }
                        list.Add(location);
                    }

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

        void getRating(string command, List<Rating> list)
        {
            SQLiteConnection db = new SQLiteConnection();
            
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
                        rating = new Rating();
                        for (int colCtr = 0; colCtr < reader.FieldCount; ++colCtr)
                        {
                            switch (colCtr)
                            {
                                case 0: { rating.RatingID = reader.GetValue(colCtr).ToString(); } break;
                                case 1: { rating.Ratings = reader.GetValue(colCtr).ToString(); } break;

                            }
                        }
                        list.Add(rating);
                    }

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

        void getStudio(string command, List<Studio> list)
        {
            SQLiteConnection db = new SQLiteConnection();

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
                        studio = new Studio();
                        for (int colCtr = 0; colCtr < reader.FieldCount; ++colCtr)
                        {
                            switch (colCtr)
                            {
                                case 0: { studio.StudioID = reader.GetValue(colCtr).ToString(); } break;
                                case 1: { studio.Name = reader.GetValue(colCtr).ToString(); } break;
                                case 2: { studio.CountryID = reader.GetValue(colCtr).ToString(); } break;

                            }
                        }
                        list.Add(studio);
                    }

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

        void getProducer(string command, List<Producer> list)
        {
            SQLiteConnection db = new SQLiteConnection();

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
                        producer = new Producer();
                        for (int colCtr = 0; colCtr < reader.FieldCount; ++colCtr)
                        {
                            switch (colCtr)
                            {
                                case 0: { producer.ProducerID = reader.GetValue(colCtr).ToString(); } break;
                                case 1: { producer.Name = reader.GetValue(colCtr).ToString(); } break;
                                case 2: { producer.LastName = reader.GetValue(colCtr).ToString(); } break;
                                case 3: { producer.FilmID = reader.GetValue(colCtr).ToString(); } break;

                            }
                        }
                        list.Add(producer);
                    }

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

        void getEditor(string command, List<Editor> list)
        {
            SQLiteConnection db = new SQLiteConnection();

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
                        editor = new Editor();
                        for (int colCtr = 0; colCtr < reader.FieldCount; ++colCtr)
                        {
                            switch (colCtr)
                            {
                                case 0: { editor.EditorID = reader.GetValue(colCtr).ToString(); } break;
                                case 1: { editor.Name = reader.GetValue(colCtr).ToString(); } break;
                                case 2: { editor.LastName = reader.GetValue(colCtr).ToString(); } break;
                                case 3: { editor.FilmID = reader.GetValue(colCtr).ToString(); } break;

                            }
                        }
                        list.Add(editor);
                    }

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

        void getComposer(string command, List<Composer> list)
        {
            SQLiteConnection db = new SQLiteConnection();

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
                        composer = new Composer();
                        for (int colCtr = 0; colCtr < reader.FieldCount; ++colCtr)
                        {
                            switch (colCtr)
                            {
                                case 0: { composer.ComposerID = reader.GetValue(colCtr).ToString(); } break;
                                case 1: { composer.Name = reader.GetValue(colCtr).ToString(); } break;
                                case 2: { composer.LastName = reader.GetValue(colCtr).ToString(); } break;
                                case 3: { composer.FilmID = reader.GetValue(colCtr).ToString(); } break;

                            }
                        }
                        list.Add(composer);
                    }

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

        void getGenre(string command, List<Genre> list)
        {
            SQLiteConnection db = new SQLiteConnection();

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
                        genre = new Genre();
                        for (int colCtr = 0; colCtr < reader.FieldCount; ++colCtr)
                        {
                            switch (colCtr)
                            {
                                case 0: { genre.GenreID = reader.GetValue(colCtr).ToString(); } break;
                                case 1: { genre.Genres = reader.GetValue(colCtr).ToString(); } break;

                            }
                        }
                        list.Add(genre);
                    }

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

        void getActor(string command, List<Actor> list)
        {
            SQLiteConnection db = new SQLiteConnection();

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
                        actor = new Actor();
                        for (int colCtr = 0; colCtr < reader.FieldCount; ++colCtr)
                        {
                            switch (colCtr)
                            {
                                case 0: { actor.ActorID = reader.GetValue(colCtr).ToString(); } break;
                                case 1: { actor.Name = reader.GetValue(colCtr).ToString(); } break;
                                case 2: { actor.LastName = reader.GetValue(colCtr).ToString(); } break;
                                case 3: { actor.YearOfBorn = reader.GetValue(colCtr).ToString(); } break;
                            }
                        }
                        list.Add(actor);
                    }

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
            
            ActorSelect actorSelect = new ActorSelect(actors);
            actorSelect.Show();
        }
    }
}
