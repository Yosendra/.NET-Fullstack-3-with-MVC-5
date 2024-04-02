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
 * There are many Dependency Injection Framework. (Autofac, Ninject, Unity, StructureMap, etc)
 * And one of them is named "Ninject".
 * We will use Ninject as our Dependency Injection Framework in our project.
 * 
 * Install these package in Nuget Package Manager:
 * • Ninject.MVC5 (3.2.1)
 * • Ninject.Web.WebApi (3.2.1)
 * 
 * You will get new file configuration for Ninject named NinjectWebCommon.cs under App_Start folder
 * At that class at the bottom line, .RegisterServices() static function is where we register our 
 * concrete class to be used as service object which will be injected for the controller's constructor
 * 
 * We can register the service by writing statement like this:
 *      kernel.Bind<IUnitOfWork>().To<UnitOfWork>();
 * The disadvantage is we must not forget if there are other new Interface, we must register that
 * new interface by writing syntax like above.
 * There is better option by installing package "ninject.extensions.conventions". It use Convention over Configuration.
 * It adds support to configure bindings using convention. This way, Ninject will scan our assembly,
 * find all interfaces and their implementations and automatically bind them.
 * 
 * Install these package in Nuget Package Manager:
 * • ninject.extensions.conventions (3.2.0)
 * 
 * Back to .RegisterServices() static function, import namespace "Ninject.Extensions.Conventions"
 * Look at static function CreateKernel(), we add the logic for scanning the assembly for find
 * interface and its implementation class to binding them for dependency injection
 * 
 * Test: Run the application, go to Gig Detail page. If there is no exception.
 *       Our dependency injection is success.
 * 
 * Look at:
 * • NinjectWebCommon.cs
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
