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
            IProduct populatedProduct = ProductFactory.Create("name", "desc", "content", 23.99, "brand");

            Assert.NotNull(emptyProduct);
            Assert.NotNull(populatedProduct);
            Assert.Equal("name", populatedProduct.Name);
            Assert.IsAssignableFrom<IProduct>(emptyProduct);
            Assert.IsAssignableFrom<IProduct>(populatedProduct);
        }
    }
}
