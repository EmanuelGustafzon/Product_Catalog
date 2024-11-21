using Shared.Interfaces;
using Shared.Models;

namespace Shared.Factories;
public static class ProductFactory
{
    public static IProduct Create()
    {
        return new Product();
    }
    public static IProduct Create(string name, string description, string category, double price, string brand)
    {
        return new Product
        {
            Name = name,
            Description = description,
            Category = category,
            Price = price,
            Brand = brand
        };
    }
}
