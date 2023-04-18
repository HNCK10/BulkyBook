using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models.User
{
    public class ResetPassword
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

        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("NewPassword", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}