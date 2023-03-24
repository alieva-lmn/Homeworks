using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceAdminPanel.Model
{
    public class Book
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string Category { get; set; }
        public string Genre { get; set; }
        public uint Year { get; set; }
        public double Price { get; set; }
    }
}
