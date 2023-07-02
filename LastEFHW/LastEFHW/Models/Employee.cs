using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastEFHW.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public int CompanyID { get; set; }
        public Company? Company { get; set; } = new();
    }
}
