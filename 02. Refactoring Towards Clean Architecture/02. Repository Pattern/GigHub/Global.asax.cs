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
 * In HomeController.Index() we also have same logic as GetFutureAttendances() to get future attendances for the current user
 * We will refactor the logic again to the next level using Repository Pattern
 * 
 * Repository
 * Mediate between the domain and data mapping layers using a collection-like interface for accessing domain objects.
 * • Minimizes duplicate query logic
 * • Provides better seperation of concerns
 * • Doucouples from persistence frameworks
 * 
 * Problem solved by repository
 * • Complex query
 * • Fat controllers
 * • Fat services
 * 
 * Query logic, eager-loading, filtering grouping is data access concerns.
 * It is not the responsiblity of the controller or even the service.
 * It belong to repository.
 * 
 * We will move these two private methods to repository class:
 * List<Gig> GetGigsUserAttending(string userId)
 * List<Attendance> GetFutureAttendances(string userId)
 * 
 * Typically we need, we need one repository per entity type.
 * Based on the return type of those two methods, we need 
 * GigRespository and AttendanceRepository. Anytime we need 
 * Gig domain object, we ask GigRespository, and so on.
 * 
 * Create new folder "Repositories"
 * Add new classes "GigRespository" & "AttendanceRepository" under that folder
 * 
 * Now the private method GetGigsUserAttending() & GetFutureAttendances() in GigsController
 * to the repository and change the visibility to public
 * 
 * In GigsController, we will construct repository object in the constructor the save it to the field
 * in order to use repository object.
 * 
 * In GigsController.Attending(), use the repository object to get the future attendence and gigs
 * 
 * Now we can refactor the query logic on HomeCongtroller.Index()
 * 
 * Look at:
 * • GigsController.cs -> (construct reposiroty object)
 *      GetGigsUserAttending() (get moved to repository)
 *      GetFutureAttendances() (get moved to repository)
 * • GigRespository.cs -> GetGigsUserAttending()
 * • AttendanceRepository.cs -> GetFutureAttendances()
 * • HomeCongtroller.cs -> Index()
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
