using System;
using System.Diagnostics;
using LSSProject_2.Models;
using Microsoft.AspNetCore.Mvc;

namespace LSSProject_2.Controllers
{
    [Route("api/[controller]")]
    public class APIController : Controller
    {
        private static readonly IAdManager am = new AdManager();
        private static  readonly IParkingManager pm = new ParkingManager();
        [HttpPost]
        public IActionResult GetParking(APIModel apiModel)
        {
            var result = Accepted();
            var em = new EmailManager();
            try
            {
                em.sendEmail(apiModel.email, "Parking Info", "llsproject@ucn.dk", "Wellcome", am.GetAdLink(), pm.GetParkingAddress(apiModel.latitude, apiModel.longitude));
            }
            catch (Exception e)
            {
                Debug.WriteLine("Failed to send email: " + e);
            }
            return result;
        }
    }
}
