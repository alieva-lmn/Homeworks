using EF_first_hw;
using System.Transactions;

using StoreContext context = new();
var products = context.Products.ToList();

void ReturnProducts(int count)
{
	if (count <= products.Count)
	{
		foreach (var item in products)
		{
			Console.WriteLine(item.ToString());
			count--;

			if (count == 0)
				break;
		}
	}
	return;
}

Console.Write("Enter number of products you want to see: ");
var count = Convert.ToInt32(Console.ReadLine());
ReturnProducts(count);

void SortProducts(int choice)
{
    if (choice == 1)
    {
        var sortedbyprice = products.OrderByDescending(x => x.Price);
        
        foreach (var item in sortedbyprice)
        {
            Console.WriteLine(item.ToString());
        }
    }
    else if (choice == 2)
    {
        var sortedbystock = products.OrderByDescending(x => x.Stock);

        foreach (var item in sortedbystock)
        {
            Console.WriteLine(item.ToString());
        }
    }
}

Console.Write("Select:\n\n1. Sort by price\n2. Sort by stock\n\n");
var choice = Convert.ToInt32(Console.ReadLine());
SortProducts(choice);


void AddProduct()
{
    var product = new Product();

    Console.Write("Name: ");
    product.Name = Console.ReadLine();
    Console.Write("Price: ");
    product.Price = Convert.ToDecimal(Console.ReadLine());
    Console.Write("Stock: ");
    product.Stock = Convert.ToInt32(Console.ReadLine());
    Console.Write("Image url: ");
    product.Image = Console.ReadLine();
    Console.Write("Category: ");
    product.CategoriesId = Convert.ToInt32(Console.ReadLine());

    products.Add(product);
    Console.WriteLine("Product is added");

    foreach (var item in products)
    {
        Console.WriteLine(item.ToString());
    }

    context.SaveChanges();
}

AddProduct();