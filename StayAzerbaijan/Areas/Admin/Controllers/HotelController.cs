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



        [HttpGet]
        public IActionResult Update(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var model = _context.Hotels
                .Include(h => h.HotelCategories)
                    .ThenInclude(hc => hc.Category)
                .FirstOrDefault(h => h.Id == id);

            if (model == null)
            {
                return NotFound();
            }

           
            var categories = _context.Categories.ToList();

            var updateHotelVM = new UpdateHotelVM
            {
                Id = model.Id,
                Name = model.Name,
                Location = model.Location,
                PricePerNight = model.Price,
                Description = model.Description,
                Star = (int)model.Star,
                IsAvailableOnWeekend = model.IsAvailableOnWeekend,
                MainPhoto = null,
                Categories = categories, 
                HotelCategories = model.HotelCategories.ToList(),
                CategoryIds = model.HotelCategories.Select(hc => hc.CategoryId).ToList()
            };

            return View(updateHotelVM);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateHotelVM hotelVM)
        {
            if (!ModelState.IsValid)
            {
                hotelVM.Categories = _context.Categories.ToList();
                return View(hotelVM);
            }

            var hotel = await _context.Hotels
                .Include(h => h.HotelCategories)
                .FirstOrDefaultAsync(h => h.Id == hotelVM.Id);

            if (hotel == null)
            {
                return NotFound();
            }

            hotel.Name = hotelVM.Name;
            hotel.Location = hotelVM.Location;
            hotel.Price = hotelVM.PricePerNight;
            hotel.Description = hotelVM.Description;
            hotel.Star = hotelVM.Star;
            hotel.IsAvailableOnWeekend = hotelVM.IsAvailableOnWeekend;
            hotel.HotelCategories.Clear();
            foreach (var categoryId in hotelVM.CategoryIds)
            {
                hotel.HotelCategories.Add(new HotelCategory { CategoryId = categoryId });
            }
            if (hotelVM.MainPhoto != null)
            {
                string mainPhotoName = await hotelVM.MainPhoto.GeneratePhoto(_env.WebRootPath, "assets", "images");
                hotel.MainImgUrl = mainPhotoName;
            }

            if (hotelVM.SliderPhoto != null)
            {
                string sliderPhotoName = await hotelVM.SliderPhoto.GeneratePhoto(_env.WebRootPath, "assets", "images");
                hotel.sliderImgUrl= sliderPhotoName;
            }

            _context.Update(hotel);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var hotel = await _context.Hotels.FindAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }

            _context.Hotels.Remove(hotel);
            await _context.SaveChangesAsync();

            return Json(new { status = 200, Message = "Hotel successfully deleted" });
        }

    }
}
