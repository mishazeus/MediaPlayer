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
using System.Net;
using System.Net.Sockets;

namespace MediaPlayer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WindowState = WindowState.Normal;
            WindowState = WindowState.Maximized;
            RootGrid.Height = System.Windows.SystemParameters.PrimaryScreenHeight;
            RootGrid.Width = System.Windows.SystemParameters.PrimaryScreenWidth;

            frame.Height = System.Windows.SystemParameters.PrimaryScreenHeight;
            frame.Width = System.Windows.SystemParameters.PrimaryScreenWidth;
            frame.Navigate(new Library());

            
            
        }

       
    }
}
