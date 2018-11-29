using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarolineBergen.Models;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Localization;
using System.Net.Mail;
using System.Net;

namespace CarolineBergen.Controllers
{
    public class HomeController : Controller
    {
        private const string personalToMail = "thisisnotarealemail@gmail.com";//"splitkegan@gmail.com";//"sujitc19@gmail.com";//caroline.bergen@outlook.com

        public IActionResult Index()
        {
            //this is a test...
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Contact()
        {
            if (TempData["EmailSentStatus"] != null)
            {
                ViewBag.EmailSentStatus = TempData["EmailSentStatus"];
            }
            else
            {
                ViewBag.EmailSentStatus = false;
            }
            ViewData["Message"] = "Contact Information";
            return View(new ContactViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Contact([FromForm] ContactViewModel model)
        {
            ViewData["Message"] = "Contact Information";
            if (!ModelState.IsValid)
            {
                ViewBag.EmailSentStatus = false;
                return View();
            }
            else
            {
                MailAddress From = new MailAddress(model.Email);
                MailAddress To = new MailAddress(personalToMail);
                MailMessage message = new MailMessage(From, To);
                message.Subject = $"{model.Name}'s Request via site mailer";
                message.Body = model.BodyMessage;

                try
                {
                    var smtp = new System.Net.Mail.SmtpClient();
                    {
                        smtp.Host = "smtp.gmail.com";
                        smtp.Port = 587;
                        smtp.Credentials = new NetworkCredential(model.Email, model.Password);
                        smtp.EnableSsl = true;
                        smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                        smtp.Timeout = 20000;
                    }
                    
                    smtp.Send(message);
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = ex.Message + "\n" + ex.StackTrace;
                    ViewBag.EmailSentStatus = false;
                    return View();
                }

                TempData["EmailSentStatus"] = true;
                return RedirectToAction("Contact");
            }
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
