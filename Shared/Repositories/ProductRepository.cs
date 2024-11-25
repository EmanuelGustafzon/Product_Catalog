using Shared.Interfaces;
using Shared.Models;

namespace Shared.Repositories;
public class ProductRepository : IRepository<IProduct>
{
    List<IProduct> _products = [];
    IJsonService<IProduct> _jsonService;
    IFileService _fileService;

    public ProductRepository(IJsonService<IProduct> jsonService, IFileService fileService)
    {
        _jsonService = jsonService;
        _fileService = fileService;
    }
    public int Add(IProduct entity)
    {
        try
        {
            _products.Add(entity);
            return (int)StatusCodes.OK;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return (int)StatusCodes.InternalError;
        }
    }
    public IEnumerable<IProduct> Get() => _products;

    public IProduct? Get(string id)
    {
        IProduct? foundProduct = _products.FirstOrDefault(x => x.ID == id);
        return foundProduct ?? null;
    }
    public int Delete(string id)
    {
        try
        {
            IProduct? product = _products.FirstOrDefault(x => x.ID == id);
            if (product == null) return (int)StatusCodes.NotFound;
            _products.Remove(product);
            return (int)StatusCodes.OK;

        } catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return (int)StatusCodes.InternalError;
        }
    }
    public int Update(string id, IProduct entity)
    {
        try
        {
            IProduct? product = _products.FirstOrDefault(x => x.ID == id);

            if (product == null) return (int)StatusCodes.NotFound;

            product.Name = entity.Name;
            product.Price = entity.Price;
            product.Description = entity.Description;
            product.Category = entity.Category;
            product.Brand = entity.Brand;

            return (int)StatusCodes.OK;

        } catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return (int)StatusCodes.InternalError;
        }   
    }
    public int Save()
    {
        try
        {
            var json = _jsonService.Serialize(_products);
            _fileService.WriteFile(json, "test.json");
            return (int)StatusCodes.OK;
        } catch (Exception ex) { 
            Console.WriteLine(ex.ToString());
            return (int)StatusCodes.InternalError;
        }
        
    }
}
