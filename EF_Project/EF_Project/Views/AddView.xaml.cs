using EF_Project.DB_Context;
using EF_Project.Models;
using System;
using System.Collections.Generic;
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

namespace EF_Project.Views
{
    public partial class AddView : Window
    {
        public CountriesDBContext Context { get; set; } = new();
        public Country Country { get; set; }
        public AddView()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in Context.GovernmentForms)
            {
                Console.WriteLine(item.Form);
            }
            Context.Add(Country);
            Context.SaveChanges();
            this.Close();
        }
    }
}
