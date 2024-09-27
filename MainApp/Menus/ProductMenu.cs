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
                Console.Write("Product added succesfully, press any key to continue...");
            }
        }
        else
        {
            Console.WriteLine("Invalid input");
        }
    }
    public void DisplayProducts()
    
    {
        Console.Clear();

        var products = _productService!.GetProducts();

            if (products.Count == 0)
            {
                Console.WriteLine("No products available.");
                return;
          
            }

            Console.WriteLine($"Product List:\n");
            foreach (var product in products)
            {
           
            Console.WriteLine($"|| ID: {product.Id} || Name: {product.Name} || Price: {product.Price:C} ||");
        }

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
            return;
        }
       
        var productToRemove = _productService!.GetProducts().FirstOrDefault(p => p.Id == guid);

        if (productToRemove != null)
        {
            _productService.RemoveProduct(productToRemove);
            Console.WriteLine("Product removed successfully");
        }
        else
        {
            Console.WriteLine("Product not found");
        } 
    }
}






