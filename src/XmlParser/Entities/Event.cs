using System.Xml.Serialization;

namespace XmlParser.Entities
{
    public class Event
    {
        [XmlAttribute]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
