using Product_Catalogue.Models;
using Product_Catalogue.Services;

namespace MainApp.Menus;

internal class ProductMenu
   
{
    private readonly ProductService? _productService;
   
    public ProductMenu(ProductService productService)
    {
        _productService = productService;
    }
    public void AddProduct()
      {
        Console.Clear();
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
            if (_productService!.ProductExists(product.Name))
            {
                Console.WriteLine("Product with the same name already exists.");
            }
            else
            {
                _productService!.AddToList(product);
                Console.Write("Product added succesfully :), press any key to continue: ");
            }
        }
        else
        {
            Console.WriteLine("Invalid input");
        }
        Console.ReadKey();
    }
    public void DisplayProducts()
    
    {
        Console.Clear();

        var products = _productService!.GetProducts();

        if (products.Count == 0)
        {
            Console.WriteLine("No products available");
            Console.ReadKey();
            return;
        }       

        Console.WriteLine($"Product List:");

        foreach (var product in products)
        {       
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n|| Id: {product.Id} || Name: {product.Name}|| Price: {product.Price:C}");
            Console.ResetColor();        

        }

        // Reset to the default console color
        Console.ResetColor();

        Console.Write($"\nPress any key to close the list: ");
        Console.ReadKey();

    }
    public void RemoveProductByGuid()
    {
        Console.Clear();
        Console.WriteLine("Remove Product:\n");
        Console.Write("Enter the GUID of the designated product: ");
        var Id = Console.ReadLine();

      
        if (!Guid.TryParse(Id, out Guid guid))
        {
            Console.WriteLine("Invalid GUID format");
            Console.ReadKey();
            return;
        }
       
        var productToRemove = _productService!.GetProducts().FirstOrDefault(p => p.Id == guid);

        if (productToRemove != null)
        {
            _productService.RemoveProduct(productToRemove);
            Console.Write($"\nProduct removed successfully");
        }
        else
        {
            Console.WriteLine("Product not found");
        }

        Console.ReadKey();
    }
}






