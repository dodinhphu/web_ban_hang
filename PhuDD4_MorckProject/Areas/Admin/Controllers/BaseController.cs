using PhuDD4_MorckProject.Models;
using System.Web.Mvc;

namespace PhuDD4_MorckProject.Areas.Admin.Controllers
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
            else if(int.Parse(customer.permission.ToString()) != 0)
            {
                System.Web.HttpContext.Current.Response.Redirect("/home");
            }
        }
    }
}