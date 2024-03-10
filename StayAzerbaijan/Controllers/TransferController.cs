using Microsoft.AspNetCore.Mvc;
using StayAzerbaijan.DAL;
using StayAzerbaijan.Entities; 

namespace StayAzerbaijan.Controllers
{
    public class TransferController : Controller
    {
        private readonly ProductDbContext _context;

        public TransferController(ProductDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var transfers = _context.Transfers.ToList(); 
            return View(transfers);
        }
    }
}
