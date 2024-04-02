using System.Linq;
using GigHub.Models;

namespace GigHub.Repositories
{
    public class FollowingRepository
    {
        private readonly ApplicationDbContext _context;

        public FollowingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Following GetFollowing(string artistId, string followerId)
        {
            return _context.Followings.SingleOrDefault(a => a.FolloweeId == artistId && a.FollowerId == followerId);
        }
    }
}