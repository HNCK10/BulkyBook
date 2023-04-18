using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models.User
{
    public class ChangePassword
    {
        [Key]
        [Required]
        [EmailAddress]
        [Display(Name = "Email address")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Security question")]
        public string SecurityQuestion { get; set; }

        [Required]
        [Display(Name = "Security answer")]
        public string SecurityAnswer { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        public string NewPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirm password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}