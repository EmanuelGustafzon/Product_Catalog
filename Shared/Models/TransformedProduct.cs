namespace Shared.Models;

// This is for ML.Net in the FindSimilarProductsService
public class TransformedProduct
{
    public string ID { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Category { get; set; } = null!;
    public double Price { get; set; }
    public float[] Features { get; set; } = null!;
}
