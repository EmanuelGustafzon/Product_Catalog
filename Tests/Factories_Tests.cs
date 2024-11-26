using Shared.Factories;
using Shared.Interfaces;

namespace Tests
{
    public class Factories_Tests
    {
        [Fact]
        public void ProductCreate_ShouldReturnProductInstance_ofTypeIProduct()
        {
            IProduct emptyProduct = ProductFactory.Create();
            IProduct populatedProduct = ProductFactory.Create("name", "desc", "category", 23.99);

            Assert.NotNull(emptyProduct);
            Assert.NotNull(populatedProduct);
            Assert.Equal("name", populatedProduct.Name);
            Assert.Equal("desc", populatedProduct.Description);
            Assert.Equal("category", populatedProduct.Category);
            Assert.Equal(23.99, populatedProduct.Price);
            Assert.IsAssignableFrom<IProduct>(emptyProduct);
            Assert.IsAssignableFrom<IProduct>(populatedProduct);
        }
    }
}
