using System.Collections.Generic;
using System.Linq;
using GigHub.Core.Models;

namespace GigHub.Core.ViewModels.Shared
{
    public class GigsVM
    {
        public IEnumerable<Gig> UpcomingGigs { get; set; }
        public bool IsShowActions { get; set; }
        public string Heading { get; set; }
        public string SearchTerm { get; set; }
        public ILookup<int, Attendance> Attendances { get; set; }
    }
}
