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
 * Keep the state of Going to the gig or not in Gig list page
 * Add Attendances with "ILookup<int, Attendance>" type in GigsVM
 * Add logic to get attendances of the current user in HomeController.Index()
 * In Gigs.cshtml, add the conditional logic to display blue going button based on Attendances property of the Model
 * 
 * Test: The gigs you are going will appear with blue Going button
 * 
 * Look at:
 * • GigsVM.cs
 * • HomeController.cs -> Index() (there is the use of .LookUp() need to learn this)
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
