using System.Xml.Serialization;

namespace ESGI.DesignPattern.Projet
{
    [XmlType("price")]
    public class Price {

        [XmlAttribute("currency")]
        public Currency Currency { get; set; }

        [XmlText]
        public double Value { get; set; }

        public Price() {}

        public Price(double value, Currency currency) {
            this.Currency = currency;
            this.Value = value;
        }
    }
}