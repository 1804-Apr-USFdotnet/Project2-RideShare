using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RideAlongMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "I'm Going on an Adventure!";

            return View();
        }

        public ActionResult Contact()
        {
            

            return View();
        }
    }
}