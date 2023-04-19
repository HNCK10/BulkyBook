using BulkyBookWeb.Data;
using BulkyBookWeb.Models.User;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using BulkyBookWeb.Controllers;
namespace BulkyBookWeb.Controllers
{
    public class OneTimePinController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OneTimePinController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        [HttpPost]
        public IActionResult OneTimePin(string email)
        {
            if (Request.Method == "POST")
            {
                return RedirectToAction("Authenticate","Authentication", new { email, encryptedOtp });
            }
            else
            {
                var register = _context.Register.Find(email);
                if (register == null)
                {
                    return NotFound();
                }
                var otp = Guid.NewGuid().ToString().Substring(0, 6);
                var dataProtectionProvider = DataProtectionProvider.Create("BulkyBookWeb");
                var protector = dataProtectionProvider.CreateProtector("OneTimePin");
                var encryptedOtp = protector.Protect(otp);
                var oneTimePin = new OneTimePin
                {
                    Email = email,
                    OTP = encryptedOtp
                };
                _context.OneTimePin.Add(oneTimePin);
                _context.SaveChanges();
                var decryptedOtp = protector.Unprotect(encryptedOtp);
                ViewBag.DecryptedOtp = decryptedOtp;
                return View();
            }
        }
    }
}
