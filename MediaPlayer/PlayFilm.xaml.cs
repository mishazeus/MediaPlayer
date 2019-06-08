using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SQLite;

namespace MediaPlayer
{
    /// <summary>
    /// Логика взаимодействия для PlayFilm.xaml
    /// </summary>
    public partial class PlayFilm : Page
    {
       
        public PlayFilm(string Path)
        {
            

            //  Mystring.Replace(@'\',@'/');
       
            InitializeComponent();

            Cinema.Source = new Uri(Path);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Cinema.Play();
        }

        private void ButtonPause(object sender, RoutedEventArgs e)
        {
            Cinema.Pause();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            TimeSpan ts = TimeSpan.FromSeconds(e.NewValue);
            Cinema.Pause();
            Cinema.Position = ts;
            Cinema.Play();
        }

        void timer_Tick(object seender, EventArgs e) {
            slider.Value = Cinema.Position.TotalSeconds;
        }

        private void Cinema_MediaOpened(object sender, RoutedEventArgs e)
        {
            if (Cinema.NaturalDuration.HasTimeSpan) {
                TimeSpan ts = TimeSpan.FromSeconds(Cinema.NaturalDuration.TimeSpan.TotalSeconds);
                slider.Maximum = ts.TotalSeconds;
            }
        }
    }      
}
