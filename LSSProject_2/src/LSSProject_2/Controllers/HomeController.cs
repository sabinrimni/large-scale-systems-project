using System;
using System.Diagnostics;
using LSSProject_2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LSSProject_2.Controllers
{
    public class HomeController : Controller
    {
        private static readonly IAdManager am = new AdManager();
        private static readonly  IParkingManager pm = new ParkingManager();

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(APIModel model)
        {

            EmailManager em = new EmailManager();
            try
            {
                em.sendEmail(model.email, "Parking Info", "llsproject@ucn.dk", "Wellcome", am.GetAdLink(), pm.GetParkingAddress(model.latitude,model.longitude));
            }
            catch (Exception e)
            {
                Debug.WriteLine("Failed to send email: " + e);
            }
            return View("Confirmation");
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
