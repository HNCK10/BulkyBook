using BulkyBookWeb.Data;
using BulkyBookWeb.Models.User;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
namespace BulkyBookWeb.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AuthenticationController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Authenticate()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Authenticate(string OneTimePin)
        {
            // Retrieve email from OneTimePin table using otp
            var oneTimePin = _context.OneTimePin.FirstOrDefault(o => o.OTP == OneTimePin);
            if (oneTimePin == null)
            {
                // Handle invalid OTP
                return RedirectToAction("InvalidOTP");
            }

            // Generate Temporary Password
            string tempPassword = GenerateRandomPassword();
            string hashedPassword = HashPassword(tempPassword);
            var authenticate = new Authenticate
            {
                Email = oneTimePin.Email,
                OTP = otp,
                TempPassword = hashedPassword
            };
            _context.Authenticate.Add(authenticate);
            _context.SaveChanges();

            return RedirectToAction("Success", new { tempPassword });
        }
        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                var hashedPassword = Convert.ToBase64String(hashedBytes);
                return hashedPassword;
            }
        }
        private string GenerateRandomPassword()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, 10).Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public IActionResult Success(string tempPassword)
        {
            ViewBag.TempPassword = tempPassword;
            return View();
        }
    }
}