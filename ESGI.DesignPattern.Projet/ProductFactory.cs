namespace ESGI.DesignPattern.Projet
{
    public class ProductFactory: IFactory<Product> {
        private Product product;

        public ProductFactory(int id, string name) {
            product = new Product(id, name, ProductSize.Medium, new Price(0, Currency.USD), Color.RED);
        }

        public Product Build() {
            return product;
        }

        public ProductFactory WithID(int id) {
            product.ID = id;
            return this;
        }

        public ProductFactory WithName(string name) {
            product.Name = name;
            return this;
        }

        public ProductFactory WithSize(ProductSize size) {
            product.Size = size;
            return this;
        }

        public ProductFactory WithPrice(Price price) {
            product.Price = price;
            return this;
        }

        public ProductFactory WithColor(Color color) {
            product.Color = color;
            return this;
        }
    }

}