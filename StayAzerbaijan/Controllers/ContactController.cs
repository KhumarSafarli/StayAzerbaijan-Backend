using Microsoft.AspNetCore.Mvc;
using StayAzerbaijan.DAL;

namespace StayAzerbaijan.Controllers
{
    public class ContactController:Controller
    {
        private readonly ProductDbContext _context;

        public ContactController(ProductDbContext context)
        {
            _context = context;
        }

        public IActionResult Contact()
        {
            return View();
        }
    }
}
