using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Project.Models
{
    public class GovernmentForms
    {
        public int ID { get; set; }
        public string Form { get; set; }
    }
}
