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
using System.Windows.Shapes;

namespace MediaPlayer
{
    /// <summary>
    /// Логика взаимодействия для ActorSelect.xaml
    /// </summary>
    public partial class ActorSelect : Window
    {
        public ActorSelect(List<Actor> actors)
        {
            InitializeComponent();            
            ListActor.ItemsSource = actors;
            DataContext = this;
        }

        private void ListActor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           // actors[ListActor.SelectedIndex];
            this.Close();
        }
    }
}
