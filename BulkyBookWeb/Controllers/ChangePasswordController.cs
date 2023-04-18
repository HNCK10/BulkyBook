using BulkyBookWeb.Data;
using BulkyBookWeb.Models.User;
using Microsoft.AspNetCore.Mvc;
namespace BulkyBookWeb.Controllers
{
    public class ChangePasswordController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChangePasswordController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePassword model)
        {
            if (ModelState.IsValid)
            {
                if (!IsPasswordStrong(model.NewPassword))
                {
                    ModelState.AddModelError("NewPassword", "Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, one number, and one special character.");
                    return View(model);
                }
                var login = new Login
                {
                    Email = model.Email,
                    Password = model.NewPassword,
                    TempPassword = null,
                    IsResetChecked = false
                };
                var changePassword = new ChangePassword
                {
                    Email = model.Email,
                    SecurityQuestion = model.SecurityQuestion,
                    SecurityAnswer = model.SecurityAnswer,
                    NewPassword = model.NewPassword
                };
                var resetPassword = new ResetPassword
                {
                    Email = model.Email,
                    SecurityQuestion = model.SecurityQuestion,
                    SecurityAnswer = model.SecurityAnswer,
                    NewPassword = model.NewPassword
                };
                _context.Login.Add(login);
                _context.ChangePassword.Add(changePassword);
                _context.ResetPassword.Add(resetPassword);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
        private bool IsPasswordStrong(string password)
        {
            const int MINIMUM_LENGTH = 8;
            const int MINIMUM_NON_ALPHANUMERIC_CHARACTERS = 1;
            if (password.Length < MINIMUM_LENGTH)
            {
                return false;
            }
            if (!password.Any(char.IsUpper) ||
                !password.Any(char.IsLower) ||
                !password.Any(char.IsDigit) ||
                password.Count(c => !char.IsLetterOrDigit(c)) < MINIMUM_NON_ALPHANUMERIC_CHARACTERS)
            {
                return false;
            }
            return true;
        }
    }
}