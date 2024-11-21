using Shared.Interfaces;

namespace Shared.Services;
public class ProductService
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
}
