using Microsoft.AspNetCore.Mvc;
using StayAzerbaijan.Entities; 
using StayAzerbaijan.DAL;

namespace StayAzerbaijan.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly ProductDbContext _context;

        public DashboardController(ProductDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var reservations = _context.Reservations.ToList(); 
            return View(reservations); 
        }
    }
}
