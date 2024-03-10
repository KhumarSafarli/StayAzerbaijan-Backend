using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StayAzerbaijan.DAL;
using StayAzerbaijan.ViewModels;

namespace StayAzerbaijan.Controllers
{
    public class HotelsController : Controller
    {
        private readonly ProductDbContext _context;

        public HotelsController(ProductDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var hotels = _context.Hotels
                .Include(h => h.HotelCategories)
                .Take(3) 
                .ToList();

            var categories = _context.Categories.ToList();
            var model = new HotelsVM { Hotels = hotels, Categories = categories };
            return View(model);
        }

        public IActionResult GetMoreHotels(int page = 1, int pageSize = 3)
        {
            var hotels = _context.Hotels
                .Include(h => h.HotelCategories)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return PartialView("_HotelPartial", hotels);
        }

    }
}
