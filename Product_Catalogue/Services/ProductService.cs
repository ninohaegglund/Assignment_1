using Product_Catalogue.Models;

namespace Product_Catalogue.Services
{
    public class ProductService
        
    {
        private List<Product> _products = []; //initializing list
        private readonly FileService _fileService;

        public ProductService()
        {
            _fileService = new FileService(); // Initialize the FileService
            LoadProducts();
        }

        public void AddItemToList(Product product) 
        {
            _products.Add(product);
            _fileService.SaveToFile(_products);
        }

 
        public List<Product> ListProducts() 
        {
            return _products;
        }

        public void LoadProducts()
        {
            _products = _fileService.LoadFromFile() ?? new List<Product>();
        }

    }
}
