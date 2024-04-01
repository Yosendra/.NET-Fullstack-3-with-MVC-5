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
 * In app.js, we will seperate AttendanceService & GigsController module into each file,
 * In "Scripts/app" create two folders, Controllers & Services.
 * Create a file "attendanceService.js" inside "Scripts/app/services" directory, move AttendanceService module logic there
 * Create a file "gigsController.js" inside "Scripts/app/controllers" directory, move GigsController module logic there
 * Now register attendanceService.js & gigsController.js to bundle in BundleConfig
 * 
 * Look at:
 * • app.js
 * • attendanceService.js
 * • gigsController.js
 * • BundleConfig.cs
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
