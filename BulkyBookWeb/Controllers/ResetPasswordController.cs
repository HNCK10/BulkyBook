using BulkyBookWeb.Data;
using BulkyBookWeb.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class ResetPasswordController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ResetPasswordController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: ResetPassword
        public IActionResult ResetPassword()
        {
            return View();
        }

        // POST: ResetPassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ResetPassword(ResetPassword resetPassword)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Login.FirstOrDefault(u => u.Email == resetPassword.Email);
                if (user != null)
                {
                    var changePassword = _context.ChangePassword.FirstOrDefault(c => c.Email == resetPassword.Email);
                    if (changePassword != null && changePassword.SecurityAnswer == resetPassword.SecurityAnswer)
                    {
                        user.Password = resetPassword.NewPassword;
                        _context.SaveChanges();
                        return RedirectToAction("Login", "LoginController");
                    }
                    else
                    {
                        ModelState.AddModelError("", "The security answer is incorrect.");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "The email address does not exist.");
                }
            }
            return View(resetPassword);
        }
    }
}
