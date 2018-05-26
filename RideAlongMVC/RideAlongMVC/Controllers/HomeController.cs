<<<<<<< HEAD
﻿using System;
=======
using System;
>>>>>>> 990fa695cddc800067b48bab1cb19ac03aa11f9d
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
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}