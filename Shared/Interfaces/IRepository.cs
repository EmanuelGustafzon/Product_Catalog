namespace Shared.Interfaces;

public interface IRepository<TEntity> where TEntity : class
{
    public void Add(TEntity entity);
    public IEnumerable<TEntity> Get();

    public void Delete(string id);
    public void Update(string id, TEntity entity);
}
