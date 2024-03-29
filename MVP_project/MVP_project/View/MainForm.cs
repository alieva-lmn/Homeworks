﻿using MVP_project.Model;
using MVP_project.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVP_project.View
{
    public partial class MainForm : Form
    {
        public Person Person { get; set; } = new();
        List<Person> myList = new List<Person>();
        string path = "peopleList";
        public MainForm()
        {
            var json = FileService.ReadFromFile(path, FileMode.Open);

            if (json == "")
            {
                InitializeComponent();
            }
            else
            {
                InitializeComponent();
                myList = SerializeService.DeserializeList(json);

                foreach (var item in myList)
                {
                    peopleListBox.Items.Add(item);
                }
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            Regex re = new("^(?<firstchar>(?=[A-Za-z]))((?<alphachars>[A-Za-z])|(?<specialchars>[A-Za-z]['-](?=[A-Za-z]))|(?<spaces> (?=[A-Za-z])))*$");
            Regex re2 = new("^[1-9][0-9]*");

            if (re.IsMatch(nameTextBox.Text) && re.IsMatch(surnameTextBox.Text) && re2.IsMatch(ageTextBox.Text))
            {
                Person person = new Person();

                person.Name = nameTextBox.Text;
                person.Surname = surnameTextBox.Text;
                person.Age = Convert.ToInt32(ageTextBox.Text);
                person.ImagePath = Person.ImagePath;

                peopleListBox.Items.Add(person);

                nameTextBox.Text = "";
                surnameTextBox.Text = "";
                ageTextBox.Text = "";

                myList.Add(person);

                var res = SerializeService.Serialize(myList);
                FileService.WriteToFile(res, path, FileMode.Truncate);
            }
            else
            {
                MessageBox.Show("Enter valid info", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void imgButton_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Image Files|*.png;*.jpg;*.jpeg;*.jfif";

            var result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                Person.ImagePath = dialog.FileName;
            }
            imgLabel.Text = dialog.FileName;
        }

        private void peopleListBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (peopleListBox.Items.Count == 0)
            {
                throw new ArgumentNullException("List is empty");
            }
            else
            {
                int index = peopleListBox.SelectedIndex;
                OptionForm form = new OptionForm(peopleListBox.SelectedItem as Person);
                form.ShowDialog();
                peopleListBox.Items[index] = form.Person;
                var res = SerializeService.Serialize(myList);
                FileService.WriteToFile(res, path, FileMode.Truncate);
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            int index = peopleListBox.SelectedIndex;
            peopleListBox.Items.Remove(peopleListBox.SelectedItem);
            myList.RemoveAt(index);

            var res = SerializeService.Serialize(myList);
            FileService.WriteToFile(res, path, FileMode.Truncate);
        }
    }
}
