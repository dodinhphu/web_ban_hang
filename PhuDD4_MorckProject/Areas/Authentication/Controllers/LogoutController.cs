using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhuDD4_MorckProject.Areas.Authentication.Controllers
{
    public class LogoutController : Controller
    {
        // GET: Authentication/Logout
        public ActionResult Logout()
        {
            Session.Remove("customer");
            return Redirect("/authentication/login");
        }
    }
}