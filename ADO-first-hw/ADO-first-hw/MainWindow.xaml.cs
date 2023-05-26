using System;
using System.Collections.Generic;
using System.Data;
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

namespace ADO_first_hw
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
        }

        private void DataBinding(string query)
        {
            using SqlConnection conn = new();
            conn.ConnectionString =
            "Data Source=LAPTOP-HVUR0JDE;" +
            "Initial Catalog=UpdatedHospital;" +
            "Integrated Security=SSPI;";

            conn.Open();
            SqlCommand cmd = new();
            cmd.CommandText = query;
            cmd.Connection = conn;
            var adapter = new SqlDataAdapter(cmd);
            var data = new DataTable();
            adapter.Fill(data);

            SQLDatagrid.ItemsSource = data.DefaultView;
        }
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            var query = SearchTextbox.Text;
            DataBinding(query);
        }

        private void ShowAllButton_Click(object sender, RoutedEventArgs e)
        {
            var query = "select * from Departments";
            DataBinding(query);
        }

        private void ShowMinButton_Click(object sender, RoutedEventArgs e)
        {
            var query = "select min(Places) from Wards";
            DataBinding(query);
        }

        private void ShowMaxButton_Click(object sender, RoutedEventArgs e)
        {
            var query = "select max(Salary) from Doctors";
            DataBinding(query);
        }
    }
}
