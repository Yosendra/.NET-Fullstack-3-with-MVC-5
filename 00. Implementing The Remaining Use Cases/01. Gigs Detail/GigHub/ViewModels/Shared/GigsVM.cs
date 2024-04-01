using System.Collections.Generic;
using GigHub.Models;

namespace GigHub.ViewModels.Shared
{
    public class GigsVM
    {
        public IEnumerable<Gig> UpcomingGigs { get; set; }
        public bool IsShowActions { get; set; }
        public string Heading { get; set; }
        public string SearchTerm { get; set; }
    }
}