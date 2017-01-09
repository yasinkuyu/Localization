// @yasinkuyu
// 05/08/2014

using System.Globalization;
using System.Web;

namespace Insya.Localization
{
    internal class LocalizationStartup
    {
        private const string CacheLangCookieName = "CacheLang";

        private static string defaultCulture;

        private static string DefaultCulture {
            get 
            {
                if (string.IsNullOrEmpty(defaultCulture)) {
                    // https://msdn.microsoft.com/en-us/library/ee825488(v=cs.20).aspx
                    defaultCulture = new CultureInfo("en-US").Name;
                }

                return defaultCulture;
            }
        }

        /// <summary>
        /// Localization Culture (ex: tr-TR)
        /// </summary>
        /// <returns></returns>
        private string Culture { get; set; }

        /// Unique applization id (* optional)
        private string AppName { get; set; }

        /// <summary>
        /// Custom Xml folder id (* optional) (Default folder name Localization)
        /// </summary>
        /// <returns></returns>
        private string Folder { get; set; }

        public bool ReadCookie()
        {
            if (HttpContext.Current == null) {
                return false;
            }

            Culture = string.Format("{0}", DefaultCulture);

            var cookieLanguage = HttpContext.Current.Request.Cookies[CacheLangCookieName];

            if (cookieLanguage != null)
            {
                Culture = string.Format("{0}", cookieLanguage.Value);
            }
            else
            {
                var httpCookie = HttpContext.Current.Response.Cookies[CacheLangCookieName];
                if (httpCookie != null)
                    httpCookie.Value = DefaultCulture;

                if (cookieLanguage != null)
                    Culture = string.Format("{0}", cookieLanguage.Value);

            }

            return true;
        }

        /// <summary>
        /// Xml localization item id usgin GetLang("itemName")
        /// </summary>
        /// <param id="id">Xml localization item id</param>
        /// <returns></returns>
        public string GetLang(string id, string _culture = "")
        {
            if (!ReadCookie()) {
                return id;
            }

            // Unique applization default id
            string uniqueApplicationName = "InsyaLocalization";
            string xmlFolderName = "Localization";

            // If used more than once on a server, enter a unique id for each project.
            if (string.IsNullOrEmpty(AppName))
                AppName = uniqueApplicationName;

            if (string.IsNullOrEmpty(Folder))
                Folder = xmlFolderName;

            if (!string.IsNullOrEmpty(_culture))
                Culture = _culture;

            string applicationName = string.Format("{0}_{1}_", Culture, uniqueApplicationName);

            string key = applicationName + id;

            if (HttpContext.Current.Application[key] == null)
            {
                string path = HttpContext.Current.Server.MapPath(string.Format("~/{0}/{1}.xml", xmlFolderName, Culture));

                Resource.GetXmlResource(path, applicationName);
            }

            object valueObj = HttpContext.Current.Application[key];
            if (valueObj == null)
                return id;
            else return valueObj.ToString();            
        }

        /// <summary>
        /// Xml localization item id usgin GetLang("itemName")
        /// </summary>
        /// <param name="lang"></param>
        /// <returns></returns>
        public string GetLang(Inline lang)
        {
            if (!ReadCookie()) {
                return DefaultCulture;
            }

            if (Culture != null)
            {
                var propy = new GetPropertyByValue();
                var value = (string)propy.GetValue(lang, Culture);

                return value;
            }

            return DefaultCulture;
        }

        // ToDo this
        public string SetLang(string lang)
        {
            var cookieLanguage = HttpContext.Current.Request.Cookies[CacheLangCookieName];

            if (cookieLanguage != null)
            {
                var cookie = string.Format("{0}", cookieLanguage.Value);
            }

            return null;
        }
    }
}
