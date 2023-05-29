using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
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

namespace Store
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Products>? Products { get; set; } = new ObservableCollection<Products>();
        public ObservableCollection<Categories>? Categories { get; set; } = new ObservableCollection<Categories>();

        public MainWindow()
        {
            DataContext = this;
            Products = DownloadProductsData();
            DownloadCategoriesData();
            InitializeComponent();
        }

        private SqlConnection OpenConnection()
        {
            SqlConnection conn = new();
            conn.ConnectionString =
            "Data Source=LAPTOP-HVUR0JDE;" +
            "Initial Catalog=Store;" +
            "Integrated Security=SSPI;";
            conn.Open();
            return conn;
        }

        private ObservableCollection<Products>? DownloadProductsData()
        {
            var conn = OpenConnection();
            var cmd = new SqlCommand("select * from Products", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            ObservableCollection<Products>? products = new();

            while (reader.Read())
            {
                var prod = new Products((int)reader["ID"], (string)reader["Name"],
                    (decimal)reader["Price"], (int)reader["Stock"], (string)reader["Image"], (int)reader["CategoriesID"]);

                products.Add(prod);
            }
            reader.Close();
            conn.Close();
            return products;
        }

        private ObservableCollection<Categories>? DownloadCategoriesData()
        {
            var conn = OpenConnection();
            var cmd = new SqlCommand("select * from Categories", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var cat = new Categories((int)reader["ID"], (string)reader["Name"]);

                Categories.Add(cat);
            }
            reader.Close();
            conn.Close();
            return Categories;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Products.Clear();
            
            var allproducts = DownloadProductsData();
            int index = 0;

            for (int i = 0; i < Categories.Count; i++)
            {
                if (button.Content == Categories[i].Name)
                {
                    index = Categories[i].ID;
                    break;
                }
            }

            for (int i = 0; i < allproducts.Count; i++)
            {
                if (allproducts[i].CategoriesID == index)
                {
                    Products.Add(allproducts[i]);
                }
            }            
        }
    }
}
