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
        Console.WriteLine("1. Add product ");
        Console.WriteLine("2. List products");
        Console.WriteLine("3. Save products to file");
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
                _productMenu.ListProducts();
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
   
}


