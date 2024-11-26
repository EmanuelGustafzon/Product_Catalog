using Microsoft.ML;
using Shared.Interfaces;
using Shared.Models;
using System.Numerics.Tensors;
using System.Data;

namespace Shared.Services;
public class FindSimilarProductsService
{
    MLContext mlContext = new();
    IProductService _productService;
    IEnumerable<TransformedProduct> TransformedProducts { get; set; } = [];
    public FindSimilarProductsService(IProductService productService)
    {
        _productService = productService;
        TransformProductList();
    }
    public void TransformProductList()
    {
        var productsDataview = mlContext.Data.LoadFromEnumerable(_productService.GetAll());
        var productDescriptionPipeline = mlContext.Transforms.Text.FeaturizeText("Features", "Description");
        var productTransformer = productDescriptionPipeline.Fit(productsDataview);
        var transformedProductsDataview = productTransformer.Transform(productsDataview);
        TransformedProducts = mlContext.Data.CreateEnumerable<TransformedProduct>(transformedProductsDataview, reuseRowObject: false);
    }
    public List<string>? GetSimilarProducts(int numberOfsimilarPrducts, IProduct product)
    {
        if(numberOfsimilarPrducts > TransformedProducts.Count()) return null;
        string productID = product.ID;
        var foundProductInTransformedList = TransformedProducts.FirstOrDefault(x => x.ID == productID);
        if (foundProductInTransformedList == null) return null;
        float[]? productFeatures = foundProductInTransformedList.Features;

        var similarProducts = TransformedProducts
            .OrderByDescending(x => TensorPrimitives.CosineSimilarity(x.Features, productFeatures))
            .Where(x => x.ID != productID)
            .Select(x => x.ID)
            .Take(numberOfsimilarPrducts)
            .ToList();

        return similarProducts;
    }
}
