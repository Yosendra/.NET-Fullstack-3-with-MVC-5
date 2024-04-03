namespace GigHub.Core.Models
{
    public class Attendance
    {
        public int GigId { get; private set; }
        public string AttendeeId { get; private set; }
        public Gig Gig { get; set; }
        public ApplicationUser Attendee { get; set; }

        protected Attendance()
        {
        }

        public Attendance(int gigId, string attendeeId)
        {
            GigId = gigId;
            AttendeeId = attendeeId;
        }
    }
}