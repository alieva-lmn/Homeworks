using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public class Products
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string? Image { get; set; }
        public int CategoriesID { get; set; }

        public Products()
        {

        }

        public Products(int id, string name, decimal price, int stock, string image, int catID)
        {
            this.ID = id;
            this.Name = name;
            this.Price = price;
            this.Stock = stock;
            this.Image = image;
            this.CategoriesID = catID;
        }
    }
}
