using System.Collections.Generic;
using System.Xml.Serialization;

namespace ESGI.DesignPattern.Projet
{
    [XmlType("order")]
    public class Order
    {
        [XmlAttribute("id")]
        public int ID { get; set; }

        [XmlElement("product")]
        public List<Product> Products { get; set; }

        public Order() {}

        public Order(int id)
        {
            this.Products = new List<Product>();
            this.ID = id;
        }
    }
}
