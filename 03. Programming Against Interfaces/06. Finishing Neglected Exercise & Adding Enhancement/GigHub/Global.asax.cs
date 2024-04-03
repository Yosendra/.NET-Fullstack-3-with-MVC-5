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
 * Finishing Neglected Exercise & Adding Enhancement
 * 
 * Look at:
 * • ApplicationDbContext.cs -> OnModelCreating() (register domain class configuration)
 * • Attendance.cs                                (delete annotation)
 * • Following.cs                                 (delete annotation)
 * • UserNotification.cs                          (delete annotation)
 * • Genre.cs                                     (delete annotation)
 * • Notification.cs                              (delete annotation)
 * • ApplicationUser.cs                           (delete annotation)
 * • AttendanceConfiguration.cs
 * • FollowingConfiguration.cs
 * • UserNotificationConfiguration.cs
 * • GenreConfiguration.cs
 * • NotificationConfiguration.cs
 * • ApplicationUserConfiguration.cs
 * • IUnitOfWork.cs
 * • UnitOfWork.cs
 * • FolloweesController.cs                       (Refactor)
 * • IApplicationUserRepository.cs
 * • ApplicationUserRepository.cs
 * • HomeController.cs                            (Refactor)
 * • IGigRepository.cs
 * • GigRepository.cs
 * • GigsController.cs (API)                      (Refactor)
 * • NotificationsController.cs (API)             (Refactor)
 * • INotificationRepository.cs
 * • NotificationRepository.cs
 * • IUserNotificationRepository.cs
 * • UserNotificationRepository.cs
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
