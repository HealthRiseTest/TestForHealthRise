using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HealthRiseTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page. 123";

            return View();
        }
        [HttpPost]
        public ActionResult PasswordStrength()
        {
            // Get the variable
            string sPassword = Request["sPassword"].ToString();

            //Call the service (note: since this is in the same project, we call it
            // directly to avoid network time
            HealthRiseController controller = new HealthRiseController();

            ViewBag.Strength = controller.TestPasswordStrengthGet(sPassword); 
            return View();
        }
    }
}