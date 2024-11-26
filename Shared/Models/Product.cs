using Shared.Interfaces;

namespace Shared.Models;
internal class Product : IProduct
{
    public string ID { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Category { get; set; } = null!;
    public double Price { get; set; }
}
