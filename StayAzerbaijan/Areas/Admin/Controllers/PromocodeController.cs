using Microsoft.AspNetCore.Mvc;
using StayAzerbaijan.Areas.Admin.ViewModels;
using StayAzerbaijan.DAL;
using StayAzerbaijan.Entities;

namespace StayAzerbaijan.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PromocodeController:Controller
    {
        private readonly ProductDbContext _context;

        public PromocodeController(ProductDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Promocode> promocodes = _context.Promocodes.ToList();
            if (promocodes is null) return NotFound();
            return View(promocodes);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreatePromocodeVM Promocode)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Name", "");
                return View(Promocode);
            }

            bool existed = _context.Promocodes.Any(c => c.Code == Promocode.Code);
            if (existed) return View(Promocode);

            Promocode newPromocode = new Promocode
            {
                Code = Promocode.Code,
                DiscountAmount = Promocode.DiscountAmount
            };
            _context.Promocodes.Add(newPromocode);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var promocode= await _context.Promocodes.FindAsync(id);
            if (promocode == null)
            {
                return NotFound();
            }

            _context.Promocodes.Remove(promocode);
            await _context.SaveChangesAsync();

            return Json(new { status = 200, Message = "Promocode successfully deleted" });
        }

    }
}
