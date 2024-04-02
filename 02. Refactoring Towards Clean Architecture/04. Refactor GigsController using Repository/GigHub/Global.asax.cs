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
 * Exercise: Refactor GigsController using Repository. Change querying through _context into through repository
 * 
 * Look at:
 * • AttendanceRepository.cs -> GetAttendance()
 * • FollowingRepository.cs -> GetFollowing()
 * • GenreRepository.cs -> GetGenres()
 * • GigRespository.cs -> GetGig()
 * • GigsController.cs -> Details(), Mine(), Edit()
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
