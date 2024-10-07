using Product_Catalogue.Services;
using Product_Catalogue.Models;
using Moq;
namespace Product_Catalogue.Tests;

public class ProductService_Tests
{
    [Fact]
    public void AddToList_ShouldAddProductToListAndContainCorrectNumberOfProducts()
    {
        //Arrange      
        var mockFileService = new Mock<FileService>(@"c:\projects\test_products.json");  //Mockar FileService
        var emptyProductList = new List<Product>();  // Startar en tom lista
        mockFileService.Setup(f => f.LoadFromFile()).Returns(emptyProductList);


        var productService = new ProductService(mockFileService.Object); 
        var product1 = new Product { Id = Guid.NewGuid(), Name = "Test Product 1", Price = 10M };
        var product2 = new Product { Id = Guid.NewGuid(), Name = "Test Product 2", Price = 10M };
        //Act
        productService.AddToList(product1);
        productService.AddToList(product2);
        //Assert
        var products = productService.GetProducts();

        //Kontrollerar så att rätt antal produkter finns i listan
        Assert.Equal(2, products.Count);
        //Kontrollerar så att en specifik produkt finns i listan
        Assert.Contains(product1, products);
        Assert.Contains(product2, products);
    }
}
