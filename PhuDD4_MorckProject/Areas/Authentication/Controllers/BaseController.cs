using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhuDD4_MorckProject.Models;
using System.Web.Mvc;

namespace PhuDD4_MorckProject.Areas.Authentication.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
            if (System.Web.HttpContext.Current.Session["customer"] != null)
            {
                System.Web.HttpContext.Current.Response.Redirect("/home");
            }
        }
    }
}