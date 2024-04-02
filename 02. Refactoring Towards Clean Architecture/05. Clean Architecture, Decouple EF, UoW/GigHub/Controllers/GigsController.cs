using System.Linq;
using System.Web.Mvc;
using GigHub.Models;
using GigHub.Persistence;
using GigHub.Repositories;
using GigHub.ViewModels.Gigs;
using GigHub.ViewModels.Shared;
using Microsoft.AspNet.Identity;

namespace GigHub.Controllers
{
    [Authorize]
    public class GigsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly GigRespository _gigRespository;
        private readonly AttendanceRepository _attendanceRepository;
        private readonly FollowingRepository _followingRepository;
        private readonly GenreRepository _genreRepository;
        private readonly UnitOfWork _unitOfWork;

        public GigsController()
        {
            _context = new ApplicationDbContext();
            _gigRespository = new GigRespository(_context);
            _attendanceRepository = new AttendanceRepository(_context);
            _followingRepository = new FollowingRepository(_context);
            _genreRepository = new GenreRepository(_context);
            _unitOfWork = new UnitOfWork(_context);
        }

        [HttpPost]
        public ActionResult Search(GigsVM viewModel)
        {
            return RedirectToAction("Index", "Home", new { query = viewModel.SearchTerm });
        }

        public ActionResult Details(int id)
        {
            var gig = _gigRespository.GetGig(id);
            if (gig == null)
                return HttpNotFound();

            var viewModel = new GigDetailsVM { Gig = gig, };

            if (User.Identity.IsAuthenticated)
            {
                var userId = User.Identity.GetUserId();
                viewModel.IsAttending = _attendanceRepository.GetAttendance(gig.Id, userId) != null;
                viewModel.IsFollowing = _followingRepository.GetFollowing(gig.ArtistId, userId) != null;
            }

            return View("Details", viewModel);
        }

        public ActionResult Mine()
        {
            var artistId = User.Identity.GetUserId();
            var gigs = _gigRespository.GetUpcomingGigsByArtist(artistId);

            return View(gigs);
        }

        public ActionResult Attending()
        {
            var userId = User.Identity.GetUserId();
            var viewModel = new GigsVM
            {
                UpcomingGigs = _gigRespository.GetGigsUserAttending(userId),
                IsShowActions = User.Identity.IsAuthenticated,
                Heading = "Gigs I'm Going",
                Attendances = _attendanceRepository.GetFutureAttendances(userId).ToLookup(a => a.GigId),
            };

            return View("Gigs", viewModel);
        }

        public ActionResult Create()
        {
            var viewModel = new GigFormVM
            {
                Genres = _genreRepository.GetGenres(),
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
                viewModel.Genres = _genreRepository.GetGenres();
                return View("GigForm", viewModel);
            }

            var gig = new Gig
            {
                ArtistId = User.Identity.GetUserId(),
                DateTime = viewModel.GetDateTime(),
                GenreId = viewModel.Genre,
                Venue = viewModel.Venue,
            };
            
            // we use .Add() in repository object
            //_context.Gigs.Add(gig);
            _gigRespository.Add(gig);

            // use the unit of work to persist data
            //_context.SaveChanges();
            _unitOfWork.Complete();

            return RedirectToAction("Mine", "Gigs");
        }

        public ActionResult Edit(int id)
        {
            var gig = _gigRespository.GetGig(id);
            if (gig == null) 
                return HttpNotFound();
            if (gig.ArtistId != User.Identity.GetUserId()) 
                return new HttpUnauthorizedResult();

            var viewModel = new GigFormVM
            {
                Id = gig.Id,
                Genres = _genreRepository.GetGenres(),
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
                viewModel.Genres = _genreRepository.GetGenres();
                return View("GigForm", viewModel);
            }

            var gig = _gigRespository.GetGigWithAttendees(viewModel.Id);
            if (gig == null) 
                return HttpNotFound();
            if (gig.ArtistId != User.Identity.GetUserId()) 
                return new HttpUnauthorizedResult();

            gig.Modify(viewModel.GetDateTime(),
                viewModel.Venue,
                viewModel.Genre);

            // use the unit of work to persist data
            //_context.SaveChanges();
            _unitOfWork.Complete();

            return RedirectToAction("Mine", "Gigs");
        }
    }
}