using BulkyBookWeb.Data;
using BulkyBookWeb.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Authentication/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: Authentication/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Login model)
        {
            if (ModelState.IsValid)
            {
                var auth = _context.Authenticate.FirstOrDefault(a => a.Email == model.Email);

                if (auth != null)
                {
                    var user = _context.Login.FirstOrDefault(u => u.Email == model.Email);

                    if (user == null)
                    {
                        if (model.Password == auth.TempPassword)
                        {
                            var login = new Login
                            {
                                Email = model.Email,
                                Password = model.Password,
                                TempPassword = auth.TempPassword,
                            };

                            _context.Add(login);
                            _context.SaveChanges();

                            if (model.IsResetChecked)
                            {
                                return RedirectToAction("ResetPassword", new { email = model.Email });
                            }
                            else
                            {
                                return RedirectToAction("ChangePassword");
                            }
                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                            return View(model);
                        }
                    }
                    else
                    {
                        if (user.Password == model.Password)
                        {
                            if (model.IsResetChecked)
                            {
                                return RedirectToAction("ResetPassword", new { email = model.Email });
                            }
                            else
                            {
                                return RedirectToAction("Index", "Home");
                            }
                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                            return View(model);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }
            }
            return View(model);
        }
    }
}