using BulkyBookWeb.Data;
using BulkyBookWeb.Models.User;
using Microsoft.AspNetCore.Mvc;
namespace BulkyBookWeb.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegisterController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                _context.Register.Add(model);
                _context.SaveChanges();
                return RedirectToAction("OneTimePin", "OneTimePin", new { email = model.Email });
            }
            else
            {
                return View(model);
            }
        }
    }
}