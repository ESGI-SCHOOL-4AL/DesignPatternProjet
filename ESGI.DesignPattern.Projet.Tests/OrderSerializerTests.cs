using System;
using Xunit;
using System.Collections.Generic;

namespace ESGI.DesignPattern.Projet.Tests
{
    public class OrderSerializerTests
    {
        [Fact]
        public void Serialize_produces_all_orders()
        {
            var orders = new List<Order>();
            var order = new Order(1234);
            //ProductSize.Medium, new Price(21, Currency.USD), Color.RED
            order.Products.Add(new ProductBuilder(4321, "T-Shirt")
                .WithSize(ProductSize.Medium)
                .WithPrice(new Price(21, Currency.USD))
                .WithColor(Color.RED)
                .Build()
            );

            order.Products.Add(new ProductBuilder(6789, "Socks")
                .WithSize(ProductSize.Medium)
                .WithPrice(new Price(8, Currency.USD))
                .WithColor(Color.RED)
                .Build()
            );

            orders.Add(order);

            var ordersWriter = new OrdersSerializer(orders);
            var expectedOrder =
                "<orders>" +
                    "<order id=\"1234\">" +
                        "<product id=\"4321\" color=\"RED\" size=\"Medium\">" +
                            "<price currency=\"USD\">" +
                            "21" +
                            "</price>" +
                        "T-Shirt" +
                        "</product>" +
                        "<product id=\"6789\" color=\"RED\" size=\"Medium\">" +
                            "<price currency=\"USD\">" +
                            "8" +
                            "</price>" +
                        "Socks" +
                        "</product>" +
                    "</order>" +
                "</orders>";

            var result = ordersWriter.Serialize();
            Assert.Equal(expectedOrder, result);
        }

        [Fact]
        public void Serialize_produces_no_orders()
        {
            var orders = new List<Order>();
            var ordersWriter = new OrdersSerializer(orders);

            var expectedOrder = "<orders />";

            Assert.Equal(expectedOrder, ordersWriter.Serialize());
        }

        [Fact]
        public void Serialize_not_applicable_size_produces_no_size_attribute()
        {
            var orders = new List<Order>();
            var order = new Order(1234);
            order.Products.Add(new ProductBuilder(4321, "T-Shirt")
                .WithSize(ProductSize.NotApplicable)
                .WithPrice(new Price(21, Currency.USD))
                .WithColor(Color.RED)
                .Build()
            );
            orders.Add(order);

            var ordersWriter = new OrdersSerializer(orders);

            var expectedOrder =
                "<orders>" +
                    "<order id=\"1234\">" +
                        "<product id=\"4321\" color=\"RED\">" +
                            "<price currency=\"USD\">" +
                            "21" +
                            "</price>" +
                        "T-Shirt" +
                        "</product>" +
                    "</order>" +
                "</orders>";

            Assert.Equal(expectedOrder, ordersWriter.Serialize());
        }
    }
}

