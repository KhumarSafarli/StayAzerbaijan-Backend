using Microsoft.AspNetCore.Mvc;
using StayAzerbaijan.DAL;

namespace StayAzerbaijan.Controllers
{
    public class AboutController:Controller
    {

        private readonly ProductDbContext _context;

        public AboutController(ProductDbContext context)
        {
            _context = context;
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
