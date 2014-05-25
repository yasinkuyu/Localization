Localization
============

Create **multi-language** structure with ASP.NET MVC

	PM> Install-Package Localization

Requirements
---------------  

Localization
  - en_US.xml
  - tr_TR.xml
  - and more...
  
Bin
  - Insya.Localization.dll
  - System.ComponentModel.DataAnnotations


### Usage
    - @Html.ActionLinkLocalization("changelng", "Index", "Home", new { locale = "en_EN"})
    - @Html.ActionLinkLocalization("changelng", "Index", "Home", new { locale = "tr_TR"})
  
  **Or**
    
    - <a href="ChangeLang/?locale=en_US" title="Change Language">English</a>
    - <a href="ChangeLang/?locale=tr_TR" title="Dili Değiştir">Türkçe</a>


Structure
---------------

### Views

### Razor
	Xml file
    <item id="homepage">Home Page</item>
    
    Razor
         @Html.Localize("homepage")
    	 Or
         @Html.Get("homepage")
      
    Method
         Localization.Localize("homepage")
         Or
         Localization.Get("homepage")
    
    @Html.ActionLinkLocalization()
    @Html.ActionLocalization()

### Controllers

```
public ActionResult Index(string lang = "en_EN")
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

### Sample 

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
          </namespaces>
      </pages>
</system.web.webPages.razor>
```
