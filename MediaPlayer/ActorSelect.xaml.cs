using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MediaPlayer
{
    /// <summary>
    /// Логика взаимодействия для ActorSelect.xaml
    /// </summary>
    public partial class ActorSelect : Window
    {
        string standartPath = Directory.GetCurrentDirectory().ToString();
        string Path;
        public delegate void SendEv(bool trig);
        public static event SendEv onNameSend;

        public ActorSelect(){
            InitializeComponent();
            Path = Directory.GetParent(standartPath).ToString();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Col1.Text!="" && Col2.Text!="" && Col3.Text!="") {
                V($"INSERT INTO 'main'.'Actor'('Name','LastName','YearOfBorn') VALUES ('{Col1.Text}', '{Col2.Text}', '{Col3.Text}');");
                onNameSend(true);
                this.Close();
            }
        }

        void V(string command)
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
    }
}
