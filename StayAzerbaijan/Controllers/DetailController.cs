using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StayAzerbaijan.DAL;
using StayAzerbaijan.ViewModels;
using System.Linq;

namespace StayAzerbaijan.Controllers
{
    public class DetailController : Controller
    {
        private readonly ProductDbContext _context;

        public DetailController(ProductDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int id)
        {
            var hotel = _context.Hotels
                .Include(h => h.Rooms)
                    .ThenInclude(r => r.RoomImages) 
                .FirstOrDefault(h => h.Id == id);

            if (hotel == null)
            {
                return NotFound();
            }

            var model = new HotelsVM
            {
                Hotel = hotel
            };

            return View(model);
        }
    }
}
