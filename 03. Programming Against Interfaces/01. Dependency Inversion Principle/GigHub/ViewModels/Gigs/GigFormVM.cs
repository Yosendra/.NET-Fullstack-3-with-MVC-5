using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web.Mvc;
using GigHub.Controllers;
using GigHub.Models;
using GigHub.ViewModels.CustomDataAnnotations;

namespace GigHub.ViewModels.Gigs
{
    public class GigFormVM
    {
        public int Id { get; set; }

        [Required]
        public string Venue { get; set; }

        [Required]
        [FutureDate]
        public string Date { get; set; }

        [Required]
        [ValidTime]
        public string Time { get; set; }

        public DateTime GetDateTime() => DateTime.Parse(string.Format("{0} {1}", Date, Time));

        [Required]
        public byte Genre { get; set; }

        public IEnumerable<Genre> Genres { get; set; }

        public string Heading { get; set; }

        public string Action 
        {
            //get => Id == 0
            //    ? "Create"
            //    : "Edit";

            get
            {
                Expression<Func<GigsController, ActionResult>> create = (c => c.Create(null));
                Expression<Func<GigsController, ActionResult>> edit = (c => c.Edit(null));

                var action = (Id == 0) ? create : edit;
                var actionName = (action.Body as MethodCallExpression).Method.Name;
                return actionName;
            }
        }
    }
}