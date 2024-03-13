using StayAzerbaijan.Entities;
using StayAzerbaijan.Models;
using StayAzerbaijan.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StayAzerbaijan.DAL;
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

        [HttpGet]
        public IActionResult Reservation(int hotelId, DateTime checkInDate, DateTime checkOutDate, int roomId, int paxCount, int nights, int adultCount, int childCount, string promoCode)
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

            var appliedPromoCode = string.IsNullOrEmpty(promoCode) ? null : _context.Promocodes.FirstOrDefault(pc => pc.Code == promoCode);

            if (appliedPromoCode != null)
            {
                totalPrice -= appliedPromoCode.DiscountAmount;
            }

            var model = new ReservationVM
            {
                Hotel = hotel,
                Room = room,
                MealTypes = mealTypes,
                HotelName = hotel.Name,
                RoomType = room != null ? room.Name : "",
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
                SelectedRoomType = room != null ? room.Name : "",
                PromoCode = promoCode,
                PromoCodeDiscount = appliedPromoCode != null ? appliedPromoCode.DiscountAmount : 0,
                Promocodes = _context.Promocodes.ToList()  
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult ApplyPromoCode(string promoCode)
        {
           
            var appliedPromoCode = _context.Promocodes.FirstOrDefault(pc => pc.Code == promoCode);

            if (appliedPromoCode != null)
            {
                
                return Json(appliedPromoCode.DiscountAmount);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult CreateReservation(Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var reservationEntity = new Reservation
                    {
                        Name = reservation.Name,
                        LastName = reservation.LastName,
                        HotelName = reservation.HotelName,
                        RoomType = reservation.RoomType,
                        PaxCount = reservation.PaxCount,
                        Price = reservation.Price,
                        PassportNumber = reservation.PassportNumber,
                        MobileNumber = reservation.MobileNumber,
                        CheckIn = reservation.CheckIn,
                        CheckOut = reservation.CheckOut
                    };

                    _context.Reservations.Add(reservationEntity);
                    _context.SaveChanges();

                    return Ok(new { status = 200, message = "Rezervasiyanız təsdiqləndi! Sizinlə əlaqə saxlayacağıq." });
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error creating reservation: {ex.Message}");
                    return StatusCode(500, "An error occurred while processing your request.");
                }
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                return BadRequest(new { status = 400, errors = errors });
            }
        }




    }
}
