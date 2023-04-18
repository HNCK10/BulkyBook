using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models.User
{
    public class Register
    {
        [Required]
        [Display(Name = "Full name")]
        public string FullName { get; set; }
        [Key]
        [Required]
        [EmailAddress]
        [Display(Name = "Email address")]
        public string Email { get; set; }
    }
}