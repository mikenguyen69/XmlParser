using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using XmlParser.Entities;
using XmlParser.Tests.Services.Abstract;

namespace XmlParser.Tests
{
    [TestClass]
    public class StandardXmlParserShould : BaseTestSetup
    {
        private readonly string xml;

        public StandardXmlParserShould()
        {
            xml = @"  
                <EventInput> 
                    <GroupId>12345</GroupId>
                    <GroupName>ABC</GroupName>    
                    <Category>Cat</Category>
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
            var input = _parser.Parse(xml);

            Assert.AreEqual(12345, input.GroupId);
            Assert.AreEqual("ABC", input.GroupName);
            Assert.AreEqual(5, input.Events.Length);
        }

        [DataRow(100, "Start")]
        [DataRow(101, "Add")]
        [DataRow(102, "Change")]
        [DataRow(103, "Alert")]
        [DataRow(104, "End")]
        [DataTestMethod]
        public void UseSerializerToParseXml_Events(int eventId, string expectedName)
        {
            var input = _parser.Parse(xml);

            Event e = input.Events.FirstOrDefault(x => x.Id == eventId);
            Assert.IsNotNull(e);
            Assert.AreEqual(expectedName, e.Name);
        }

        [ExpectedException(typeof(System.InvalidOperationException))]
        [TestMethod]
        public void ThrowInvalidInputExeptionForInvalidDataType()
        {
            string invalidXml = @"<EventInput> 
                    <GroupId>134abc</GroupId>
                    <GroupName>ABC</GroupName>    
                    <Category>Cat</Category>
                    <Events> 
                        <Event Id=""100""><Name>Start</Name></Event> 
                        <Event Id=""101""><Name>Add</Name></Event> 
                        <Event Id=""102""><Name>Change</Name></Event> 
                        <Event Id=""103""><Name>Alert</Name></Event> 
                        <Event Id=""104""><Name>End</Name></Event> 
                        </Events> 
                </EventInput>";

            var input = _parser.Parse(invalidXml);
        }
    }
}
