using Shared.Interfaces;

namespace Shared.Repositories;
public class ProductRepository : IRepository<IProduct>
{
    List<IProduct> _products = [];
    public void Add(IProduct entity) => _products.Add(entity);
    public IEnumerable<IProduct> Get() => _products;
    public void Delete(string id)
    {
        IProduct product = _products.FirstOrDefault(x => x.ID == id);
        if (product != null) 
            _products.Remove(product);
    }
    public void Update(string id, IProduct entity)
    {
        IProduct product = _products.FirstOrDefault(x => x.ID == id);
        if (product != null)
            product = entity;
    }
}
