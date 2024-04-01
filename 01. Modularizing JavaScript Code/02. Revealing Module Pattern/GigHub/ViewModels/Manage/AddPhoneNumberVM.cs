using System.ComponentModel.DataAnnotations;

namespace GigHub.ViewModels.Manage
{
    public class AddPhoneNumberVM
    {
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string Number { get; set; }
    }
}