using System.Xml.Serialization;

namespace ConsoleApp2.MappingClasses
{
    public class Amount
    {
        [XmlElement("Value")]
        public decimal Value { get; set; }

        [XmlElement("Currency")]
        public string Currency { get; set; }
    }
}
