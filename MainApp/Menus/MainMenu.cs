using Product_Catalogue.Services;

namespace MainApp.Menus;

public class MainMenu

{
    public readonly ProductService _productService;
    private readonly ProductMenu _productMenu;
    internal MainMenu(ProductService productService, ProductMenu productMenu)
    {
        _productService = productService;
        _productMenu = productMenu;
    }
    internal void MenuInterface()
    {
        Console.Clear();
        Console.WriteLine($"Product Menu:\n");
        Console.WriteLine("1. Add product");
        Console.WriteLine("2. List products");
        Console.WriteLine("3. Remove product");
        Console.WriteLine("0. Exit");
        Console.Write($"\nPiease pick an option: ");

        var option = Console.ReadLine();

        switch (option)
        {
            case "1":
                _productMenu.AddProduct();
                break;
               
            case "2":
                Console.Clear();
                _productMenu.ListProducts();
                Console.ReadKey();
                break;

            case "0":
                Environment.Exit(0);
                break;

            default:
                return;
        }
    }
    
}


