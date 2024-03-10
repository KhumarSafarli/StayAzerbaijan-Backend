
using Microsoft.AspNetCore.Mvc;
using StayAzerbaijan.DAL;
using StayAzerbaijan.ViewModels;
using System.Linq;

namespace StayAzerbaijan.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductDbContext _context;

        public HomeController(ProductDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var allHotels = _context.Hotels.ToList(); 
            var model = new HomeVM
            {
                Hotels = allHotels
            };

            return View(model);

          
        }
    }
}
