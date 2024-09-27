using Newtonsoft.Json;
using Product_Catalogue.Models;

namespace Product_Catalogue.Services
{
    public class FileService
    {
        private readonly string _filePath = (@"c:\projects\products.json");

        public bool SaveToFile(List<Product> products)
        {
            try
            {
                var json = JsonConvert.SerializeObject(products, Formatting.Indented); 
                File.WriteAllText(_filePath, json); 
                return true; 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving file: {ex.Message}");
                return false;
            }
        }

       
        public List<Product> LoadFromFile()
        {
            try
            {
                if (!File.Exists(_filePath))
                {
                    return new List<Product>(); 
                }

                var json = File.ReadAllText(_filePath); 
                return JsonConvert.DeserializeObject<List<Product>>(json) ?? new List<Product>(); 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading file: {ex.Message}");
                return new List<Product>(); 
            }
        }
    }
}
