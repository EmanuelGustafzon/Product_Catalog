using Shared.Factories;
using Shared.Interfaces;
using Shared.Repositories;
using Shared.Services;

namespace Tests;
public class ProductRepository_Tests
{
    IJsonService<IProduct> jsonService = new JsonService<IProduct>();
    IFileService fileService = new FileService(@"C:\Users\Emanuel");
    ProductRepository repository = new(fileService, jsonService);
    [Fact]
    public void Add_ShouldAddProduct()
    {
        IProduct Product = ProductFactory.Create("name", "desc", "content", 23.99, "brand");
        repository.Add(Product);

        IEnumerable<IProduct> products = repository.Get();
        Assert.Single(products);
    }
}
