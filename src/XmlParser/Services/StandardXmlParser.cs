using System;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;
using XmlParser.Entities;
using XmlParser.Interfaces;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace XmlParser.Services
{
    public class StandardXmlParser<T> : IParser<T> where T : BaseEntity
    {
        private readonly XmlSerializer serializer;

        public StandardXmlParser()
        {
            serializer = new XmlSerializer(typeof(T));
        }
        
        public T Parse(string xml) 
        {
            return (T)serializer.Deserialize(new StringReader(xml));
        }

        public T ParseText(string text)
        {
            Type type = typeof(EventInput);
            PropertyInfo[] props = type.GetProperties();

            string[] taglist = props.Select(x => x.Name).ToArray();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("<{0}>", type.Name));

            foreach (string tag in taglist)
            {
                string match = GetMatchXmlNode(text, tag);

                if (!string.IsNullOrEmpty(match))
                {
                    sb.AppendLine(match);
                }
            }

            sb.AppendLine(string.Format("</{0}>", type.Name));
            
            return Parse(sb.ToString());
        }

        #region Helpers
        private string GetMatchXmlNode(string text, string tag)
        {
            string result = "";
            Regex rx = new Regex(string.Format("<{0}>(.*)</{0}>", tag), RegexOptions.Compiled | RegexOptions.IgnoreCase);

            var match = rx.Match(text);
            List<string> tagList = new List<string>();

            if (match.Success)
            {
                result = match.Groups[0].Value;

                // replace the tag to be title case that match the property name
                result = Regex.Replace(result, tag, tag, RegexOptions.IgnoreCase);
            }

            return result;
        }
        #endregion
    }
}
