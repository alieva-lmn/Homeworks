using Store_code_first_approach_.DB_Context;
using Store_code_first_approach_.Models;
using System;
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

namespace Store_code_first_approach_
{
    public partial class MainWindow : Window
    {
        StoreDBContext context { get; set; } = new();
        public ObservableCollection<Products> Products { get; set; } = new();
        public MainWindow()
        {
            foreach (var item in context.Products)
            {
                Products.Add(item);
            }
            DataContext = this;
            InitializeComponent();
        }
        private void ADDButton_Click(object sender, RoutedEventArgs e)
        {
            var addView = new AddWindow();
            addView.ShowDialog();
        }
    }
}
