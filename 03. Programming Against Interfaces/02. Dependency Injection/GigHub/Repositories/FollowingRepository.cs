using System.Linq;
using GigHub.Models;

namespace GigHub.Repositories
{
    public class FollowingRepository : IFollowingRepository
    {
        private readonly ApplicationDbContext _context;

        public FollowingRepository(ApplicationDbContext context) => _context = context;

        public Following GetFollowing(string followeeId, string followerId)
        {
            return _context.Followings
                .SingleOrDefault(a => a.FolloweeId == followeeId && a.FollowerId == followerId);
        }
    }
}