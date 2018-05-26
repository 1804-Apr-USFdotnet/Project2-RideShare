using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace RideAlongAPI.Controllers
{
    public class GetUserName
    {
        public static string Name(IPrincipal user)
        {
            return user == null ? HttpContext.Current.User.Identity.Name : user.Identity.Name;
        }
    }
}