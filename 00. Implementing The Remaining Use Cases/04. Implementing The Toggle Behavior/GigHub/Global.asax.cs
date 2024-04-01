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
 * Currently the going button show the right state, if we are going to the gig, it appears with blue button
 * but when we click again to not going, it still blue. Now we will make the toggle of it.
 * In Gigs.cshtml at the bottom, we put the condition for triggering the action.
 * 
 * Create new endpoint "DELETE /api/attendances" for deleting attendances in GigsController (API) -> DeleteAttendance()
 * 
 * Test: Click Going button at the gig, look at the changed button.
 *       Then click again on the same button, the button will revert its state
 * 
 * Look at:
 * • Gigs.cshtml
 * • GigsController.cs (API) -> DeleteAttendance()
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
