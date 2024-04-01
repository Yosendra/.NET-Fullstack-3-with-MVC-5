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
 * Because of adding new property "Attendances" in GigsVM to be used in Gigs.cshtml,
 * It is possible there are other action method too which use the same this view model class
 * We can look at find reference to this view model GigsVM class to give initialization
 * for the Attendances property.
 * 
 * Go to GigsVM class, find reference.
 * After we look, we find that GigsController.Attending() is using the view model GigVM class
 * Initialize the attendances there, the logic same as the we put at HomeController.Index()
 * 
 * Test: The gigs you are going will appear with blue Going button
 * 
 * Look at:
 * • GigsController.cs -> Attending()
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
