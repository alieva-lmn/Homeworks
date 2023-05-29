using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public class Categories
    {
        public int ID { get; set; }
        public string? Name { get; set; }

        public Categories()
        {

        }

        public Categories(int id, string name)
        {
            this.ID = id;
            this.Name = name;
        }
    }
}
