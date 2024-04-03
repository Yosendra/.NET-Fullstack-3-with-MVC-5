using System.Linq;
using System.Web.Http;
using GigHub.Core.Models;
using Microsoft.AspNet.Identity;
using GigHub.Persistence;
using GigHub.Core.Dtos;
using GigHub.Core;

namespace GigHub.Controllers.Api
{
    [Authorize]
    public class FollowingsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public FollowingsController(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public IHttpActionResult Follow(FollowingDto dto)
        {
            var followeeId = dto.FolloweeId;
            var followerId = User.Identity.GetUserId();
            var isAlreadyFollow = _unitOfWork.Followings.GetFollowing(followeeId, followerId) != null;

            if (isAlreadyFollow)
                return BadRequest("You already follow this artist.");

            var following = new Following(followeeId, followerId);
            _unitOfWork.Followings.Add(following);
            _unitOfWork.Complete();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Unfollow(string id)
        {
            var userId = User.Identity.GetUserId();
            var following = _unitOfWork.Followings.GetFollowing(id, userId);

            if (following == null)
                return NotFound();

            _unitOfWork.Followings.Remove(following);
            _unitOfWork.Complete();

            return Ok(id);
        }
    }
}
