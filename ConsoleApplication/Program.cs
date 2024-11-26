using Shared.Factories;
using Shared.Interfaces;
using Shared.Models;
using Shared.Repositories;
using Shared.Services;

var phone = ProductFactory.Create("phone", "load headphones", "tech", 299.98);
var pear = ProductFactory.Create("pear", "Tasty freah pear", "fruit", 2.98);
var orange = ProductFactory.Create("orange", "Very refreshing orange", "fruit", 3.98);

IJsonService<IProduct> jsonService = new JsonService<IProduct>();
IFileService fileService = new FileService(@"C:\Users\Emanuel");
var repo = new ProductRepository(jsonService, fileService, "Products.json");

IProductService service = new ProductService(repo);

service.Add(pear);
service.Add(orange);
service.Add(phone);

FindSimilarProductsService findSimilarProductsService = new FindSimilarProductsService(service);
List<string>? ids = findSimilarProductsService.GetSimilarProducts(1, orange);

foreach (var id in ids)
{
    var sim = service.GetByID(id);
    Console.WriteLine(sim?.Name);
}

