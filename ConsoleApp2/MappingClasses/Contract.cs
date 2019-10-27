using System.Xml.Serialization;

namespace ConsoleApp2.MappingClasses
{
    [XmlRoot("Contract", Namespace = "http://creditinfo.com/schemas/Sample/Data")]
    public class Contract: IMustBeValidated
    {
        [XmlElement("ContractCode")]
        public string ContractCode { get; set; }

        [XmlElement("ContractData")]
        public ContractData ContractData { get; set; }

        [XmlElement("Individual")]
        public Individual[] Individual { get; set; }

        [XmlElement("SubjectRole")]
        public SubjectRole[] SubjectRole { get; set; }
    }
}
