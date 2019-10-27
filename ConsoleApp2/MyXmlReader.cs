using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;

namespace ConsoleApp2
{
    public class MyXmlReader
    {
        private readonly string _xmlSchemaUrl = "./XML/Data.xsd";
        private readonly string _targetNamespace = "http://creditinfo.com/schemas/Sample/Data";

        public async Task ReadXml(Stream stream)
        {
            XmlReaderSettings settings = new XmlReaderSettings();

            XmlSchemaSet sc = new XmlSchemaSet();
            sc.Add(this._targetNamespace, this._xmlSchemaUrl);
            settings.ValidationType = ValidationType.Schema;
            settings.Schemas = sc;
            settings.ValidationEventHandler += ValidationCallBack;
            settings.Async = true;
            using (XmlReader reader = XmlReader.Create(stream, settings))
            {
                while (await reader.ReadAsync())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            Console.WriteLine("Start Element {0}", reader.Name);
                            break;
                        case XmlNodeType.Text:
                            Console.WriteLine("Text Node: {0}",
                                     await reader.GetValueAsync());
                            break;
                        case XmlNodeType.EndElement:
                            Console.WriteLine("End Element {0}", reader.Name);
                            break;
                        default:
                            Console.WriteLine("Other node {0} with value {1}",
                                            reader.NodeType, reader.Value);
                            break;
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
