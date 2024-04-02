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
 * It is quite long, but the point is currently Controller Package ==> Persistance Package
 * Using the Dependency Inversion Principle. We will add a new "Core" Package (folder)
 * So the dependency package become like this:
 *  Controller ==> Core <== Persistance
 * Core is abstraction, containing business logic, domain object, dto, also view model
 * Controller responsible on how to represent the data, and accepting request from client
 * Persistance is responsible for data access
 * 
 * Add new folder "Core".
 * Move the Models, Dtos, folder there. Then fix the namespace.
 * Move IUnitOfWOrk to Core, update the namespace
 * Create folder under Core called named "Repositories", update the namespace
 * Move the all repositories's interface files to that folder, update the namespace
 * Move Repositories solution folder to Perssistence folder, update the namespace
 * Move ViewModels folder to Core also, update the namespace
 * 
 * Move Migration solution folder to Persistence folder,
 * but this is a tricky part. We should not change the namespace because 
 * Entity framework need this. After move it. We have to tell EF that the migration
 * folder is now under Persistence.
 * Under Migrations folder, open Configuration.cs, add MigrationsDirectory = @"Persistence\Migrations"; in the constructor
 * 
 * Look at:
 * • Configuration.cs
 * • etc
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
