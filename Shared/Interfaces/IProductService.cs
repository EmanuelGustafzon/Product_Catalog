namespace Shared.Interfaces;

public interface IProductService
{
    public void Add(IProduct product);
    public IEnumerable<IProduct> GetAll();

    public IProduct GetByID(string id);
    public void Update(string id, IProduct product);

    public void Delete(string id);
}
