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
 * We will refactor the data annotation in domain model.
 * We will override them using FluentAPI instead of using annotation.
 * Delete the data annotation we are using in domain classes
 * 
 * In Gig, delete all data annotation
 * In ApplicationDbContext, write the configuration for the Gig inside .OnModelCreating() 
 * 
 * Create a new folder EntityConfigurations under Persistence folder
 * Add GigConfiguration class inside that folder
 * 
 * The convention we use when defining relationship in configuration of FluentAPI
 * we put it in Parent/Principle table
 * 
 * Back to ApplicationDbContext.OnModelCreating(), put
 *   modelBuilder.Configurations.Add(new GigConfiguration());
 * to register the Gig Configuration
 * 
 * (now it is Gig only, we need do the same for the others domain classes which use data annotation, this can be exercise)
 * 
 * Look at:
 * • Gig.cs -> delete all data annotation
 * • ApplicationDbContext.cs -> OnModelCreating()
 * • GigConfiguration.cs
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
