using System;
using System.IO;
using System.Xml.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace XmlParser.Tests
{
    [TestClass]
    public class StandardXmlParserShould
    {
        private readonly StandardXmlParser<EventInput> parser;
        private readonly string xml;

        public StandardXmlParserShould()
        {
            parser = new StandardXmlParser<EventInput>();
            xml = @"  
                <EventInput> 
                    <GroupId>12345</GroupId>
                    <GroupName>ABC</GroupName>    
                    <Events> 
                        <Event Id=""100""><Name>Start</Name></Event> 
                        <Event Id=""101""><Name>Add</Name></Event> 
                        <Event Id=""102""><Name>Change</Name></Event> 
                        <Event Id=""103""><Name>Alert</Name></Event> 
                        <Event Id=""104""><Name>End</Name></Event> 
                        </Events> 
                </EventInput>";
        }

        [TestMethod]
        public void UseSerializerToParseXml_Root()
        {
            var input = parser.Parse(xml);

            Assert.AreEqual(12345, input.GroupId);
            Assert.AreEqual("ABC", input.GroupName);
            Assert.AreEqual(5, input.Events.Length);

            
        }

        [DataRow(100, "Start")]
        [DataRow(101,"Add")]
        [DataRow(102,"Change")]
        [DataRow(103,"Alert")]
        [DataRow(104,"End")]
        [DataTestMethod]
        public void UseSerializerToParseXml_Events(int eventId, string expectedName)
        {
            var input = parser.Parse(xml);

            Event e = input.Events.FirstOrDefault(x => x.Id == eventId);
            Assert.IsNotNull(e);
            Assert.AreEqual(expectedName, e.Name);
        }
    }
}
