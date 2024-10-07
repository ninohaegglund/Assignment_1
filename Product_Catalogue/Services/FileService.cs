using Newtonsoft.Json;
using Product_Catalogue.Models;

namespace Product_Catalogue.Services
{
    public class FileService
    {
        private readonly string _filePath;

       
        public FileService(string filePath)
        {
            _filePath = filePath;
        }

       
        public virtual bool SaveToFile(List<Product> products)
        {
            try
            {
                var json = JsonConvert.SerializeObject(products, Formatting.Indented);
                File.WriteAllText(_filePath, json);
                return true;
            }
            catch 
            {
                
                return false;
            }
        }

     
        public virtual List<Product> LoadFromFile()
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
            catch 
            {
                
                return new List<Product>();
            }
        }
    }
}
