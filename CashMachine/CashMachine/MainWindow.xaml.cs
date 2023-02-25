using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace CashMachine
{
    public partial class MainWindow : Window
    {
        public GasStation gasStation { get; set; } = new();
        double overall = 0;
        public MainWindow()
        {
            InitializeComponent();
            gasolineComboBox.ItemsSource = gasStation.GasolineOption;

            item1CheckBox.Content = gasStation.Menu[0].Name.ToString();
            item2CheckBox.Content = gasStation.Menu[1].Name.ToString();
            item3CheckBox.Content = gasStation.Menu[2].Name.ToString();
            item4CheckBox.Content = gasStation.Menu[3].Name.ToString();

            item1PriceTextBox.Text = gasStation.Menu[0].Price.ToString();
            item2PriceTextBox.Text = gasStation.Menu[1].Price.ToString();
            item3PriceTextBox.Text = gasStation.Menu[2].Price.ToString();
            item4PriceTextBox.Text = gasStation.Menu[3].Price.ToString();
        }
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;

            gasStation.Menu[0].Count = Convert.ToUInt16(item1QuantityTextBox.Text);
            gasStation.Menu[1].Count = Convert.ToUInt16(item2QuantityTextBox.Text);
            gasStation.Menu[2].Count = Convert.ToUInt16(item3QuantityTextBox.Text);
            gasStation.Menu[3].Count = Convert.ToUInt16(item4QuantityTextBox.Text);

            foreach (var item in gasStation.Menu)
            {
                if (cb.Content == item.Name)
                {
                    double res = item.Count * item.Price;
                    overall += res;
                    cafeOverallPrice.Text = overall.ToString();
                }
            }

            double finalPrice = Convert.ToDouble(gasOverallPrice.Text) + Convert.ToDouble(cafeOverallPrice.Text);
            overallPrice.Text = finalPrice.ToString();
        }
        private void quantityRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            priceTextBox.Text = "0";
        }
        private void priceRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            quantityTextBox.Text = "0";
        }
        private void quantityTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            calculateOverallPrice();
        }
        private void priceTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            calculateOverallPrice();
        }
        private void calculateOverallPrice()
        {
            if (quantityTextBox.IsEnabled == true && gasolinePriceTextBox.Text != "")
            {
                double res = Convert.ToDouble(gasolinePriceTextBox.Text, System.Globalization.CultureInfo.InvariantCulture) * Convert.ToDouble(quantityTextBox.Text, System.Globalization.CultureInfo.InvariantCulture);
                gasOverallPrice.Text = res.ToString();

                double finalPrice = Convert.ToDouble(gasOverallPrice.Text) + Convert.ToDouble(cafeOverallPrice.Text);
                overallPrice.Text = finalPrice.ToString();
            }
            if (quantityTextBox.IsEnabled == false && gasolinePriceTextBox.Text != "")
            {
                gasOverallPrice.Text = priceTextBox.Text;

                double finalPrice = Convert.ToDouble(gasOverallPrice.Text) + Convert.ToDouble(cafeOverallPrice.Text);
                overallPrice.Text = finalPrice.ToString();
            }
        }
        private void paymentButton_Click(object sender, RoutedEventArgs e)
        {
            if (overallPrice.Text != "0")
            {
                MessageBox.Show("Оплата прошла успешно!");
            }
        }
    }
}
