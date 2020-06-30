using System.Collections.Generic;
using System.Text;
using System.IO;

using System.Xml.Serialization;
using System.Xml;

namespace ESGI.DesignPattern.Projet
{


    public class OrdersWriter
    {

        private List<Order> Orders;

        private XmlWriterSettings Settings;

        public OrdersWriter(List<Order> orders)
        {
            this.Orders = orders;
            this.Settings = new XmlWriterSettings();
            this.Settings.Indent = false;
            this.Settings.NewLineHandling = NewLineHandling.None;
            this.Settings.OmitXmlDeclaration = true;
        }

        public string Serialize()
        {
            var writer = new StringWriter();
            var xmlWriter = XmlWriter.Create(writer, this.Settings);
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");
            new XmlSerializer(typeof(List<Order>), new XmlRootAttribute("orders")).Serialize(xmlWriter, this.Orders, namespaces);
            return writer.ToString();
        }
    }
}
