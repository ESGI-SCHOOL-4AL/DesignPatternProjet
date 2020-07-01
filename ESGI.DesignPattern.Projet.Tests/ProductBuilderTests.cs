using Xunit;

namespace ESGI.DesignPattern.Projet.Tests {
    public class ProductBuilderTests {
        private const int TEST_ID = 134;
        private const string TEST_NAME = "Test Product";

        [Fact]
        public void DefaultBuildedProductValues()
        {
            ProductBuiler builderTest = new ProductBuiler(TEST_ID, TEST_NAME);
            Product expectedProduct = new Product(TEST_ID, TEST_NAME, ProductSize.Medium, new Price(0, Currency.USD), Color.RED);

            Product factoryOutput = builderTest.Build();
            Assert.Equal(expectedProduct.ID, factoryOutput.ID);
            Assert.Equal(expectedProduct.Name, factoryOutput.Name);
            Assert.Equal(expectedProduct.Size, factoryOutput.Size);
            Assert.Equal(expectedProduct.Price.Value, factoryOutput.Price.Value);
            Assert.Equal(expectedProduct.Price.Currency, factoryOutput.Price.Currency);
            Assert.Equal(expectedProduct.Color, factoryOutput.Color);


        }

        [Fact]
        public void ChangeProductData() {
            Price newPrice = new Price(20, Currency.USD);
            ProductSize newSize = ProductSize.ExtraLarge;

            ProductBuiler factoryTest = new ProductBuiler(TEST_ID, TEST_NAME);
            Product factoryOutput = factoryTest.WithPrice(newPrice).WithSize(newSize).Build();

            Assert.Equal(newPrice.Value, factoryOutput.Price.Value);
            Assert.Equal(newSize, factoryOutput.Size);
        }


    }
}