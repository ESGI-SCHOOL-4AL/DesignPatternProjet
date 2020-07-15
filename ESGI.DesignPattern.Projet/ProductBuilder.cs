namespace ESGI.DesignPattern.Projet
{
    public class ProductBuilder: IBuilder<Product> {
        private Product product;

        public ProductBuilder(int id, string name) {
            product = new Product(id, name, ProductSize.Medium, new Price(0, Currency.USD), Color.RED);
        }

        public Product Build() {
            return product;
        }

        public ProductBuilder WithID(int id) {
            product.ID = id;
            return this;
        }

        public ProductBuilder WithName(string name) {
            product.Name = name;
            return this;
        }

        public ProductBuilder WithSize(ProductSize size) {
            product.Size = size;
            return this;
        }

        public ProductBuilder WithPrice(Price price) {
            product.Price = price;
            return this;
        }

        public ProductBuilder WithColor(Color color) {
            product.Color = color;
            return this;
        }
    }

}