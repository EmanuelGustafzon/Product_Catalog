using Shared.Interfaces;

namespace Shared.Models;
internal class Product : IProduct
{
    public string ID { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public string Category { get; set; } = "";
    public double Price { get; set; }
    public string Brand { get; set; } = "";
}
