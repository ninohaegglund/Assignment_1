using Product_Catalogue.Menus;
using Product_Catalogue.Services;

class Program
{
    static void Main(string[] args)
    {
     
        ProductService productService = new ProductService();

       
        ProductMenu productMenu = new ProductMenu(productService);

      
        MainMenu mainMenu = new MainMenu(productService, productMenu);

        while (true)
        {
            mainMenu.MenuInterface();
        }
    }
}
