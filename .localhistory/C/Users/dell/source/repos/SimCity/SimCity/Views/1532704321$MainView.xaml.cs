﻿using SimCity.Services;
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

namespace SimCity
{
    /// <summary>
    /// Logika interakcji dla klasy MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void Country_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CountryComboBox.Items.Add( CountryService.GetCountry());
        }

        private void CountrySet_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
