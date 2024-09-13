using Product_Catalogue.Services;
using Product_Catalogue.Models;
using System.Security.Cryptography.X509Certificates;
using Product_Catalogue.Menus;

namespace Product_Catalogue.Menus;


public class MainMenu

{
    public readonly ProductService _productService;
    private readonly ProductMenu _productMenu;
    public MainMenu(ProductService productService, ProductMenu productMenu)
    {
        _productService = productService;
        _productMenu = productMenu;
    }

    public void MenuInterface()
    {

        Console.Clear();
        Console.WriteLine("1. Add Product ");
        Console.WriteLine("2. List Products");
        Console.WriteLine("3. Save product to file");
        Console.WriteLine("4. Load products");
        Console.WriteLine("0. Exit");

        var option = Console.ReadLine();

        switch (option)
        {
            case "1":
                Console.Clear();
                _productMenu.AddProduct();
                Console.ReadKey();
                break;

            case "2":
                Console.Clear();
                ListProducts();
                Console.Write("Press any key to continue...");
                Console.ReadKey();
                break;

            case "3":
                break;

            case "4":
                break;

            case "0":
                Console.WriteLine("Goodbye!");
                Environment.Exit(0);
                break;

            default:
                return;

        }

    }
   public void ListProducts()
    {
        var products = _productService.ListProducts();

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


