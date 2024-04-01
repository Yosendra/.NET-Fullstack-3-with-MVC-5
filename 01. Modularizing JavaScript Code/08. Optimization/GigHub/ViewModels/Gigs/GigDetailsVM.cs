using GigHub.Models;

namespace GigHub.ViewModels.Gigs
{
    public class GigDetailsVM
    {
        public Gig Gig { get; set; }
        public bool IsAttending { get; set; }
        public bool IsFollowing { get; set; }
    }
}