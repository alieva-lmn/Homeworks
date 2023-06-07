using Store_code_first_approach_.DB_Context;
using Store_code_first_approach_.Models;
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

namespace Store_code_first_approach_
{
    public partial class AddWindow : Window
    {
        StoreDBContext Context { get; set; } = new();
        public Products Product { get; set; } = new();
        public AddWindow()
        {
            DataContext = this;
            InitializeComponent();
        }
        private void ADDButton_Click(object sender, RoutedEventArgs e)
        {
            Context.Products.Add(Product);
            Context.SaveChanges();
            this.Close();
        }
    }
}
