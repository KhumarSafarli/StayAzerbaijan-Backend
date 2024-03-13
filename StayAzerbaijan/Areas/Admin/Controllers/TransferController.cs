using Microsoft.AspNetCore.Mvc;
using StayAzerbaijan.DAL;
using StayAzerbaijan.Entities;
using StayAzerbaijan.Areas.Admin.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StayAzerbaijan.Helpers;

namespace StayAzerbaijan.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TransferController : Controller
    {
        private readonly ProductDbContext _context;
        private readonly IWebHostEnvironment _env;

        public TransferController(ProductDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index()
        {
            IEnumerable<Transfer> model = _context.Transfers.ToList();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTransferVM transferVM)
        {
            if (!ModelState.IsValid)
            {
                return View(transferVM);
            }

            Transfer newTransfer = new Transfer
            {
                Name = transferVM.Name,
                Price = transferVM.Price,
                Description = transferVM.Description,
                PaxCount = transferVM.PaxCount
            };

            if (transferVM.Image != null)
            {
                string imageName = await transferVM.Image.GeneratePhoto(_env.WebRootPath, "assets", "images");
                newTransfer.Image = imageName;
            }

            await _context.Transfers.AddAsync(newTransfer);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var existingTransfer = await _context.Transfers.FindAsync(id);
            if (existingTransfer == null)
            {
                return NotFound();
            }

            var updateTransferVM = new UpdateTransferVM
            {
                Id = existingTransfer.Id,
                Name = existingTransfer.Name,
                Price = existingTransfer.Price,
                Description = existingTransfer.Description,
                PaxCount = existingTransfer.PaxCount
            };

            return View(updateTransferVM);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateTransferVM transferVM)
        {
            if (!ModelState.IsValid)
            {
                return View(transferVM);
            }

            var existingTransfer = await _context.Transfers.FindAsync(transferVM.Id);
            if (existingTransfer == null)
            {
                return NotFound();
            }

            existingTransfer.Name = transferVM.Name;
            existingTransfer.Price = transferVM.Price;
            existingTransfer.Description = transferVM.Description;
            existingTransfer.PaxCount = transferVM.PaxCount;

            if (transferVM.Image != null)
            {
                string imageName = await transferVM.Image.GeneratePhoto(_env.WebRootPath, "assets", "images");
                existingTransfer.Image = imageName;
            }

            _context.Update(existingTransfer);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var transfer = await _context.Transfers.FindAsync(id);
            if (transfer == null)
            {
                return NotFound();
            }

            _context.Transfers.Remove(transfer);
            await _context.SaveChangesAsync();

            return Json(new { status = 200, Message = "Transfer successfully deleted" });
        }
    }
}
