using Product_Catalogue.Models;
using Product_Catalogue.Services;
using System.ComponentModel.Design;

namespace Product_Catalogue.Menus;

public class ProductMenu
    //Class that manages the product menu
{
    private readonly ProductService? _productService;
   
    public ProductMenu(ProductService productService)
    {
        _productService = productService;
    }
      public  void AddProduct()
      {
        Console.Write("Add Product: ");
        var name = Console.ReadLine();

        Console.Write("Enter price: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal price))
        {

            var product = new Product

            {
                Name = name!,
                Price = price
            };

            _productService?.AddItemToList(product);

            Console.Write("Product added succesfully, press any key to continue:  ");
        }
        else
        {
            Console.WriteLine("Invalid input");
        }



        }
    public void ListProducts()
    {
        var products = _productService!.ListProducts();

        if (products.Count == 0)
        {
            Console.WriteLine("No products available.");
            return;
        }

        Console.WriteLine("Product List:");
        foreach (var product in products)
        {
            Console.WriteLine($"|| ID: {product.Id} || Name: {product.Name} || Price: {product.Price:C} ||");
        }
    }
}

   
  



