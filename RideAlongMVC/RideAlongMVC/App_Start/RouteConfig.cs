<<<<<<< HEAD
﻿using System;
=======
using System;
>>>>>>> 990fa695cddc800067b48bab1cb19ac03aa11f9d
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RideAlongMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
<<<<<<< HEAD
                defaults: new { controller = "Share", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
=======
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
>>>>>>> 990fa695cddc800067b48bab1cb19ac03aa11f9d
