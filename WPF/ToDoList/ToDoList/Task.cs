using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace ToDoList
{
    public class Task
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime Deadline { get; set; }
        public bool isChecked { get; set; }
    }
}
