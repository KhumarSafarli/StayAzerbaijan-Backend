using Microsoft.AspNetCore.Mvc;
using StayAzerbaijan.Areas.Admin.ViewModels;
using StayAzerbaijan.DAL;
using StayAzerbaijan.Entities;
using System.Collections.Generic;
using System.Linq;

namespace StayAzerbaijan.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ProductDbContext _context;

        public CategoryController(ProductDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Category> categories = _context.Categories.ToList();
            if (categories is null) return NotFound();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateCategoryVM category)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Name", "");
                return View(category);
            }

            bool existed = _context.Categories.Any(c => c.Name == category.Name);
            if (existed) return View(category);

            Category newCategory = new Category
            {
                Name = category.Name
            };
            _context.Categories.Add(newCategory);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int id)
        {
            if (id == 0) return BadRequest();

            Category category = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null) return NotFound();

            return View(category);
        }

        [HttpPost]
        public IActionResult Update(int id, Category category)
        {
            if (id == 0) return BadRequest();

            bool existed = _context.Categories.Any(c => c.Name == category.Name);
            if (existed == true)
            {
                ModelState.AddModelError("Name", "Bu ada uygun category movcuddur");
                return View(category);
            }

            Category existedCategory = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (existedCategory == null) return NotFound();

            existedCategory.Name = category.Name;
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return Json(new { status = 200, Message = "Hotel successfully deleted" });
        }

    }
}
