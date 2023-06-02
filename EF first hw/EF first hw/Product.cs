using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EF_first_hw;

public partial class Product
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public int Stock { get; set; }

    public string Image { get; set; } = null!;

    public int CategoriesId { get; set; }

    public virtual Category Categories { get; set; } = null!;

    public override string ToString()
    {
        return $"ID: {Id}\nName: {Name}\nPrice: {Price}\nStock: {Stock}\nCategory: {Categories}\n"; 
    }
}
