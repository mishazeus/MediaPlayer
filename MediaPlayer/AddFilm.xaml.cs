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

namespace MediaPlayer
{
    /// <summary>
    /// Логика взаимодействия для AddFilm.xaml
    /// </summary>
    public partial class AddFilm : Page
    {
        string standartPath = Directory.GetCurrentDirectory().ToString();
        string Path;

        public AddFilm()
        {
            InitializeComponent();
            Path = Directory.GetParent(standartPath).ToString();
        }

        string[] stringChange(string split) {    
            string[] str = split.Split(new char[] { ' ' });

            return str ;
        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Year.Text != "" && Country.Text != "" && Studio.Text != "" && Director.Text != "" && Screenwriter.Text != ""
                && Producer.Text != "" && Operator.Text != "" && Composer.Text != "" && Time.Text != "" && Editor.Text != ""
                && Genre.Text != "" && Budget.Text != "" && Rating.Text != "" && Name.Text != "")
            {
                stringChange(Director.Text);
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

                    SQLiteDataReader reader = cmdSelect.ExecuteReader();
                    while (reader.Read())
                    {
                        r = reader.GetValue(0).ToString();
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
    }
}
