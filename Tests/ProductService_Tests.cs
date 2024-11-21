using Shared.Factories;
using Shared.Interfaces;
using Shared.Repositories;
using Shared.Services;
namespace Tests;

public class ProductService_Tests
{
    [Fact]
    public void Add_ShouldAddProductToList()
    {
        IRepository<IProduct> repo = new ProductRepository();
        ProductService service = new ProductService(repo);

        IProduct product = ProductFactory.Create();
        service.Add(product);
        var productList = service.GetAll();

        Assert.Contains(product, productList);
    }
}
