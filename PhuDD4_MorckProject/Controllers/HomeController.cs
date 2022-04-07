using PhuDD4_MorckProject.Areas.Admin.Controllers;
using PhuDD4_MorckProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhuDD4_MorckProject.Controllers
{
    public class HomeController : Controller
    {
        MockProjectEntities1 DB = new MockProjectEntities1();
       DungChung dungchung = new DungChung();
        // GET: Home
        public ActionResult Home(string loaisapxep, string id)
        {
            try
            {
                List<category> category = DB.categories.ToList();
                ViewBag.category = category;
                int id_category;
                List<product> List_product;
                switch (loaisapxep)
                {
                    case "category":
                        id_category = int.Parse(id);
                        ViewBag.category_id = id_category;
                        List_product = dungchung.product_theo_dm(id_category);
                        break;
                    case "ascending":
                        List_product = dungchung.product_tangdan();
                        break;
                    case "descending":
                        List_product = dungchung.product_giamdan();
                        break;
                    case "search":
                        List_product = dungchung.product_timkiem(id);
                        break;
                    default:
                        List_product = DB.products.ToList();
                        ViewBag.kt_all = "ALL";
                        break;
                }
                return View(List_product);
            }
            catch
            {
                return Redirect("/home");
            }
        }

        // GET: chitietsanpham
        public ActionResult Details_Product(string id)
        {
            try
            {
                int id_product = int.Parse(id);
                product product = dungchung.Find_product(id_product);
                return View(product);
            }
            catch
            {
                return RedirectToAction("Home");
            }
        }
    }
}