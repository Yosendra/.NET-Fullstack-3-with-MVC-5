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
 * Extract interface from ApplicationDbContext class in order to be able to mock it
 * In GigRepository, depend on IApplicationDbContext instead of ApplicationDbContext
 * Create forlder Persistence->Repositories under Test project
 * Create unit test class "GigRepositoryTests" inside it
 * 
 * Look at:
 * • IApplicationDbContext.cs
 * • ApplicationDbContext.cs
 * • GigRepositoryTests.cs
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
