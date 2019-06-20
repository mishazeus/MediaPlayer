using System;
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
    /// Логика взаимодействия для OneBufferWindow.xaml
    /// </summary>
    public partial class OneBufferWindow : Window
    {
        string standartPath = Directory.GetCurrentDirectory().ToString();
        string Path;
        public delegate void SendBuf(bool trig);
        public static event SendBuf onNameBuf;

        

        public OneBufferWindow(string col1, string titleName)
        {
            InitializeComponent();
            Path = Directory.GetParent(standartPath).ToString();
            onebufferwindow.Title = titleName;
           
            c1.Text = col1; 
            
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (Col1.Text != "")
            {
                V($"INSERT INTO 'main'.'{Title}'('{c1.Text}') VALUES ('{Col1.Text}');");
                onNameBuf(true);
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
       } 
    }
