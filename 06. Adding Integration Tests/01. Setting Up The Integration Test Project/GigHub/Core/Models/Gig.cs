using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GigHub.Core.Models
{
    public class Gig
    {
        public int Id { get; private set; }
        public string ArtistId { get; private set; }
        public byte GenreId { get; private set; }
        public DateTime DateTime { get; private set; }
        public string Venue { get; private set; }
        public bool IsCanceled { get; private set; }
        public Genre Genre { get; private set; }
        public ApplicationUser Artist { get; private set; }
        public ICollection<Attendance> Attendances { get; private set; }

        public Gig()
        {
            Attendances = new Collection<Attendance>();
        }

        public Gig(string artistId, byte genreId, DateTime dateTime, string venue, bool isCanceled = false)
        {
            ArtistId = artistId;
            GenreId = genreId;
            DateTime = dateTime;
            Venue = venue;
            IsCanceled = isCanceled;
            Attendances = new Collection<Attendance>();
        }

        public void Cancel()
        {
            IsCanceled = true;

            var notification = Notification.GigCanceled(this);
            foreach (var attendee in Attendances.Select(a => a.Attendee))
                attendee.Notify(notification);
        }

        public void Modify(DateTime dateTime, string venue, byte genre)
        {
            var notification = Notification.GigUpdated(this, DateTime, Venue);

            Venue = venue;
            DateTime = dateTime;
            GenreId = genre;

            foreach (var attendee in Attendances.Select(a => a.Attendee))
                attendee.Notify(notification);
        }
    }
}