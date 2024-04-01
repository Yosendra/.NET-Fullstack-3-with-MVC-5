using System.Linq;
using System.Web.Http;
using GigHub.Dtos;
using GigHub.Models;
using Microsoft.AspNet.Identity;

namespace GigHub.Controllers.Api
{
    [Authorize]
    public class FollowingsController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public FollowingsController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult Follow(FollowingDto dto)
        {
            var followerId = User.Identity.GetUserId();
            var followeeId = dto.FolloweeId;
            var isAlreadyFollow = _context.Followings.Any(f => f.FollowerId == followerId && f.FolloweeId == followeeId);

            if (isAlreadyFollow)
                return BadRequest("You already follow this artist.");

            var following = new Following
            {
                FollowerId = followerId,
                FolloweeId = followeeId,
            };
            _context.Followings.Add(following);
            _context.SaveChanges();

            return Ok();
        }
    }
}
