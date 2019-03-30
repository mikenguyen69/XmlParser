using XmlParser.Entities;

namespace Expense.Core.Entities
{
    public class SystemValue : BaseEntity
    {
        public string Key { get; set; }
        public object Value { get; set; }

        public SystemValue(string key, object value)
        {
            Key = key;
            Value = value;
        }
    }
}
