// @yasinkuyu
// 05/08/2014

using System.Web.Mvc;

namespace Insya.Localization.Helpers
{

    public static partial class HtmlHelperExtensions
    {

        /// <summary>
        /// Razor template using @Html.Localize("id")
        /// </summary>
        /// <param id="helper"></param>
        /// <param id="id"></param>
        /// <returns></returns>
        public static MvcHtmlString Localize(this HtmlHelper helper, string id)
        {
            return new MvcHtmlString(Localization.Localize(id));
        }

        /// <summary>
        /// Razor template using @Html.Localize("id")
        /// </summary>
        /// <param id="helper"></param>
        /// <param id="id"></param>
        /// <param id="lang"></param>
        /// <returns></returns>
        public static MvcHtmlString Localize(this HtmlHelper helper, LangCode lang)
        {
            return new MvcHtmlString(Localization.Localize(lang));
        }

        /// <summary>
        /// or Razor template using @Html.Loc("id")
        /// </summary>
        /// <param id="helper"></param>
        /// <param id="id"></param>
        /// <returns></returns>
        public static MvcHtmlString Loc(this HtmlHelper helper, string id)
        {
            return new MvcHtmlString(Localization.Localize(id));
        }

        /// <summary>
        /// or Razor template using @Html.Loc("id")
        /// </summary>
        /// <param id="helper"></param>
        /// <param id="id"></param>
        /// <returns></returns>
        public static MvcHtmlString Get(this HtmlHelper helper, string id)
        {
            return new MvcHtmlString(Localization.Localize(id));
        }
    }

}
