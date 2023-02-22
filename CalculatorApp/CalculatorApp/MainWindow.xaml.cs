using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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

namespace CalculatorApp
{
    public partial class MainWindow : Window
    {
        Calculation calc { get; set; } = new();
        public MainWindow()
        {
            InitializeComponent();
            ResultPanel.Text = "0";
        }
        private void ceButton_Click(object sender, RoutedEventArgs e)
        {
            if (calc.Operator == null)
            {
                calc.NumButton1 = "";
                ResultPanel.Text = "0";
            }
            else
            {
                calc.NumButton2 = "";
                ResultPanel.Text = calc.NumButton1 + calc.Operator;
            }
        }
        private void cButton_Click(object sender, RoutedEventArgs e)
        {
            calc = new();
            ResultPanel.Text = calc.Result.ToString();
        }
        private void backspaceButton_Click(object sender, RoutedEventArgs e)
        {
            if (calc.Operator == null)
            {
                if (calc.NumButton1.Length > 0)
                {
                    calc.NumButton1 = calc.NumButton1.Remove(calc.NumButton1.Length - 1, 1);
                    ResultPanel.Text = calc.NumButton1;
                }
            }
            else
            {
                if (calc.NumButton2.Length > 0)
                {
                    calc.NumButton2 = calc.NumButton2.Remove(calc.NumButton2.Length - 1, 1);
                    ResultPanel.Text = calc.NumButton1 + calc.Operator + calc.NumButton2;
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            if (calc.Operator == null)
            {
                calc.NumButton1 += button.Content.ToString();

                if (calc.NumButton1.StartsWith("0"))
                {
                    calc.NumButton1 = calc.NumButton1.Remove(0);
                    ResultPanel.Text = "0";
                }
                else
                    ResultPanel.Text = calc.NumButton1.ToString();
            }
            else
            {
                calc.NumButton2 += button.Content.ToString();

                if (calc.NumButton2.StartsWith("0"))
                {
                    calc.NumButton2 = calc.NumButton2.Remove(0);
                    ResultPanel.Text = "0";
                }
                else
                    ResultPanel.Text = calc.NumButton1 + calc.Operator + calc.NumButton2;
            }
        }
        private void commaButton_Click(object sender, RoutedEventArgs e)
        {
            if (calc.Operator == null)
            {
                calc.NumButton1 += ',';
                ResultPanel.Text = calc.NumButton1;
            }
            else
            {
                calc.NumButton2 += ',';
                ResultPanel.Text = calc.NumButton1 + calc.Operator + calc.NumButton2;
            }
        }
        private void percentButton_Click(object sender, RoutedEventArgs e)
        {
            calc.Result = Convert.ToDouble(calc.NumButton1) * Convert.ToDouble(calc.NumButton2) / 100;
            ResultPanel.Text = calc.Result.ToString();
            calc.Result += Convert.ToDouble(calc.NumButton1);

            calc.NumButton1 = calc.Result.ToString();
            calc.NumButton2 = null;
        }
        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            if (calc.Operator == null)
            {
                calc.Operator = button.Content.ToString();
            }
            else
            {
                calc.Result = Calculation.PerformCalculation(calc);
                ResultPanel.Text = calc.Result.ToString();
                calc.NumButton1 = calc.Result.ToString();
                calc.NumButton2 = null;
                calc.Operator = button.Content.ToString();
            }

            ResultPanel.Text = calc.NumButton1 + calc.Operator;
        }
        private void equalButton_Click(object sender, RoutedEventArgs e)
        {
            calc.Result = Calculation.PerformCalculation(calc);
            ResultPanel.Text = calc.Result.ToString();
        }
    }
}