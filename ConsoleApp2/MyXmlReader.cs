using ConsoleApp2.MappingClasses;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ConsoleApp2
{
    public class MyXmlReader
    {
        private readonly string _xmlSchemaUrl = "./XML/Data.xsd";
        private readonly string _targetNamespace = "http://creditinfo.com/schemas/Sample/Data";

        public async Task ReadXml(Stream stream)
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            XmlSerializer serializer = new XmlSerializer(typeof(Contract), "http://creditinfo.com/schemas/Sample/Data");

            XmlSchemaSet sc = new XmlSchemaSet();
            sc.Add(this._targetNamespace, this._xmlSchemaUrl);
            settings.ValidationType = ValidationType.Schema;
            settings.Schemas = sc;
            settings.ValidationEventHandler += ValidationCallBack;
            settings.Async = true;
            XmlDocument doc = new XmlDocument();
            using (XmlReader reader = XmlReader.Create(stream, settings))
            {
                while (await reader.ReadAsync())
                {
                    if (reader.Name == "Contract")
                    {
                        var t = serializer.Deserialize(reader);
                        int i = 1;
                    
                    }
                }
            }
        }

        private void ValidationCallBack(object sender, ValidationEventArgs e)
        {
            Console.WriteLine($"Validation Error:\n   {e.Message}\n");
            throw new XmlSchemaValidationException(e.Message);
        }
    }
}
