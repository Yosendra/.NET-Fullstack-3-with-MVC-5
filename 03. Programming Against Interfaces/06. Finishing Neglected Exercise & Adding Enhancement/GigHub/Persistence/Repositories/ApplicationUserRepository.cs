using System.Collections.Generic;
using System.Linq;
using GigHub.Core.Models;
using GigHub.Core.Repositories;

namespace GigHub.Persistence.Repositories
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly ApplicationDbContext _context;

        public ApplicationUserRepository(ApplicationDbContext context) => _context = context;

        public IEnumerable<ApplicationUser> GetArtistsFollowedBy(string followerId)
        {
            return _context.Followings
                .Where(f => f.FollowerId == followerId)
                .Select(f => f.Followee);
        }
    }
}