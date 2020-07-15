namespace ESGI.DesignPattern.Projet
{
    public class ProductBuiler: IBuilder<Product> {
        private Product product;

        public ProductBuiler(int id, string name) {
            product = new Product(id, name, ProductSize.Medium, new Price(0, Currency.USD), Color.RED);
        }

        public Product Build() {
            return product;
        }

        public ProductBuiler WithID(int id) {
            product.ID = id;
            return this;
        }

        public ProductBuiler WithName(string name) {
            product.Name = name;
            return this;
        }

        public ProductBuiler WithSize(ProductSize size) {
            product.Size = size;
            return this;
        }

        public ProductBuiler WithPrice(Price price) {
            product.Price = price;
            return this;
        }

        public ProductBuiler WithColor(Color color) {
            product.Color = color;
            return this;
        }
    }

}