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
 * We still have dependency to _context in the GigsController constructor 
 * even though we don't depend to it anymore in our method.
 * we will decouple it now
 * 
 * Look at GigsController. We have 4 dependency to repository object. It is so many.
 * In a unit of work, we always work with one or more repositories.
 * It doesn't make sense to have unit of work without a repository.
 * We will move the repository field under the UnitOfWOrk, instead of access the repository directly
 * we will access them through the unit of work. This way will reduce dependencies in this class
 * and we will only have two dependencies, DbContext and UnitOfWork
 * 
 * In UnitOfWork, add property to contain the repository
 * Back to GigsController's constructor,
 * We can remove the _gigsRepository field
 * Now we use _unitOfWork.Gigs to access the GigRepository,
 * Fix the code error due to this changes in GigsController
 * 
 * Now do the same for the other repositories
 * 
 * Look at:
 * • UnitOfWork.cs
 * • GigsController.cs
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
