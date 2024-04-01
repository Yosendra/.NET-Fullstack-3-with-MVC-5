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
 * In app.js we define a function directly.
 * It pollute the global namespace. Chances are we can accidently
 * create the same function. This is not we want.
 * 
 * We will use the concept called Revealing Module Pattern
 * Look at app.js, we try to use this concept
 * In Gigs.cshtml, instead of calling initGigs();, we change it to GigsController.init()
 * 
 * Look at:
 * • app.js
 * • Gigs.cshtml
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
