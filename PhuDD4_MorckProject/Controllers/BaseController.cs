using PhuDD4_MorckProject.Models;
using System.Web.Mvc;

namespace PhuDD4_MorckProject.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
            var customer = (customer)System.Web.HttpContext.Current.Session["customer"];
            if (customer == null)
            {
                System.Web.HttpContext.Current.Response.Redirect("/authentication/login");
            }
        }
    }
}