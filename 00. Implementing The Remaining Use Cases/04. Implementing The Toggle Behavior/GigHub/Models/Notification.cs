using System;
using System.ComponentModel.DataAnnotations;

namespace GigHub.Models
{
    public class Notification
    {
        public int Id { get; private set; }
        public DateTime DateTime { get; private set; }
        public NotificationType Type { get; private set; }
        public DateTime? OriginalDateTime { get; private set; }
        public string OriginalVenue { get; private set; }

        [Required]
        public int GigId { get; private set; }
        public Gig Gig { get; private set; }

        protected Notification()
        {
        }

        private Notification(NotificationType type, Gig gig)
        {
            Gig = gig ?? throw new ArgumentNullException("Gig is null.");
            Type = type;
            DateTime = DateTime.Now;
        }

        public static Notification GigCreated(Gig gig)
            => new Notification(NotificationType.GigCreated, gig);

        public static Notification GigCanceled(Gig gig)
            => new Notification(NotificationType.GigCanceled, gig);

        public static Notification GigUpdated(Gig newGig, DateTime originalDateTime, string originalVenue)
            => new Notification(NotificationType.GigUpdated, newGig) 
            {
                OriginalDateTime = originalDateTime,
                OriginalVenue = originalVenue,
            };
    }
}