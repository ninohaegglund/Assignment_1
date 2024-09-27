using Product_Catalogue.Models;

namespace Product_Catalogue.Services
{
    public class ProductService
        
    {
        private List<Product> _products = new List<Product>(); //initializing list
        private readonly FileService _fileService;

        public ProductService()
        {
            _fileService = new FileService(); // Initialize the FileService
            LoadProducts();
        }

        public void AddToList(Product product) 
        {
            _products.Add(product);
            _fileService.SaveToFile(_products);
        }

        public List<Product> GetProducts() 
        {
            return _products;
        }

        public void RemoveProduct(Product product)
        {
            _products.Remove(product);
            _fileService.SaveToFile(_products);
        }


        public void LoadProducts()
        {
            _products = _fileService.LoadFromFile() ?? new List<Product>();
        }

        public bool ProductExists(string productName)
        {
            return _products.Any(p => p.Name.Equals(productName, StringComparison.OrdinalIgnoreCase));
        }

    }
}
