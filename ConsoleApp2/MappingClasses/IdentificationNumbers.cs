using System.Xml.Serialization;

namespace ConsoleApp2.MappingClasses
{
    public class IdentificationNumbers
    {
        [XmlElement("NationalID")]
        public string NationalId { get; set; }
    }
}
