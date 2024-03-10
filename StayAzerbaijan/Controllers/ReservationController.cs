using Microsoft.AspNetCore.Mvc;
using StayAzerbaijan.DAL;
using StayAzerbaijan.Models;
using StayAzerbaijan.ViewModels;

namespace StayAzerbaijan.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ProductDbContext _context;

        public ReservationController(ProductDbContext context)
        {
            _context = context;
        }

        public IActionResult Reservation(int hotelId)
        {
            var hotel = _context.Hotels.FirstOrDefault(h => h.Id == hotelId);
            if (hotel == null)
            {
                return NotFound();
            }

            var deluxeRoom = _context.Rooms.FirstOrDefault(r => r.HotelId == hotelId && r.Name == "Deluxe Standart Room");

            var model = new ReservationVM
            {
                Hotel = hotel,
                RoomDetails = new RoomDetailsVM
                {
                    BedType = deluxeRoom?.BedType,
                    Landscape = deluxeRoom?.Landscape,
                    MealType = "BB (səhər yeməyi)"
                }
            };

            return View(model);
        }
    }
}
