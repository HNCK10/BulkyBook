using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models.User
{
    public class Login
    {
        [Key]
        [Required]
        [EmailAddress]
        [Display(Name = "Email address")]
        public string Email { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        public string TempPassword { get; set; }
        public bool IsResetChecked { get; set; }
    }
}
