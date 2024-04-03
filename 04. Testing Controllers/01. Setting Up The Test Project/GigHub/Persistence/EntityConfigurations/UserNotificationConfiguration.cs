using System.Data.Entity.ModelConfiguration;
using GigHub.Core.Models;

namespace GigHub.Persistence.EntityConfigurations
{
    public class UserNotificationConfiguration : EntityTypeConfiguration<UserNotification>
    {
        public UserNotificationConfiguration()
        {
            HasKey(un => new { un.UserId, un.NotificationId });
        }
    }
}