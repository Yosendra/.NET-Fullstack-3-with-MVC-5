using System.ComponentModel.DataAnnotations;

namespace GigHub.ViewModels.Identity
{
    public class ForgotPasswordVM
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
