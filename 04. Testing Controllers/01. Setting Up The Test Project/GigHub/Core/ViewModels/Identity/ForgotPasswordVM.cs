using System.ComponentModel.DataAnnotations;

namespace GigHub.Core.ViewModels.Identity
{
    public class ForgotPasswordVM
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
