using EF_CRUD.DBContext;
using EF_CRUD.Models;
using Microsoft.EntityFrameworkCore;
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
using System.Xml.Linq;

namespace EF_CRUD
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Product> Products { get; set; } = new();
        private MyStoreContext _context = new();
        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
            LoadProductsAsync();
            listViewProducts.ItemsSource = Products;
        }

        private async void LoadProductsAsync()
        {
            Products.Clear();

            var products = await _context.Products.ToListAsync();

            foreach (var product in products)
            {
                Products.Add(product);
            }
        }

        private async void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var new_product = new Product();

            new_product.Name = txtName.Text;
            decimal.TryParse(priceName.Text, out decimal decimal_price);
            new_product.Price = decimal_price;
            Int32.TryParse(stockName.Text, out int int_stock);
            new_product.Stock = int_stock;

            _context.Products.Add(new_product);
            await _context.SaveChangesAsync();

            LoadProductsAsync();
        }

        private async void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (listViewProducts.SelectedItem is Product selectedProduct)
            {
                string new_name = txtName.Text;
                decimal.TryParse(priceName.Text, out decimal decimal_price);
                Int32.TryParse(stockName.Text, out int int_stock);

                selectedProduct.Name = new_name;
                selectedProduct.Price = decimal_price;
                selectedProduct.Stock = int_stock;

                _context.Products.Update(selectedProduct);
                await _context.SaveChangesAsync();

                LoadProductsAsync();
            }
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (listViewProducts.SelectedItem is Product selectedProduct)
            {
                _context.Products.Remove(selectedProduct);
                await _context.SaveChangesAsync();
                LoadProductsAsync();
            }
        }
    }
}
