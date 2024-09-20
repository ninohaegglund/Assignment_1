using Product_Catalogue.Models;

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
            _products.Remove(product);
        }
        public List<Product> ListProducts()
        {
            return _products;
        }

    }
}
