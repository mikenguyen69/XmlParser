using System;
using System.IO;
using System.Xml.Serialization;

namespace XmlParser.Tests
{
    public class StandardXmlParser<T> where T : BaseInput
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