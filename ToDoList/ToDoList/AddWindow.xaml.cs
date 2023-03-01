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
using System.Windows.Shapes;


namespace ToDoList
{
    public partial class AddWindow : Window
    {
        public List<Task> Todolist { get; set; } = new();
        string path = "myList";

        public AddWindow()
        {
            InitializeComponent();
        }
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            var json = FileService.ReadFromFile(path, FileMode.OpenOrCreate);

            if (!String.IsNullOrEmpty(json))
            {
                Todolist = SerializeService.DeserializeList(json);
                
            }

            Task newTask = new();
            string date = dateTextbox.Text;

            newTask.Name = nameTextBox.Text;
            newTask.Description = descriptionTextBox.Text;
            newTask.Deadline = Convert.ToDateTime(date);

            Todolist.Add(newTask);

            var res = SerializeService.Serialize(Todolist);
            FileService.WriteToFile(res, path, FileMode.Truncate);
            this.Close();
        }
    }
}
