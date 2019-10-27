using System.Xml.Serialization;

namespace ConsoleApp2.MappingClasses
{
    public class SubjectRole
    {
        [XmlElement("CustomerCode")]
        public string CustomerCode { get; set; }

        [XmlElement("RoleOfCustomer")]
        public string RoleOfCustomer { get; set; }

        [XmlElement("GuaranteeAmount")]
        public Amount GuaranteeAmount { get; set; }
    }

}
