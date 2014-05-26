Localization
============

Create `multi-language` structure with ASP.NET MVC

    PM> Install-Package Localization


### Usage

    - <li>@Html.ActionLinkLocalization("English", "Index", "Locales", new { lang = "en_US" })</li>
    - <li>@Html.ActionLinkLocalization("Türkçe", "Index", "Locales", new { lang = "tr_TR" })</li>
    Or
    - <a href="Locales/?lang=en_US">English</a>
    - <a href="Locales/?lang=tr_TR">Türkçe</a>

Index.cshtml

    @Html.Get("homepage") or @Html.Localize("homepage")


### Video Tutorial

[![ASP.NET MVC Localization Tutorial](https://i.vimeocdn.com/video/476536020_295x166.jpg)](https://vimeo.com/96476532)



Requirements
---------------  

Localization
  - en_US.xml
  - tr_TR.xml
  - and more...
  
Bin
  - Insya.Localization.dll
  - System.ComponentModel.DataAnnotations





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






**Roadmap:**
- Localizable Routing
- All the XML language files editing tool on one screen.
- Testing tools