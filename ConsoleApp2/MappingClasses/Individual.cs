using System;
using System.Xml.Serialization;

namespace ConsoleApp2.MappingClasses
{
    public class Individual
    {
        [XmlElement("CustomerCode")]
        public string CustomerCode { get; set; }

        [XmlElement("FirstName")]
        public string FirstName { get; set; }

        [XmlElement("LastName")]
        public string LastName { get; set; }

        [XmlElement("Gender")]
        public string Gender { get; set; }

        [XmlElement("DateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        [XmlElement("IdentificationNumbers")]
        public IdentificationNumbers IdentificationNumbers { get; set; }
    }
}
