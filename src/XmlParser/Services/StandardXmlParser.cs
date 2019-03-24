using System.IO;
using System.Xml.Serialization;
using XmlParser.Entities;
using XmlParser.Interfaces;

namespace XmlParser.Services
{
    public class StandardXmlParser<T> : IParser<T> where T : BaseXml
    {
        private readonly XmlSerializer serializer;

        public StandardXmlParser()
        {
            serializer = new XmlSerializer(typeof(T));
        }
        
        public T Parse(string xml) 
        {
            return (T)serializer.Deserialize(new StringReader(xml));
        }
    }
}
