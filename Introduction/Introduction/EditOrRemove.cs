using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Introduction
{
    public partial class EditOrRemove : Form
    {
        public Person Person { get; set; } = new();
        public EditOrRemove()
        {
            InitializeComponent();
        }

        public EditOrRemove(Person person)
        {
            InitializeComponent();
            Person = person;
        }
        private void EditOrRemove_Load(object sender, EventArgs e)
        {
            label1.Text = "Choose an option below";
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            EditForm editForm = new EditForm(Person);
            editForm.ShowDialog();
            Person = editForm.Person;
        }
        private void viewInfo_Click(object sender, EventArgs e)
        {
            InfoForm form = new(Person);
            form.ShowDialog();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
