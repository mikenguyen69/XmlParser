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
        private readonly string xml;

        public NonStandardXmlParserShould()
        {
            xml = @"this is special text it has <GroupId>12345</GroupId> and a <GroupName>ABC</GroupName>.
It also has list of following events ....";
            //xml = $"<root>{xml}</root>";
        }

        [TestMethod]
        public void ExtractTheXmlNodeFromText()
        {
            NonStandardXmlParser parser = new NonStandardXmlParser();

            Type type = typeof(EventInput);
            PropertyInfo[] props = type.GetProperties();

            string[] taglist = props.Where(x => x.PropertyType != typeof(Array)).Select(x => x.Name).ToArray();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<EventInput>");

            foreach(string tag in taglist)
            {
                Regex rx = new Regex(string.Format("<{0}>(.*)</{0}>", tag), RegexOptions.Compiled | RegexOptions.IgnoreCase);

                var match = rx.Match(xml);
                List<string> tagList = new List<string>();

                if (match.Success)
                {
                    sb.AppendLine(match.Groups[0].Value);
                }
            }
            sb.AppendLine("</EventInput>");

            string combinedXml = sb.ToString();

            var eventInput = _parser.Parse(combinedXml);

            Assert.AreEqual(12345, eventInput.GroupId);
            Assert.AreEqual("ABC", eventInput.GroupName);
        }
    }
}
