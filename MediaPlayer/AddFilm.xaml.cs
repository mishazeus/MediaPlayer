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

        public delegate void SendAdd(bool trig);
        public static event SendAdd onNameAdd;

        Film film;
        Operator operat;
        HashSet<Operator> operators;
        HashSet<Director> directors;
        Location location;
        HashSet<Location> locations;
        Studio studio;
        HashSet<Studio> studios;
        Rating rating;
        HashSet<Rating> ratings;
        Screenwriter screenwriter;
        HashSet<Screenwriter> screenwriters;
        Producer producer;
        HashSet<Producer> producers;
        Editor editor;
        HashSet<Editor> editors;
        Composer composer;
        HashSet<Composer> composers;
        Genre genre;
        HashSet<Genre> genres;
        Actor actor;
        HashSet<Actor> actors;
        HashSet<Actor> actors2;

        string genreIO;


        public AddFilm()
        {
            InitializeComponent();
            Path = Directory.GetParent(standartPath).ToString();
            film = new Film();
            operators = new HashSet<Operator>();
            directors = new HashSet<Director>();
            screenwriters = new HashSet<Screenwriter>();
            locations = new HashSet<Location>();
            ratings = new HashSet<Rating>();
            studios = new HashSet<Studio>();
            producers = new HashSet<Producer>();
            editors = new HashSet<Editor>();
            composers = new HashSet<Composer>();
            genres = new HashSet<Genre>();
            actors = new HashSet<Actor>();
            actors2 = new HashSet<Actor>();
            genreIO = "";

            updateList();


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
            Actor.ItemsSource = actors;
            ActorList.ItemsSource = actors2;
            DataContext = this;

            BufferWindow.onNamesend += Page2_onNamesend;
            StudioWindow.onNameStudio += Page3_onNamesend;
            OneBufferWindow.onNameBuf += Page_onNamesend;
        }

        public AddFilm(string actor1, string director1, string oper1, string screenwriter1, string location1, string rating1, string studio1, string editor1, string composer1, string genre1, string producer1)
        {
            InitializeComponent();
            Path = Directory.GetParent(standartPath).ToString();
            film = new Film();
            operators = new HashSet<Operator>();
            directors = new HashSet<Director>();
            screenwriters = new HashSet<Screenwriter>();
            locations = new HashSet<Location>();
            ratings = new HashSet<Rating>();
            studios = new HashSet<Studio>();
            producers = new HashSet<Producer>();
            editors = new HashSet<Editor>();
            composers = new HashSet<Composer>();
            genres = new HashSet<Genre>();
            actors = new HashSet<Actor>();
            actors2 = new HashSet<Actor>();

            updateList();


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
            Actor.ItemsSource = actors;
            ActorList.ItemsSource = actors2;
            DataContext = this;

            Director.SelectedItem = director1;
            Screenwriter.SelectedItem = screenwriter1;
            Operator.SelectedItem = oper1;
            Country.SelectedItem = location1;
            Rating.SelectedItem = rating1;
            Producer.SelectedItem = producer1;
            Studio.SelectedItem = studio1;
            Editor.SelectedItem = editor1;
            Composer.SelectedItem = composer1;
            // Genre.SelectedItem = genre1;

            //ActorList.ItemsSource = actors2;


            BufferWindow.onNamesend += Page2_onNamesend;

        }

        void updateList() {
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
        }

        void updateComboB() {
            Actor.Items.Refresh();
            Producer.Items.Refresh();
            Director.Items.Refresh();
            Screenwriter.Items.Refresh();
            Operator.Items.Refresh();
            Country.Items.Refresh();
            Studio.Items.Refresh();
            Editor.Items.Refresh();
            Composer.Items.Refresh();
            Genre.Items.Refresh();
        }
        
        

        void deleteD() {
            actors.Clear();
            producers.Clear();
            directors.Clear();
            screenwriters.Clear();
            operators.Clear();
            studios.Clear();
            editors.Clear();
            composers.Clear();
            genres.Clear();
            locations.Clear();
        }
       

      

        void Page2_onNamesend(bool tr)
        {
            if (tr == true)
            {
                deleteD();
                updateList();
                updateComboB();
            }
        }

        void Page3_onNamesend(bool tr)
        {
            if (tr == true)
            {
                deleteD();
                updateList();
                updateComboB();
            }

        }

        void Page_onNamesend(bool tr)
        {
            if (tr == true)
            {
                deleteD();
                updateList();
                updateComboB();
            }

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Year.Text != "" && Country.SelectedItem != null && Studio.SelectedItem != null && Director.SelectedItem != null && Screenwriter.SelectedItem != null
                && Producer.SelectedItem != null && Operator.SelectedItem != null && Composer.SelectedItem != null && Time.Text != "" && Editor.SelectedItem != null
                && Genre.SelectedItem != null && Budget.Text != "" && Rating.SelectedItem != null && Name.Text != "")
            {
        char ch1 = '\\';
        char ch2 = '/';
        P($"INSERT INTO 'main'.'Film'('Name', 'directorID', 'studioID', 'duratiom', 'link', 'ratingID', 'PathLogo','Year','Budget','producerID','screenwriterID','editorID','composerID','operatorID')" +
        $" VALUES('{Name.Text}', '{film.DirectorID}', '{film.StudioID}', '{Time.Text}', '{film.PathFilm}', '{film.RatingID}', '{film.PathLogo.Replace(ch1,ch2)}', '{Year.Text}','{Budget.Text}','{film.ProducerID}','{film.ScreenwriterID}','{film.EditorID}','{film.ComposerID}','{film.OperatorID}');");

        P($"INSERT INTO 'main'.'ListGenre'('genreID','filmID') VALUES('{genreIO}','{V($"SELECT filmID FROM Film WHERE Name LIKE '%{Name.Text}%';")}');");
                foreach (Actor a in actors2) {
                    P($"INSERT INTO 'main'.'ListActor'('actorID','filmID') VALUES('{a.ActorID}','{V($"SELECT filmID FROM Film WHERE Name LIKE '%{Name.Text}%';")}');");
                }
                MessageBox.Show("Фильм сохранен!");
                onNameAdd(true);
            }
            else {
                MessageBox.Show("Заполнены не все параметры!");
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
            OneBufferWindow actorSelect = new OneBufferWindow("Country", "Location");
            actorSelect.Show();
        }

        private void FStudio_Click(object sender, RoutedEventArgs e)
        {
            StudioWindow stSel = new StudioWindow("Name","Studio",locations);
            stSel.Show();
        }

        private void FDirector_Click(object sender, RoutedEventArgs e)
        {
            BufferWindow actorSelect = new BufferWindow("Name", "LastName", "Director");
            actorSelect.Show();
        }

        private void FScreenwriter_Click(object sender, RoutedEventArgs e)
        {
            BufferWindow actorSelect = new BufferWindow("Name", "LastName", "Screenwriter");
            actorSelect.Show();
        }

        private void FProducer_Click(object sender, RoutedEventArgs e)
        {
            BufferWindow actorSelect = new BufferWindow("Name", "LastName", "Producer");
            actorSelect.Show();
        }

        private void FOperator_Click(object sender, RoutedEventArgs e)
        {
            BufferWindow actorSelect = new BufferWindow("Name", "LastName", "Operator");
            actorSelect.Show();
        }

        private void FComposer_Click(object sender, RoutedEventArgs e)
        {
            BufferWindow actorSelect = new BufferWindow("Name", "LastName", "Composer");
            actorSelect.Show();
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
            BufferWindow actorSelect = new BufferWindow("Name", "LastName", "Editor");
            actorSelect.Show();
        }

        private void FGenre_Click(object sender, RoutedEventArgs e)
        {
            OneBufferWindow actorSelect = new OneBufferWindow("Genre", "Genre");
            actorSelect.Show();

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
            OneBufferWindow actorSelect = new OneBufferWindow("Country", "Location");
            actorSelect.Show();
        }

        private void FPoster_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select a picture";
            openFileDialog.Filter = "ALL FILES (*.*)|*.*|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
            if (openFileDialog.ShowDialog() == true) {
                fPoster.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                film.PathLogo = openFileDialog.FileName;
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
                film.PathFilm = openFileDialog.FileName;
            }
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
            return r;
        }

        void getDirector(string command, HashSet<Director> list)
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

        void getScreenwriter(string command, HashSet<Screenwriter> list)
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

        void getOperator(string command, HashSet<Operator> list)
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

        void getLocation(string command, HashSet<Location> list)
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

        void getRating(string command, HashSet<Rating> list)
        {
            SQLiteConnection db = new SQLiteConnection();
            
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

        void getStudio(string command, HashSet<Studio> list)
        {
            SQLiteConnection db = new SQLiteConnection();

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

        void getProducer(string command, HashSet<Producer> list)
        {
            SQLiteConnection db = new SQLiteConnection();

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
                        producer = new Producer();
                        for (int colCtr = 0; colCtr < reader.FieldCount; ++colCtr)
                        {
                            switch (colCtr)
                            {
                                case 0: { producer.ProducerID = reader.GetValue(colCtr).ToString(); } break;
                                case 1: { producer.Name = reader.GetValue(colCtr).ToString(); } break;
                                case 2: { producer.LastName = reader.GetValue(colCtr).ToString(); } break;
                            
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

        void getEditor(string command, HashSet<Editor> list)
        {
            SQLiteConnection db = new SQLiteConnection();

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

        void getComposer(string command, HashSet<Composer> list)
        {
            SQLiteConnection db = new SQLiteConnection();

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

        void getGenre(string command, HashSet<Genre> list)
        {
            SQLiteConnection db = new SQLiteConnection();

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

        void getActor(string command, HashSet<Actor> list)
        {
            SQLiteConnection db = new SQLiteConnection();

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
            BufferWindow actorSelect = new BufferWindow("Name","LastName","Actor");
            actorSelect.Show();
        }

        private void Actor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Actor ac = new MediaPlayer.Actor();
            foreach (Actor actor in actors)
            {
                if (actor == Actor.SelectedItem)
                {
                    ac = actor;
                }
            }
           
            actors2.Add(ac);
            ActorList.Items.Refresh();
        }

        private void ActorList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Actor ac = new MediaPlayer.Actor();
            foreach (Actor actor in actors2)
            {
                if (actor == ActorList.SelectedItem)
                {
                    ac = actor;
                }
            }

            actors2.Remove(ac);
            ActorList.Items.Refresh();
        }

        private void Country_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                r2.Fill = Brushes.Green;
        }

        private void Studio_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                r3.Fill = Brushes.Green;
            foreach (Studio s in studios)
            {
                if (Studio.SelectedItem == s)
                {
                    film.StudioID = s.StudioID.ToString();
                }
            }
        }

        private void Director_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                r4.Fill = Brushes.Green;
            foreach (Director d in directors) {
                if (Director.SelectedItem == d) {
                    film.DirectorID = d.DirectorID.ToString();
                }
            }
        }

        private void Screenwriter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                r5.Fill = Brushes.Green;
            foreach (Screenwriter s in screenwriters)
            {
                if (Screenwriter.SelectedItem == s)
                {
                    film.ScreenwriterID = s.ScreenwriterID.ToString();
                }
            }
        }

        private void Producer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                r6.Fill = Brushes.Green;
            foreach (Producer p in producers)
            {
                if (Producer.SelectedItem == p)
                {
                    film.ProducerID = p.ProducerID.ToString();
                }
            }
        }

        private void Operator_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                r7.Fill = Brushes.Green;
            foreach (Operator o in operators)
            {
                if (Operator.SelectedItem == o)
                {
                    film.OperatorID = o.OperatorID.ToString();
                }
            }
        }

        private void Composer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                r8.Fill = Brushes.Green;
            foreach (Composer c in composers)
            {
                if (Composer.SelectedItem == c)
                {
                    film.ComposerID = c.ComposerID.ToString();
                }
            }
        }

        private void Editor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                r10.Fill = Brushes.Green;
            foreach (Editor ed in editors)
            {
                if (Editor.SelectedItem == ed)
                {
                    film.EditorID = ed.EditorID.ToString();
                }
            }
        }

        private void Genre_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                r11.Fill = Brushes.Green;
            foreach (Genre g in genres)
            {
                if (Genre.SelectedItem == g)
                {
                    genreIO = g.GenreID.ToString();
                }
            }
        }

        private void Rating_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                r13.Fill = Brushes.Green;
            foreach (Rating r in ratings)
            {
                if (Rating.SelectedItem == r)
                {
                    film.RatingID = r.RatingID.ToString();
                }
            }
        }
   
    }
}
