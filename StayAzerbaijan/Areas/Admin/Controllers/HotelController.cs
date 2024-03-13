using Microsoft.AspNetCore.Mvc;
using StayAzerbaijan.Areas.Admin.ViewModels;
using StayAzerbaijan.DAL;
using StayAzerbaijan.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StayAzerbaijan.DAL;
using StayAzerbaijan.Entities;
using StayAzerbaijan.Helpers;

namespace StayAzerbaijan.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HotelController : Controller
    {
        private readonly ProductDbContext _context;
        private readonly IWebHostEnvironment _env;

        public HotelController(ProductDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index()
        {
            IEnumerable<Hotel> model = _context.Hotels.ToList(); 
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
        
            CreateHotelVM model = new CreateHotelVM
            {
                Categories = _context.Categories.ToList(),
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateHotelVM hotel)
        {
            if (!ModelState.IsValid)
            {
                hotel.Categories = await _context.Categories.ToListAsync();
                return View(hotel);
            }

            Hotel newHotel = new Hotel();
            newHotel.HotelCategories = new List<HotelCategory>();
            newHotel.Location = hotel.Location;

            if (!hotel.MainPhoto.IsValidLength(1))
            {
                ModelState.AddModelError(string.Empty, "Main photo size error");
                hotel.Categories = await _context.Categories.ToListAsync();
                return View(hotel);
            }

            foreach (int id in hotel.CategoryIds)
            {
                HotelCategory category = new HotelCategory()
                {
                    CategoryId = id,
                    Hotel = newHotel
                };
                newHotel.HotelCategories.Add(category);
            }

            string mainPhotoName = await hotel.MainPhoto.GeneratePhoto(_env.WebRootPath, "assets", "images");
            newHotel.MainImgUrl = mainPhotoName;

            if (!hotel.SliderPhoto.IsValidLength(1))
            {
                ModelState.AddModelError(string.Empty, "Slider photo size error");
                hotel.Categories = await _context.Categories.ToListAsync();
                return View(hotel);
            }

            string sliderPhotoName = await hotel.SliderPhoto.GeneratePhoto(_env.WebRootPath, "assets", "images");
            newHotel.sliderImgUrl = sliderPhotoName;
            newHotel.Name = hotel.Name;
            newHotel.Price = hotel.PricePerNight;
            newHotel.Description = hotel.Description;
            newHotel.Star = hotel.Star;
            newHotel.IsAvailableOnWeekend = hotel.IsAvailableOnWeekend;

            await _context.Hotels.AddAsync(newHotel);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }




        public IActionResult Update(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            UpdateHotelVM model = _context.Hotels
                .Include(h => h.HotelCategories)
                    .ThenInclude(hc => hc.Category)
                .Where(h => h.Id == id)
                .Select(h => new UpdateHotelVM
                {
                    Id = h.Id,
                    Name = h.Name,
                    Location = h.Location,
                    PricePerNight = h.Price,
                    Description = h.Description,
                    Star = (int)h.Star,
                    IsAvailableOnWeekend = h.IsAvailableOnWeekend,
                    MainPhoto = null,
                    Categories = _context.Categories.ToList(),
                    HotelCategories = h.HotelCategories.ToList()
                }).FirstOrDefault(p => p.Id == id)!;

            return View(model);
        }






        [HttpPost]
        public IActionResult Delete(int id)
        {
          

            return Json(new { status = 200, Message = "Hotel successfully deleted" }); 
        }
    }
}
