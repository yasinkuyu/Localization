using System.Web.Mvc;

namespace Insya.Localization.Helpers
{
    public static partial class HtmlHelperExtensions
    {

        /// <summary>
        /// MVC Action link localization url helper
        /// Example @Html.ActionLocalization("homepage", "Index", "Home") -> <item id="homepage">Home Page</item>
        /// Output : /Homepage/
        /// </summary>
        /// <param id="urlHelper"></param>
        /// <param id="actionName"></param>
        /// <param id="controllerName"></param>
        /// <param id="routeValues"></param>
        /// <returns></returns>
        public static string ActionLocalization(this UrlHelper urlHelper, string actionName, string controllerName, object routeValues = null)
        {
            var scheme = urlHelper.RequestContext.HttpContext.Request.Url.Scheme;

            return urlHelper.Action(actionName, controllerName, routeValues, scheme);
        }

    }
}
