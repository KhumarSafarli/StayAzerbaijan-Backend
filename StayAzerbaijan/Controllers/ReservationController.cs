using StayAzerbaijan.DAL;
using StayAzerbaijan.Entities;
using StayAzerbaijan.Models;
using StayAzerbaijan.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace StayAzerbaijan.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ProductDbContext _context;

        public ReservationController(ProductDbContext context)
        {
            _context = context;
        }

        public IActionResult Reservation(int hotelId, DateTime checkInDate, DateTime checkOutDate, int roomId, int paxCount, int nights, int adultCount, int childCount, string transferOption)
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

            decimal transferPrice = 0;
            if (transferOption != "no-transfer")
            {
                var selectedTransfer = _context.Transfers.FirstOrDefault(t => t.Name == transferOption);
                if (selectedTransfer != null)
                {
                    transferPrice = selectedTransfer.Price;
                }
            }

            decimal totalPrice = room != null ? room.Price * nights + transferPrice : transferPrice;

            var model = new ReservationVM
            {
                Hotel = hotel,
                Room = room,
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
