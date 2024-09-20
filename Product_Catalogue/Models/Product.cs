
namespace Product_Catalogue.Models
{
    public class Product
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }

    }
}
