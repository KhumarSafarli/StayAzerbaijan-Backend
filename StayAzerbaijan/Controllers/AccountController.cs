using Microsoft.AspNetCore.Mvc;
using StayAzerbaijan.DAL;

namespace StayAzerbaijan.Controllers
{
    public class AccountController:Controller
    {
        private readonly ProductDbContext _context;

        public AccountController(ProductDbContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
    }
}
