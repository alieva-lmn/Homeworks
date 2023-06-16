using EF_Project.DB_Context;
using EF_Project.Models;
using EF_Project.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata;
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

namespace EF_Project
{
    public partial class MainWindow : Window
    {
        public CountriesDB CountriesDB { get; set; } = new();
        public ObservableCollection<Country> Countries { get; set; } = new();
        public List<string> FiltrationList { get; set; } = new List<string> { "Filter by Population", "Filter by GDP", "Filter by Name" };

        public MainWindow()
        {
            foreach (var item in CountriesDB.Context.Countries)
            {
                Countries.Add(item);
            }

            DataContext = this;
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var addView = new AddView();
            addView.ShowDialog();
        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            if (button.Content.ToString() == FiltrationList[0])
            {
                var sortedbypopulation = CountriesDB.Context.Countries.OrderByDescending(x => x.Population);

                Countries.Clear();

                foreach (var item in sortedbypopulation)
                {
                    Countries.Add(item);
                }
            }
            else if (button.Content.ToString() == FiltrationList[1])
            {
                var sortedbygdp = CountriesDB.Context.Countries.OrderByDescending(x => x.GDP);

                Countries.Clear();

                foreach (var item in sortedbygdp)
                {
                    Countries.Add(item);
                }
            }
            else if (button.Content.ToString() == FiltrationList[2])
            {
                var sortedbyname = CountriesDB.Context.Countries.OrderBy(x => x.Name);

                Countries.Clear();

                foreach (var item in sortedbyname)
                {
                    Countries.Add(item);
                }
            } 
        }
    }
}
