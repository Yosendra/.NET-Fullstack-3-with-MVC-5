namespace GigHub.Core.Models
{
    public class Following
    {
        public string FolloweeId { get; private set; }
        public string FollowerId { get; private set; }
        public ApplicationUser Follower { get; set; }
        public ApplicationUser Followee { get; set; }

        protected Following()
        {
        }

        public Following(string followeeId, string followerId)
        {
            FolloweeId = followeeId;
            FollowerId = followerId;
        }
    }
}