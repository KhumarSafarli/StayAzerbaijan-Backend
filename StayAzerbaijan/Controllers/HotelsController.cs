using Microsoft.AspNetCore.Mvc;
using StayAzerbaijan.DAL;

namespace StayAzerbaijan.Controllers
{
    public class HotelsController:Controller
    {
        private readonly ProductDbContext _context;

        public HotelsController(ProductDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
