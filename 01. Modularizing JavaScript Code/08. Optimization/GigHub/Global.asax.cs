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
 * There is a need of optimization on this line on gigsController.js
 * 
        var init = function () {
            $(".js-toggle-attendance").click(toggleAttendance);
        };
 * 
 * This code only works for element that are currently in the document object model or DOM.
 * If in the future we implement something like load more, like in facebook or instagram
 * as the user scrolls down, the page show them more gigs. With this code, the toggleAttendance
 * method will not be called for elements that are added to the DOM after a page loaded.
 * Plus, in terms of memory management, when we use the click mehtod like this, you will end up
 * with a seperate handler per element matching this criteria. So if you have 10 gigs
 * on the page, we'll end up with 10 instances of toggleAttendance function in memory.
 * A more efficient way is to use the jQuery ".on()" method. It would look like this:
 * 
        var init = function () {
            $(container).on("click", ".js-toggle-attendance", toggleAttendance);
        };
 * 
 * With this we'll have one instance of toggleAttendance function in memory and if in
 * the future we add another element to this container that has ".js-toggle-attendance" selector
 * toggleAttendance will still be called when that element is clicked.
 * 
 * In Gigs.cshtml we make some adjustment when invoking GigsController.init()
 * 
 * Look at:
 * • app.js
 * • gigsController.js
 * • Gigs.cshtml
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
