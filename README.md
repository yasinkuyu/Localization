Localization
============

Create `multi-language` structure with ASP.NET MVC

    PM> Install-Package Localization


### Usage

    - <li>@Html.ActionLinkLocalization("English", "Index", "Locales", new { lang = "en_US" })</li>
    - <li>@Html.ActionLinkLocalization("Türkçe", "Index", "Locales", new { lang = "tr_TR" })</li>
    and more...
    Or
    - <a href="Locales/?lang=en_US">English</a>
    - <a href="Locales/?lang=tr_TR">Türkçe</a>
    and more...

Index.cshtml

    @Html.Get("homepage") or @Html.Localize("homepage")


### Video Tutorial



[![ASP.NET MVC Localization Tutorial vimeo](https://i.vimeocdn.com/video/476545847_295x166.jpg)](https://vimeo.com/96483908)


[![ASP.NET MVC Localization Tutorial youtube](https://i.vimeocdn.com/video/476545847_295x166.jpg)](http://youtu.be/9V5PS4m0er0)



Requirements
---------------  

Localization
  - en_US.xml
  - tr_TR.xml
  - and more...
  
Bin
  - Insya.Localization.dll
  - System.ComponentModel.DataAnnotations



Default locale
	
	public void DefaultLocale( )
	{
	    HttpCookie cookie = Request.Cookies.Get("CacheLang");
	    if ( cookie == null)
	    {
	        HttpCookie newCookie = new HttpCookie("CacheLang");
	        newCookie.Value = "en_US";
	        Response.Cookies.Add(newCookie);
	    }
	}


Structure
---------------

### Views
    Xml file
    <item id="homepage">Home Page</item>
    
    Razor
         @Html.Localize("homepage")
         Or
         @Html.Get("homepage")
      
    Code Behind
         Localization.Localize("homepage")
         Or
         Localization.Get("homepage")
    
    @Html.ActionLinkLocalization()
    @Html.ActionLocalization()


### Inline Localization
	
	@Html.Get(new Inline(en: "book", tr: "kitap"))
	@Html.Localize(new Inline(en: "book", tr: "kitap"))





### Controllers

```
public ActionResult Index(string lang = "en_US")
{
  Response.Cookies["CacheLang"].Value = lang;
  
  if (Request.UrlReferrer != null)
  Response.Redirect(Request.UrlReferrer.ToString());
  
  var message = Localization.Get("changedlng");
  
  return Content(message);
}
```

### Models
  
    Attribute Localize
      Display Attribute 
        [DisplayLocalize("username")]
        public string Username { get; set; }
      
      String Length Attribute 
        [StringLengthLocalize(20, MinimumLength = 4)]
        public string DisplayName { get; set; }
      
      Required Attribute 
        [RequiredLocalized]
        public string DisplayName { get; set; }
      
      Description Attribute 
        [DescriptionLocalize]
        public string DisplayName { get; set; }

----------

**Intellisense in razor files (Views/web.config)**
- Views
    - web.config
        - system.web.webPages.razor
            - pages
                - namespaces
                    - add namespace="Insya.Localization" 
                    - add namespace="Insya.Localization.Helpers" 


Example 

```
<system.web.webPages.razor>
  <host factoryType="System.Web.Mvc.MvcWebRazorHostFactory, System.Web.Mvc, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" />
      <pages pageBaseType="System.Web.Mvc.WebViewPage">
          <namespaces>
          <add namespace="System.Web.Mvc" />
          <add namespace="System.Web.Mvc.Ajax" />
          <add namespace="System.Web.Mvc.Html" />
          <add namespace="System.Web.Optimization"/>
          <add namespace="System.Web.Routing" />
          ## <add namespace="Insya.Localization" />
          ## <add namespace="Insya.Localization.Helpers" />
          </namespaces>
      </pages>
</system.web.webPages.razor>
```

**Note:** Nuget package auto insert <add namespace="Insya.Localization" />  <add namespace="Insya.Localization.Helpers" />



### Contribution
Fork


**Roadmap:**
- Localizable Routing
- All the XML language files editing tool on one screen.
- Testing tools
