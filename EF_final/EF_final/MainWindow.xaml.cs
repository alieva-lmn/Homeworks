﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace EF_final
{
    public partial class MainWindow : Window
    {
        public CountriesDatabaseContext Context { get; set; } = new();
        public ObservableCollection<Country> Countries { get; set; } = new();

        public MainWindow()
        {
            foreach (var item in Context.Countries)
            {
                Countries.Add(item);
            }

            DataContext = this;
            InitializeComponent();
        }
    }
}