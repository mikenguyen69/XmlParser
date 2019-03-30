using XmlParser.Entities;

namespace XmlParser.Interfaces
{
    public interface IParser<T> where T : BaseEntity
    {
        T Parse(string xml);
        T ParseText(string text);
    }
}
