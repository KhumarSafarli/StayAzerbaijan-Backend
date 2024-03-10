using Microsoft.AspNetCore.Mvc;
using StayAzerbaijan.DAL;

namespace StayAzerbaijan.Controllers
{
    public class ResultController:Controller
    {
        private readonly ProductDbContext _context;

        public ResultController(ProductDbContext context)
        {
            _context = context;
        }

        public IActionResult Searchresult()
        {
            return View();
        }
    }
}
