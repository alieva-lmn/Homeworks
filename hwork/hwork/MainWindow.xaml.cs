using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace hwork
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Document> Documents { get; set; } = new();
        private string index;

        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var doc = new Document();
            doc = doc.Clone() as Document;
            doc.Title = "New Document";
            doc.ID = Guid.NewGuid();
            Documents.Add(doc);
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Document doc = (sender as Button).DataContext as Document;
            
            foreach (var document in Documents)
            {
                if (document.ID == doc.ID)
                {
                    Documents.Remove(document);
                    break;
                }
            }
        }
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Document doc = (sender as Button).DataContext as Document;
            index = doc.ID.ToString();

            foreach (var document in Documents)
            {
                if (document.ID == doc.ID)
                {
                    mytextbox.Text = document.Body;
                    break;
                }
            }
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            foreach (var document in Documents)
            {
                if (document.ID.ToString() == index)
                {
                    document.Body = mytextbox.Text;
                    break;
                }
            }
        }
    }
}
