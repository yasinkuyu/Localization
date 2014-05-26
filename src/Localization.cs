// @yasinkuyu
// 05/08/2014

namespace Insya.Localization
{
    public static class Localization
    {


        private static LocalizationStartup _loc;

        static Localization()
        {
            _loc = new LocalizationStartup();

        }

        /// <summary>
        /// Alternative calling Localize("id") or Get("id")
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string Get(string id)
        {

            return _loc.GetLang(id);

        }

        /// <summary>
        /// Example	<item id="homepage">Home Page</item>
        /// </summary>
        /// <param name="id"></param>
        /// <returns>xml item id</returns>
        public static string Localize(string id)
        {
            return _loc.GetLang(id);

        }


        /// <summary>
        /// Todo: Inline localization 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>xml item id</returns>
        public static string Localize(LangCode lang)
        {
            return _loc.GetLang(lang.en_US.ToString());

        }

        
        // ToDo this 
        public static string Set(string id)
        {

            return _loc.GetLang(id);

        }
    }
}
