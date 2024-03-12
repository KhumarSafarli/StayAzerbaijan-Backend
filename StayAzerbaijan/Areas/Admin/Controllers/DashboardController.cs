using Microsoft.AspNetCore.Mvc;

namespace StayAzerbaijan.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController:Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
