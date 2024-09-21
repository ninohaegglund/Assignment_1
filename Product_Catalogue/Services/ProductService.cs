using Product_Catalogue.Models;

namespace Product_Catalogue.Services
{
    public class ProductService
        //Class that manages adding, removing and listing products. 
    {
        private List<Product> _products = []; //initializing list
        private readonly FileService _fileService;

        public ProductService()
        {
            _fileService = new FileService(); // Initialize the FileService
        }

        public void AddItemToList(Product product) 
        {
            _products.Add(product);
        }
 
        public List<Product> ListProducts()
        {
            return _products;
        }

        public bool SaveProducts()
        {
            if (_products.Count == 0) // Check if the product list is empty,
                                      // so it doesn't overwrite the text in the json file
            {
                return false; // Return false if no products to save
            }
            return _fileService.SaveToFile(_products);
        }

      
        public void LoadProducts()
        {
            _products = _fileService.LoadFromFile();
        }

    }
}
