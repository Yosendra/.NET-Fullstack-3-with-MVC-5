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
 * Dependency Inversion Principle
 * #1: High-level modules should not depend on low-level modules. Both should depend on abstractiions.
 * 
 * ==> : depends
 * 
 * Currently, Controller ==> UnitOfWork
 * 
 * Controller is high-level module, UnitOfWork is low-level module.
 * Our controller dependent, or tightly coupled to UnitOfWork,
 * which means we are violating dependency inversion principle.
 * But what is wrong with this tight coupling?
 * With this tight coupling, if we change UnitOfWork, the controller
 * may have to be changed, or at least it needs to be recompiled,
 * and the assembly in which it's defined needs to be redeployed.
 * This prevent us from independently deploy our assemblies or properly componentize
 * our application. Dependency Inversion Principle help us remove this coupling.
 * 
 * Using DIP, Controller ==> IUnitOfWork <== UnitOfWork
 * 
 * So instead of controller being dependent on UnitOfWork, it will be dependent on an
 * abstraction, or an interface that will be implemented by UnitOfWork.
 * With this, the controller no longer knows about the concrete UnitOfWork implementation.
 * If we change the UnitOfWork implementation, the controller will not be affected
 * as long as the contract or interface stays the same. Today we are using DbContext
 * and EntityFramework in our UnitOfWork, tommorow we can change it with another ORM
 * or newer version of Entity Framework with a different API. Again, the controller will
 * not be affected. It doesn't need recompilation because it's only dependent on the 
 * contract/interface. If we keep this contract simple and clean, the chances of it being
 * changed will be reduced significantly.
 * 
 * Dependency Inversion Principle
 * #2: Abstractions should not depend on details. Details should depend on abstractions.
 * 
 * Example in our IUnitOfWork we define contract like this:
 *  IUnitOfWork
 *  • Complete()
 *  • Gigs: GigRepository
 * notice, we still use concrete class there. That is GigRepository. We must change it to abstraction/interface. So it become like this:
 *  IUnitOfWork
 *  • Complete()
 *  • Gigs: IGigRepository
 * 
 * Create IGigRepository. by extract interface in GigRepository class. (using Visual Studio feature)
 * Now in UnitOfWork, change the type of Gigs property to IGigRepository.
 * Do the same to the others repository like before.
 * 
 * Now extract interface form UnitOfWork class become IUnitOfWork
 * In GigsController, change the type fielf of _unitOfWork from UnitOfWork to IUnitOfWork 
 * 
 * Look at:
 * • IGigRepository.cs
 * • IAttendanceRepository.cs
 * • IFollowingRepository.cs
 * • IGenreRepository.cs
 * • UnitOfWork.cs -> Gigs-Attendances-Followings-Genres properties,
 * • IUnitOfWork.cs
 * • GigsController.cs -> _unitOfWork field, _context field (removed), constructor
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
