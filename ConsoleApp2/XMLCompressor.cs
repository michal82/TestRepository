using System.IO;
namespace ConsoleApp2
{
    public class XMLCompressor
    {
        public Stream GenerateStreamFromString(string inputBinaryXml)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(inputBinaryXml);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}
