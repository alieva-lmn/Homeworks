using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ThreadHW
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonDownload_Click(object sender, RoutedEventArgs e)
        {
            Thread th = new(SendInfoToListBox);
            th.Start();
        }

        private void SendInfoToListBox()
        {
            List<string> mylist = new List<string> 
            { "Naruto",
              "Death Note", 
              "Attack on Titan", 
              "Fullmetal Alchemist: Brotherhood", 
              "Demon Slayer: Kimetsu no Yaiba"
            };

            foreach (string item in mylist)
            {
                Thread.Sleep(1000);

                Dispatcher.Invoke(() =>
                {
                    dataListBox.Items.Add(item);
                });
            }
        }
    }
}
