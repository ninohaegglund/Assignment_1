using Product_Catalogue.Menus;
using Product_Catalogue.Services;

class Program
{
    static void Main(string[] args)
    {

        ProductService productService = new();


        ProductMenu productMenu = new(productService);


        MainMenu mainMenu = new(productService, productMenu);

        while (true)
        {
            mainMenu.MenuInterface();
        }
    }
}
