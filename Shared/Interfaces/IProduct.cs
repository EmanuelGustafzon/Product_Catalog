namespace Shared.Interfaces;

public interface IProduct
{
    public string ID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public double Price { get; set; }
    public string Brand { get; set; }
}
