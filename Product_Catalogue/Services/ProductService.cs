using Product_Catalogue.Menus;
using Product_Catalogue.Models;
using System.Threading.Channels;

namespace Product_Catalogue.Services
{
    public class ProductService
        //Class that manages adding, removing and listing products. 
    {
        private List<Product> _products = []; //initializing list
        public void AddItemToList(Product product) 
        {
            _products.Add(product);
        }
        public void RemoveItem(Product product) // Work in progress
        {

        }
        public List<Product> ListProducts()
        {
            return _products;
        }


        

            
    }
}
