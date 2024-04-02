using System.Linq;
using System.Web.Mvc;
using GigHub.Models;
using GigHub.Persistence;
using GigHub.ViewModels.Gigs;
using GigHub.ViewModels.Shared;
using Microsoft.AspNet.Identity;

namespace GigHub.Controllers
{
    [Authorize]
    public class GigsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public GigsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public ActionResult Search(GigsVM viewModel)
        {
            return RedirectToAction("Index", "Home", new { query = viewModel.SearchTerm });
        }

        public ActionResult Details(int id)
        {
            var gig = _unitOfWork.Gigs.GetGig(id);
            if (gig == null)
                return HttpNotFound();

            var viewModel = new GigDetailsVM { Gig = gig, };
            if (User.Identity.IsAuthenticated)
            {
                var userId = User.Identity.GetUserId();
                viewModel.IsAttending = _unitOfWork.Attendances.GetAttendance(gig.Id, userId) != null;
                viewModel.IsFollowing = _unitOfWork.Followings.GetFollowing(gig.ArtistId, userId) != null;
            }

            return View("Details", viewModel);
        }

        public ActionResult Mine()
        {
            var artistId = User.Identity.GetUserId();
            var gigs = _unitOfWork.Gigs.GetUpcomingGigsByArtist(artistId);

            return View(gigs);
        }

        public ActionResult Attending()
        {
            var userId = User.Identity.GetUserId();
            var viewModel = new GigsVM
            {
                UpcomingGigs = _unitOfWork.Gigs.GetGigsUserAttending(userId),
                IsShowActions = User.Identity.IsAuthenticated,
                Heading = "Gigs I'm Going",
                Attendances = _unitOfWork.Attendances.GetFutureAttendances(userId).ToLookup(a => a.GigId),
            };

            return View("Gigs", viewModel);
        }

        public ActionResult Create()
        {
            var viewModel = new GigFormVM
            {
                Genres = _unitOfWork.Genres.GetGenres(),
                Heading = "Add a Gig",
            };

            return View("GigForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GigFormVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Genres = _unitOfWork.Genres.GetGenres();
                return View("GigForm", viewModel);
            }

            var gig = new Gig
            {
                ArtistId = User.Identity.GetUserId(),
                DateTime = viewModel.GetDateTime(),
                GenreId = viewModel.Genre,
                Venue = viewModel.Venue,
            };
            
            _unitOfWork.Gigs.Add(gig);
            _unitOfWork.Complete();

            return RedirectToAction("Mine", "Gigs");
        }

        public ActionResult Edit(int id)
        {
            var gig = _unitOfWork.Gigs.GetGig(id);
            if (gig == null) 
                return HttpNotFound();
            if (gig.ArtistId != User.Identity.GetUserId()) 
                return new HttpUnauthorizedResult();

            var viewModel = new GigFormVM
            {
                Id = gig.Id,
                Genres = _unitOfWork.Genres.GetGenres(),
                Genre = gig.GenreId,
                Date = gig.DateTime.ToString("d MMM yyyy"),
                Time = gig.DateTime.ToString("HH:mm"),
                Venue = gig.Venue,
                Heading = "Edit a Gig",
            };

            return View("GigForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GigFormVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Genres = _unitOfWork.Genres.GetGenres();
                return View("GigForm", viewModel);
            }

            var gig = _unitOfWork.Gigs.GetGigWithAttendees(viewModel.Id);
            if (gig == null)
                return HttpNotFound();
            if (gig.ArtistId != User.Identity.GetUserId())
                return new HttpUnauthorizedResult();

            gig.Modify(viewModel.GetDateTime(),
                viewModel.Venue,
                viewModel.Genre);

            _unitOfWork.Complete();

            return RedirectToAction("Mine", "Gigs");
        }
    }
}