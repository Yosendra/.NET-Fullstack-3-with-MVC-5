using System.Linq;
using GigHub.Core.Models;
using GigHub.Core.Repositories;

namespace GigHub.Persistence.Repositories
{
    public class FollowingRepository : IFollowingRepository
    {
        private readonly ApplicationDbContext _context;

        public FollowingRepository(ApplicationDbContext context) => _context = context;

        public void Add(Following following)
        {
            _context.Followings.Add(following);
        }

        public void Remove(Following following)
        {
            _context.Followings.Remove(following);
        }

        public Following GetFollowing(string followeeId, string followerId)
        {
            return _context.Followings
                .SingleOrDefault(a => 
                    a.FolloweeId == followeeId && 
                    a.FollowerId == followerId);
        }
    }
}
