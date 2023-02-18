using MVP_project.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVP_project.View
{
    public partial class EditForm : Form
    {
        public Person Person { get; set; } = new();
        public EditForm()
        {
            InitializeComponent();
        }
        public EditForm(Person person)
        {
            InitializeComponent();

            nameTextBox.Text = person.Name;
            surnameTextBox.Text = person.Surname;
            ageTextBox.Text = person.Age.ToString();

            Person = person;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Person.Name = nameTextBox.Text;
            Person.Surname = surnameTextBox.Text;
            Person.Age = Convert.ToInt32(ageTextBox.Text);

            this.Close();
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
    }
}
