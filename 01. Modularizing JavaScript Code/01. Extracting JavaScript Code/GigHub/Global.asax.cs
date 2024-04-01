using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;

/* Password : User1#123
 * user1@domain.com
 * yosi@domain.com
 * artist1@domain.com
 * artist2@domain.com
 * 
 * At Gigs.cshtml, we combine the javascript code and html code in one file.
 * This is called spaghetti code. The best practice is to seperate both of them into their own file.
 * This is the implementation of principle Seperation of Concern
 * 
 * Create new folder named "app" under Scripts folder.
 * This folder is the place we put javascript code which specific from our application.
 * Create app.js under under that app folder
 * 
 * We create new javascript bundle in BundleConfig.
 * This bundle is specific to load our application javascript.
 * Look at BundleConfig
 * 
 * Go to _Layout.cshtml to render the app.js
 * 
 * Test: Toggle click on going button of the gig.
 *       It should be still working like normal
 * 
 * Look at:
 * • Gigs.cshtml
 * • app.js
 * • BundleConfig.cs
 * • _Layout.cshtml
*/

namespace GigHub
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Mapper.Initialize(c => c.AddProfile<MappingProfile>());
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
