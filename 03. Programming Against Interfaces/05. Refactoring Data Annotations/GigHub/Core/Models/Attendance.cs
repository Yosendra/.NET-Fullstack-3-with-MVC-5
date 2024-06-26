﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Services.Description;

namespace GigHub.Core.Models
{
    public class Attendance
    {
        [Key]
        [Column(Order = 1)]
        public int GigId { get; set; }
        public Gig Gig { get; set; }

        [Key]
        [Column(Order = 2)]
        public string AttendeeId { get; set; }
        public ApplicationUser Attendee { get; set; }
    }
}