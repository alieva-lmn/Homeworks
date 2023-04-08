using Microsoft.VisualBasic;
using System;
using System.Collections;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ToDoList
{
    public partial class MainWindow : Window
    {
        public List<Task> Todolist { get; set; } = new();
        string path = "myList";
        public MainWindow()
        {
            var json = FileService.ReadFromFile(path, FileMode.OpenOrCreate);

            if (String.IsNullOrEmpty(json))
            {
                InitializeComponent();
                sortByDay();
                MainFrame.Content = new Page1();
            }
            else
            {
                InitializeComponent();
                Todolist = SerializeService.DeserializeList(json);
                
                sortByDay();
                MainFrame.Content = new Page1();
            }
        }

        private void sortByDay()
        {
            var json = FileService.ReadFromFile(path, FileMode.OpenOrCreate);
            Todolist = SerializeService.DeserializeList(json);

            List<Task> daylist = new();

            foreach (var item in Todolist)
            {
                if (item.Deadline == DateTime.Today)
                {
                    daylist.Add(item);
                }
            }
            myListBox.ItemsSource = daylist;
        }

        private void sortByWeek()
        {
            var json = FileService.ReadFromFile(path, FileMode.OpenOrCreate);
            Todolist = SerializeService.DeserializeList(json);

            List<Task> weeklist = new();
            var dateRange = DateTime.Today.AddDays(7);

            foreach (var item in Todolist)
            {
                if (item.Deadline.Day <= dateRange.Day && item.Deadline.Month == dateRange.Month)
                {
                    weeklist.Add(item);
                }
            }
            myListBox.ItemsSource = weeklist;
        }

        private void sortByMonth()
        {
            var json = FileService.ReadFromFile(path, FileMode.OpenOrCreate);
            Todolist = SerializeService.DeserializeList(json);

            List<Task> monthlist = new();

            foreach (var item in Todolist)
            {
                if (item.Deadline.Month == DateTime.Today.Month)
                {
                    monthlist.Add(item);
                }
            }
            myListBox.ItemsSource = monthlist;
        }

        private void sortByYear()
        {
            var json = FileService.ReadFromFile(path, FileMode.OpenOrCreate);
            Todolist = SerializeService.DeserializeList(json);

            List<Task> yearlist = new();

            foreach (var item in Todolist)
            {
                if (item.Deadline.Year == DateTime.Today.Year)
                {
                    yearlist.Add(item);
                }
            }
            myListBox.ItemsSource = yearlist;
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            var addView = new AddWindow();
            addView.ShowDialog();
        }
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            List<Task> removalList = new();

            foreach (var item in Todolist)
            {
                if (item.isChecked != true)
                {
                    removalList.Add(item);
                }
            }
            Todolist = removalList;
            myListBox.ItemsSource = Todolist;

            var res = SerializeService.Serialize(Todolist);
            FileService.WriteToFile(res, path, FileMode.Truncate);
        }

        private void myCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;

            foreach (Task item in myListBox.Items)
            {
                if (cb.Content == item.Name && cb.IsChecked == true)
                {
                    item.isChecked = true;
                    break;
                }
            }
        }
        private void ButtonDay_Click(object sender, RoutedEventArgs e)
        {
            sortByDay();
            MainFrame.Content = new Page1();
        }
        private void ButtonWeek_Click(object sender, RoutedEventArgs e)
        {
            sortByWeek();
            MainFrame.Content = new Page2();
        }
        private void ButtonMonth_Click(object sender, RoutedEventArgs e)
        {
            sortByMonth();
            MainFrame.Content = new Page3();
        }
        private void ButtonYear_Click(object sender, RoutedEventArgs e)
        {
            sortByYear();
            MainFrame.Content = new Page4();
        }
    }
}
