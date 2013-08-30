using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhoneContactMvcApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Hello welcome to my Mobile jQuery project";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "This app will has an account feature as well as some minor functionality to control the AdventureWorks database";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact me at ksmith8560@gmail.com or by phone 970-219-4463";

            return View();
        }
    }
}
