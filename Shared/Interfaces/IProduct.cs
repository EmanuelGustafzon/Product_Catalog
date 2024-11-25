using Shared.Models;
using System.Text.Json.Serialization;

namespace Shared.Interfaces;

[JsonDerivedType(typeof(Product), nameof(Product))]
public interface IProduct
{
    public string ID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public double Price { get; set; }
    public string Brand { get; set; }
}
