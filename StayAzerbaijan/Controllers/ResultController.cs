using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StayAzerbaijan.DAL;
using StayAzerbaijan.Entities;
using StayAzerbaijan.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StayAzerbaijan.Controllers
{
    public class ResultController : Controller
    {
        private readonly ProductDbContext _context;

        public ResultController(ProductDbContext context)
        {
            _context = context;
        }

        public IActionResult SearchResult(string city, DateTime checkInDate, DateTime checkOutDate, int adultCount, int childCount)
        {
   
            int totalGuests = adultCount + childCount;
            var filteredHotels = _context.Hotels
                .Where(h => h.Location.Contains(city) || h.Name.Contains(city))
                .Include(h => h.HotelCategories)
                    .ThenInclude(hc => hc.Category)
                .Include(h => h.HotelMealTypes)
                    .ThenInclude(mt => mt.MealType)
                .Select(h => new Hotel
                {
                    Id = h.Id,
                    Name = h.Name,
                    Location = h.Location,
                    Star = h.Star,
                    Price = h.Price,
                    HotelCategories = h.HotelCategories,
                    HotelMealTypes = h.HotelMealTypes,
                    MainImgUrl = h.MainImgUrl,
                    Rooms = h.Rooms.Where(r => r.Capacity >= totalGuests).ToList()
                })
                .ToList();

          
            var model = new SearchResultViewModel
            {
                FilteredHotels = filteredHotels,
                CheckInDate = checkInDate,
                CheckOutDate = checkOutDate,
                AdultCount = adultCount,
                ChildCount = childCount
            };

            return View(model);
        }
    }
}
