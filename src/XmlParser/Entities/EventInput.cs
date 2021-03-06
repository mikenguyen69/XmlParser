﻿using System.Xml.Serialization;

namespace XmlParser.Entities
{
    [XmlRoot()]
    public class EventInput : BaseEntity
    {
        public EventInput()
        {
        }

        public Event[] Events { get; set; }
        public int GroupId { get; set; }
        public string GroupName { get; set; }
    }
}
