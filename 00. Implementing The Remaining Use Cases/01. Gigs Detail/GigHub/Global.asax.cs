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
 * Implementing Gigs Detail page
 * In Gigs.cshtml, add hyperlink on the artist name
 * Create GigDetailsVM
 * In GigsController, add Details action method
 * Create Details.cshtml for the gig detail page of GigsController.Details() action method
 * 
 * 
 * Look at:
 * • Gigs.cshtml
 * • GigDetailsVM.cs
 * • GigsController.cs -> Details()
 * • Details.cshtml
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
