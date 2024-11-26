using Shared.Interfaces;
using Shared.Models;

namespace Shared.Repositories;
public class ProductRepository : BaseRepository<IProduct>
{
    public ProductRepository(IJsonService<IProduct> jsonService, IFileService fileService, string filePath) 
        : base (jsonService, fileService, filePath) { }

    public override IProduct? Get(string id)
    {
        IProduct? foundProduct = Entities.FirstOrDefault(x => x.ID == id);
        return foundProduct ?? null;
    }
    public override int Delete(string id)
    {
        try
        {
            IProduct? product = Entities.FirstOrDefault(x => x.ID == id);
            if (product == null) return (int)StatusCodes.NotFound;
            Entities.Remove(product);
            return (int)StatusCodes.OK;

        } catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return (int)StatusCodes.InternalError;
        }
    }
    public override int Update(string id, IProduct entity)
    {
        try
        {
            IProduct? product = Entities.FirstOrDefault(x => x.ID == id);

            if (product == null) return (int)StatusCodes.NotFound;

            product.Name = entity.Name;
            product.Price = entity.Price;
            product.Description = entity.Description;
            product.Category = entity.Category;

            return (int)StatusCodes.OK;

        } catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return (int)StatusCodes.InternalError;
        }   
    }
}
