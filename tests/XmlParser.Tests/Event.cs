using System.Xml.Serialization;

namespace XmlParser.Tests
{
    public class Event
    {
        [XmlAttribute]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}