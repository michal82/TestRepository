using System;
using System.IO;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string xmlString = File.ReadAllText("./XML/Sample.xml");
            var xmlCompressor = new XMLCompressor();
            var stream = xmlCompressor.GenerateStreamFromString(xmlString); //simulation input of binary XML
            var myXmlReader = new MyXmlReader();
            myXmlReader.ReadXml(stream).GetAwaiter().GetResult();   //async call called synchronously

            Console.ReadKey();
        }
    }
}
