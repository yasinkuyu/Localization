using System.Web.Mvc;
using System.Web.Routing;

namespace Insya.Localization.Helpers
{
    public static partial class HtmlHelperExtensions
    {

        /// <summary>
        /// MVC Action link localization html helper
        /// Example @Html.ActionLinkLocalization("homepage", "Index", "Home") -> <item id="homepage">Home Page</item>
        /// Output : <a href="homapageurl"></a>
        /// </summary>
        /// <param id="htmlHelper"></param>
        /// <param id="linkText"></param>
        /// <param id="actionName"></param>
        /// <param id="controllerName"></param>
        /// <param id="routeValues"></param>
        /// <param id="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString ActionLinkLocalization(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, object routeValues = null, object htmlAttributes = null)
        {
            var urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);
            var tagBuilder = new TagBuilder("a") { InnerHtml = Localization.Localize(linkText) };

            tagBuilder.Attributes["href"] = urlHelper.Action(actionName.ToLowerInvariant(), controllerName.ToLowerInvariant(), routeValues);

            tagBuilder.MergeAttributes(new RouteValueDictionary(htmlAttributes));

            return MvcHtmlString.Create(tagBuilder.ToString());
        }
    }
}
