using System;
using Microsoft.AspNetCore.Mvc;
using StayAzerbaijan.DAL;
using StayAzerbaijan.Entities;
using StayAzerbaijan.Models;

namespace StayAzerbaijan.Controllers
{
    public class ContactController : Controller
    {
        private readonly ProductDbContext _context;

        public ContactController(ProductDbContext context)
        {
            _context = context;
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMessage(string name, string email, string message)
        {
            if (ModelState.IsValid)
            {
              
                var newMessage = new Message
                {
                    Name = name,
                    Email = email,
                    Content = message,
                    SentAt = DateTime.Now
                };

                _context.Messages.Add(newMessage);
                _context.SaveChanges();

             
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("Contact");
            }
        }

    }
}
