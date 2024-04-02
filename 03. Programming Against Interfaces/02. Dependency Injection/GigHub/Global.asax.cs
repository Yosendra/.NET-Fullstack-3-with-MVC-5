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
 * In GigsController, we still depends to EntityFramework by constructing ApplicationDbContext directly in the constructor
 * We need another mechanism to make it really decouple from ApplicationDbContext class.
 * 
 * Add constructor parameter at GigsController.
 * Notice at the assignment to _unitOfWork field inside it.
 * It is the implementation of "Dependencey Injection"
 * We're injecting depencdenicies into this class via its constructor.
 * So instead of this class initializing a concrete UnitOfWork class,
 * you want something else in our application to be responsible to that.
 * It would initialize object, pass them to different classes.
 * That's the job of Dependency Injection Framework.
 * 
 * Look at:
 * • GigsController -> field assignment, constructor parameter
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
