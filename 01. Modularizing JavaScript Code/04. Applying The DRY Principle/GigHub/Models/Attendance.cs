using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Services.Description;

namespace GigHub.Models
{
    public class Attendance
    {
        [Key]
        [Column(Order = 1)]             // this is needed if you use Composite key
        public int GigId { get; set; }
        public Gig Gig { get; set; }

        [Key]
        [Column(Order = 2)]             // this is needed if you use Composite key
        public string AttendeeId { get; set; }
        public ApplicationUser Attendee { get; set; }


    }
}