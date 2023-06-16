using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EF_Project.Models
{
    public class Country
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public int GovernmentFormID { get; set; }
        public GovernmentForms? GovernmentForms { get; set; }
        public string Url { get; set; }
        public float Population { get; set; }
        public double Area { get; set; }
        public double GDP { get; set; }
        public string HeadOfState { get; set; }
        public string Anthem { get; set; }
    }
}
