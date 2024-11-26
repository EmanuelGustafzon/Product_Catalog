using Shared.Interfaces;

namespace Shared.Services;
public class ProductService : IProductService
{
    IRepository<IProduct> _ProductRepository;

    public ProductService(IRepository<IProduct> productRepo)
    {
        _ProductRepository = productRepo;
    }
    public IEnumerable<IProduct> GetAll()
    {
        return _ProductRepository.Get();
    }
    public void Add(IProduct product)
    {
        foreach(var item in GetAll())
        {
            if (item.Name == product.Name) return;
        }
        _ProductRepository.Add(product);
    }
    public IProduct? GetByID(string id)
    {
        var foundProduct = _ProductRepository.Get(id);
        return foundProduct ?? null;
    }
    public void Update(string id, IProduct product)
    {
        _ProductRepository.Update(id, product);
    }
    public void Delete(string id)
    {
        _ProductRepository.Delete(id);
    }
}
