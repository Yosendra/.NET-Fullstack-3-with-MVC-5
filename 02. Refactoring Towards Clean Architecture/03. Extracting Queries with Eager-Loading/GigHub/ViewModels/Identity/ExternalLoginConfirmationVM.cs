using System.ComponentModel.DataAnnotations;

namespace GigHub.ViewModels.Identity
{
    public class ExternalLoginConfirmationVM
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
