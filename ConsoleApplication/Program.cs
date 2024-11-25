using Shared.Factories;
using Shared.Interfaces;
using Shared.Repositories;
using Shared.Services;

var phone = ProductFactory.Create("phone", "cool phone", "tech", 299.98, "Samsung");
var apple = ProductFactory.Create("apple", "cool appple", "fruit", 2.98, "none");

IJsonService<IProduct> jsonService = new JsonService<IProduct>();
IFileService fileService = new FileService(@"C:\Users\Emanuel");
var repo = new ProductRepository(jsonService, fileService);

repo.Add(phone);
repo.Add(apple);
repo.Save();



