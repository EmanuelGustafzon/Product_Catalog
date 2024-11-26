using Shared.Factories;
using Shared.Interfaces;
using Shared.Repositories;
using Shared.Services;

var phone = ProductFactory.Create("phone", "cool phone", "tech", 299.98);
var apple = ProductFactory.Create("apple", "cool appple", "fruit", 2.98);
var apple2 = ProductFactory.Create("apple", "cool appple", "fruit", 3.98);

IJsonService<IProduct> jsonService = new JsonService<IProduct>();
IFileService fileService = new FileService(@"C:\Users\Emanuel");
var repo = new ProductRepository(jsonService, fileService, "Products.json");
var r = repo.Add(phone);
repo.SaveChanges();
foreach(var prod in repo.Get())
{
    Console.WriteLine(prod.Price);
}



