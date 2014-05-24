using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;

namespace Insya.Localization
{
    public class Resource
    {
        public static void GetXmlResource(string path, string applicationName)
        {

            var doc = new XmlTextReader(path);
            var xml = new XmlDocument();
            xml.Load(doc);

            var nodes = xml.DocumentElement.SelectSingleNode("//lang");

            for (var nod = 0; nod <= nodes.ChildNodes.Count - 1; nod++)
            {
                var itemId = nodes.ChildNodes.Item(nod).Attributes.Item(0).InnerText;
                var itemValue = nodes.ChildNodes.Item(nod).InnerText;

                HttpContext.Current.Application[applicationName + itemId] = itemValue;

            }
            xml.Clone();
            doc.Close();
        }
    }
}
