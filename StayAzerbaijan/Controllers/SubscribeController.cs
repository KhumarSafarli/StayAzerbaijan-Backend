//using Microsoft.AspNetCore.Mvc;
//using System.Net;
//using System.Net.Mail;

//namespace StayAzerbaijan.Controllers
//{
//    public class SubscribeController : Controller
//    {
//        [HttpPost]
//        public IActionResult Subscribe(string email)
//        {
//            try
//            {
//                using (var client = new SmtpClient("smtp.example.com"))
//                {
//                    client.Port = 587;
//                    client.Credentials = new NetworkCredential("khumarns@code.edu.az", "xumar98A!");
//                    client.EnableSsl = true;

//                    var message = new MailMessage();
//                    message.From = new MailAddress("khumarns@code.edu.az");
//                    message.To.Add(email);
//                    message.Subject = "Subscription Confirmation";
//                    message.Body = "Thank you for subscribing to our newsletter!";

//                    client.Send(message);
//                }

//                return RedirectToAction("SubscriptionSuccess");
//            }
//            catch (Exception ex)
//                return RedirectToAction("SubscriptionError");
//            }
//        }
//    }
//}
