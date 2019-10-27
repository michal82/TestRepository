using System;
using System.Xml.Serialization;

namespace ConsoleApp2.MappingClasses
{
    public class ContractData
    {
        [XmlElement("PhaseOfContract")]
        public string PhaseOfContract { get; set; }

        [XmlElement("OriginalAmount")]
        public Amount OriginalAmount { get; set; }

        [XmlElement("InstallmentAmount")]
        public Amount InstallmentAmount { get; set; }

        [XmlElement("CurrentBalance")]
        public Amount CurrentBalance { get; set; }

        [XmlElement("OverdueBalance")]
        public Amount OverdueBalance { get; set; }

        [XmlElement("DateOfLastPayment")]
        public DateTime DateOfLastPayment { get; set; }

        [XmlElement("NextPaymentDate")]
        public DateTime NextPaymentDate { get; set; }

        [XmlElement("DateAccountOpened")]
        public DateTime DateAccountOpened { get; set; }

        [XmlElement("RealEndDate")]
        public DateTime RealEndDate { get; set; }
    }
}
