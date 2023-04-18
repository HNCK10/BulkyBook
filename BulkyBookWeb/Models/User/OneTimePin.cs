using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models.User
{
    public class OneTimePin
    {
        [Key]
        [Required]
        [EmailAddress]
        [Display(Name = "Email address")]
        public string Email { get; set; }
        [Display(Name = "One Time Pin")]
        public string OTP { get; set; }
    }
}
