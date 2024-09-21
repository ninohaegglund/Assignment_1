using Newtonsoft.Json;
using Product_Catalogue.Models;

namespace Product_Catalogue.Services
{
    public class FileService
    {
        private readonly string _filePath = (@"c:\projects\products.json"); // Path to save the products

        // Method to save products to file
        public bool SaveToFile(List<Product> products)
        {
            try
            {
                var json = JsonConvert.SerializeObject(products, Formatting.Indented); // Convert product list to JSON
                File.WriteAllText(_filePath, json); // Save JSON to file
                return true; // Indicate success
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving file: {ex.Message}");
                return false;
            }
        }

        // Method to load products from file
        public List<Product> LoadFromFile()
        {
            try
            {
                if (!File.Exists(_filePath))
                {
                    return new List<Product>(); // Return empty list if file doesn't exist
                }

                var json = File.ReadAllText(_filePath); // Read JSON from file
                return JsonConvert.DeserializeObject<List<Product>>(json) ?? new List<Product>(); // Deserialize JSON to product list
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading file: {ex.Message}");
                return new List<Product>(); // Return empty list on failure
            }
        }
    }
}
