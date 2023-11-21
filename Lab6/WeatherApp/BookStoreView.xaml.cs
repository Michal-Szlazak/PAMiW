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
using System.Windows.Shapes;
using WeatherApp.ViewModels;

namespace WeatherApp
{
    /// <summary>
    /// Logika interakcji dla klasy BookStoreView.xaml
    /// </summary>
    public partial class BookStoreView : Window
    {
        public BookStoreView(BooksViewModel booksViewModel)
        {
            DataContext = booksViewModel;
            InitializeComponent();
        }
    }
}
