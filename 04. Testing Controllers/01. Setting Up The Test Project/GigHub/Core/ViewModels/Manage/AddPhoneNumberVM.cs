using System.ComponentModel.DataAnnotations;

namespace GigHub.Core.ViewModels.Manage
{
    public class AddPhoneNumberVM
    {
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string Number { get; set; }
    }
}
