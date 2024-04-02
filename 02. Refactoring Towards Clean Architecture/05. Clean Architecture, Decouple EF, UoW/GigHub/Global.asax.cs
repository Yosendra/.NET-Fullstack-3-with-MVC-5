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
 ***************************************************************************************************** 
 * Clean Architecture
 * • Independent of Frameworks
 * • Independent of UI
 * • Independent of Database
 * • Testable
 * 
 * Traditional Layered Architecture:
 * Presentation -> Business Logic -> Data Access
 * 
 * Clean Architecture
 * Presentation -> Business Logic <- Data Access    (Data Access DEPENDS on Business Logic)
 * 
 *****************************************************************************************************
 * Decouplling from Entity Framework
 * 
 * Currently Controller & Repository depends on DbContext
 * • Controller -> DbContext
 * • Repository -> DbContext
 * 
 * Issue with DbContext Everywhere
 * • Productivity (Many places to change)
 * • Team work (More merge conflicts)
 * • Deployment (Heavier deployments)
 * 
 * Instead of DbContext being everywhere in the application,
 * we want to reduce it to only in the repositories.
 * Controller and Service class should not know nothing about DbContext.
 * 
 *****************************************************************************************************
 * Unit of Work Pattern
 * 
 * In GigsController.Create(), we still have dependecy to _context when we want to save gig
 *
    _context.Gigs.Add(gig);
    _context.SaveChanges();
 *
 * We want to treat _gigRepository like a collection. So we can write it like this
 *
    _gigRepository.Add(gig)
 *
 * We create method .Add() at GigRepository class.
 * Notice we not calling the "_context.SaveChanges();" there
 * 
 * We are introduced Unit of Work
 * Maintains a list of object affected by a business transaction
 * and coordinates the writing out of changes
 * 
 * We should not have/invoke .SaveChanges() method in the repository
 * In business transaction, it's possible that we work with multiple repositories
 * We may get one domain object from this repository and another from another repository
 * We modify the state of both these domain objects, and then we need to process the changes.
 * If you add save method in the repository, which repository should have the same method? Both of them?
 * And that means we need to make two seperate calls to persist changes in each domain object.
 * But what about transaction? What if both these changes have to be persisted together?
 * You may say "Okay, we create a transaction object". Well we can do that, but do you think this is
 * a good and clean solution? So one more time, the repository should be like a collection of domain objects
 * in memory. Its contract meaning its public mehtods, should not reflect anything about a database.
 * Saving changes is the responsibility of unit of work.
 * 
 * Contract:
 * Repository -> Add(), Remove(), Get()
 * UnitOfWork -> Complete()
 * 
 ***************************************************************************************************** 
 * 
 * Implementing Unit of Work pattern
 * 
 * Add new folder "Persistence", Create a class named "UnitOfWork" inside it
 * This class will be tightly coupled to the Entity Framework
 * Add .Complete() method inside it
 * 
 * Add reference to UnitOfWork object in GigsController
 * 
 * Back to the GigsController.Create() (POST), use the .Complete() method from _unitOfWork object
 * to persist the data instead of using _context.SaveChanges();
 * 
 * We still have dependency to _context in the GigsController constructor 
 * even though we don't depend to it anymore in our method.
 * we will decouple it next
 * 
 * Look at:
 * • GigRepository.cs -> Add()
 * • GigsController.cs -> Create() (POST), field & constructor, Edit() (POST)
 * • UnitOfWork.cs -> Complete()
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
