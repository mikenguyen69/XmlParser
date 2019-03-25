using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using XmlParser.Entities;
using XmlParser.Tests.Services.Abstract;

namespace XmlParser.Tests.Services
{
    [TestClass]
    public class NonStandardXmlParserShould : BaseTestSetup
    {
        private readonly string validXml;

        public NonStandardXmlParserShould()
        {
            validXml = @"this is special text it has <GroupId>12345</GroupId> and a <GroupName>ABC</GroupName>.
It also has list of following events ....";
        }

        [TestMethod]
        public void ExtractTheXmlNodeFromText()
        {
            var eventInput = _parser.ParseText(validXml);

            Assert.AreEqual(12345, eventInput.GroupId);
            Assert.AreEqual("ABC", eventInput.GroupName);
        }

        [ExpectedException(typeof(System.InvalidOperationException))]
        [TestMethod]
        public void ThrowInvalidOperationExceptionForInvalidTag()
        {
            string invalidXml = @"this is special text it has <GroupId>Invalid Id Here</GroupId> and a <GroupName>ABC</GroupName>.
It also has list of following events ....";

            var eventInput = _parser.ParseText(invalidXml);
        }
    }
}
