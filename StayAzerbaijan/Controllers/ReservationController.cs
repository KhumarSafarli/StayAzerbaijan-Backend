using StayAzerbaijan.Entities;
using StayAzerbaijan.Models;
using StayAzerbaijan.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StayAzerbaijan.DAL;

namespace StayAzerbaijan.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ProductDbContext _context;

        public ReservationController(ProductDbContext context)
        {
            _context = context;
        }

        public IActionResult Reservation(int hotelId, DateTime checkInDate, DateTime checkOutDate, int roomId, int paxCount, int nights, int adultCount, int childCount)
        {
            var hotel = _context.Hotels
                .Include(h => h.Rooms)
                .Include(h => h.HotelMealTypes)
                .ThenInclude(ht => ht.MealType)
                .FirstOrDefault(h => h.Id == hotelId);

            if (hotel == null)
            {
                return NotFound();
            }

            var room = hotel.Rooms.FirstOrDefault(r => r.Id == roomId);
            decimal totalPrice = room != null ? room.Price * nights : 0;
            var mealTypes = hotel.HotelMealTypes.Select(ht => ht.MealType).ToList();

            var model = new ReservationVM
            {
                Hotel = hotel,
                Room = room,
                MealTypes = mealTypes,
                RoomDetails = new RoomDetailsVM
                {
                    Room = room, 
                },
                CheckInDate = checkInDate,
                CheckOutDate = checkOutDate,
                PaxCount = paxCount,
                Nights = nights,
                AdultCount = adultCount,
                ChildCount = childCount,
                TotalPrice = totalPrice,
                SelectedRoomType = room != null ? room.Name : "" 
            };

            return View(model);
        }

    }
}
