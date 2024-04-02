﻿using System;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using GigHub.Models;
using GigHub.Repositories;
using GigHub.ViewModels.Shared;
using Microsoft.AspNet.Identity;

namespace GigHub.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;
        private readonly GigRespository _gigRespository;                // notice this
        private readonly AttendanceRepository _attendanceRepository;

        public HomeController()
        {
            _context = new ApplicationDbContext();
            _gigRespository = new GigRespository(_context);                     // notice this
            _attendanceRepository = new AttendanceRepository(_context);
        }

        public ActionResult Index(string query = null)
        {
            var upcmingGigs = _context.Gigs
                .Include(g => g.Artist)
                .Include(g => g.Genre)
                .Where(g => g.DateTime > DateTime.Now && g.IsCanceled == false);

            if (!string.IsNullOrWhiteSpace(query))
                upcmingGigs = upcmingGigs
                    .Where(g => 
                        g.Artist.Name.Contains(query) || 
                        g.Genre.Name.Contains(query) || 
                        g.Venue.Contains(query));

            var userId = User.Identity.GetUserId();
            //var attendances = _context.Attendances
            //    .Where(a => a.AttendeeId == userId && a.Gig.DateTime > DateTime.Now)
            //    .ToList()
            //    .ToLookup(a => a.GigId);

            var viewModel = new GigsVM
            {
                UpcomingGigs = upcmingGigs,
                IsShowActions = User.Identity.IsAuthenticated,
                Heading = "Upcoming Gigs",
                SearchTerm = query,
                //Attendances = attendances,
                Attendances = _attendanceRepository.GetFutureAttendances(userId).ToLookup(a => a.GigId),
            };

            return View("Gigs", viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}