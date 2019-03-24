using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XmlParser.Tests
{
    [XmlRoot()]
    public class EventInput : BaseInput
    {
        public EventInput()
        {
        }

        public Event[] Events { get; set; }
        public int GroupId { get; set; }
        public string GroupName { get; set; }
    }
}
