using XmlParser.Entities;

namespace XmlParser.Interfaces
{
    public interface IParser<T> where T : BaseXml
    {
        T Parse(string xml);
    }
}
