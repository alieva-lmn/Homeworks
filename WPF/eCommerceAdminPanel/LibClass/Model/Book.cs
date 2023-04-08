using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LibClass.Model
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public string Publisher { get; set; }
        public string ImagePath { get; set; }
        public double Price { get; set; }
        public uint Year { get; set; }
        public Guid Id { get; set; }
    }
}
