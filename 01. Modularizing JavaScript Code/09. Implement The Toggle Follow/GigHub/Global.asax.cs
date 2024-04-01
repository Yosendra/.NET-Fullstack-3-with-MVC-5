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
 * Implementation for toggle follow button of the artist in Gig Details
 * Also adding the api for unfollow artist
 * 
 * Test: click the artist name of upcoming gig to view gig detail page, toggle click on follow button
 * 
 * Look at:
 * • gigDetailsController.js
 * • followingService.js
 * • FollowingsController.cs (API) -> Unfollow()
 * • GigsController.cs -> Details.cshtml (add script section at the bottom)
 * • BundleConfig.cs (register gigDetailsController.js & followingService.js to the bundle)
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
