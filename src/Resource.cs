// @yasinkuyu
// 05/08/2014

using System.Web;
using System.Xml;

namespace Insya.Localization
{
    public class Resource
    {
        /// <summary>
        /// GetXmlResource all items (ex: tr_TR.xml)
        /// 
        /// Very simple xml structure
        ///     <lang>
	    ///         <item id="homepage">Homepage</item>
        ///     </lang>
        /// </summary>
        /// <param name="path"></param>
        /// <param name="applicationName"></param>
        public static void GetXmlResource(string path, string applicationName)
        {
            using (XmlTextReader reader = new XmlTextReader(path)) {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(reader);

                var nodes = xmlDoc.DocumentElement.SelectSingleNode("//lang");

                for (int i = 0; i <= nodes.ChildNodes.Count - 1; i++) {
                    string itemId = nodes.ChildNodes.Item(i).Attributes.Item(0).InnerText;
                    string itemValue = nodes.ChildNodes.Item(i).InnerText;

                    HttpContext.Current.Application[applicationName + itemId] = itemValue;
                }
            }
        }
    }
}
