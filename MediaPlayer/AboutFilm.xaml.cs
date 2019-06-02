﻿using System;
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


namespace MediaPlayer
{
    /// <summary>
    /// Логика взаимодействия для AboutFilm.xaml
    /// </summary>
    public partial class AboutFilm : Page
    {
        public AboutFilm(Film film)
        {
            InitializeComponent();
            DataContext = film;
            fText.Text = "";
            aText.Text = "";
           
         
        }

    }
}
