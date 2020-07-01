using System.Collections.Generic;
using System.Xml.Serialization;

namespace ESGI.DesignPattern.Projet
{
    [XmlType("product")]
    public class Product
    {
        [XmlAttribute("id")]
        public int ID { get; set; }

        [XmlAttribute("color")]
        public Color Color { get; set; }

        [XmlAttribute("size")]
        public ProductSize Size { get; set; }
        
        [XmlElement("price")]
        public Price Price { get; set; }        

        [XmlText]
        public string Name { get; set; }

        public Product() {}

        public Product(int id, string name, ProductSize size, Price price, Color color)
        {
            this.ID = id;
            this.Name = name;
            this.Size = size;
            this.Price = price;
            this.Color = color;
        }

        public bool ShouldSerializeSize() {
            return this.Size != ProductSize.NotApplicable;
        }

    }
}
