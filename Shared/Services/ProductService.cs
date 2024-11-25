using Shared.Interfaces;

namespace Shared.Services;
public class ProductService : IProductService
{
    IRepository<IProduct> _ProductRepo;

    public ProductService(IRepository<IProduct> productRepo)
    {
        _ProductRepo = productRepo;
    }
    public void Add(IProduct product)
    {
        _ProductRepo.Add(product);
    }
    public IEnumerable<IProduct> GetAll()
    {
        return _ProductRepo.Get();
    }

    public IProduct GetByID(string id)
    {
        return _ProductRepo.Get(id);
    }
    public void Update(string id, IProduct product)
    {
        _ProductRepo.Update(id, product);
    }
    public void Delete(string id)
    {
        _ProductRepo.Delete(id);
    }
}
