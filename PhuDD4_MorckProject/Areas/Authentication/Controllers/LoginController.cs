using PhuDD4_MorckProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhuDD4_MorckProject.Areas.Authentication.Controllers
{
    public class LoginController : BaseController
    {
        // GET: Authentication/Login
        public ActionResult Index()
        {
            return View();
        }

        // POST: Authentication/Login
        [HttpPost]
        public ActionResult Login(FormCollection data )
        {
            JsonResult trave = new JsonResult();
            try
            {
                string username = data["username"];
                string password = data["password"];
                if(string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    trave.Data = new
                    {
                        status = "FALSE",
                        messeger = "Không được Bỏ Trống Các Trường"
                    };
                    return Json(trave, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    MockProjectEntities1 DB = new MockProjectEntities1();
                    DungChung dungchung = new DungChung();
                    customer customer = dungchung.tim_customer(username);
                    if(customer == null)
                    {
                        trave.Data = new
                        {
                            status = "FALSE",
                            messeger = "Tài Khoản Không Chính Xác"
                        };
                        return Json(trave, JsonRequestBehavior.AllowGet);
                    }
                    else if(customer.password != password)
                    {
                        trave.Data = new
                        {
                            status = "FALSE",
                            messeger = "Mật Khẩu Không Chính Xác"
                        };
                        return Json(trave, JsonRequestBehavior.AllowGet);
                    }

                    trave.Data = new
                     {
                        status = "OK",
                        messeger = "Đăng Nhập Thàng Công"
                     };
                    int sl_item_cart = DB.carts.Where(c => c.cart_id == customer.username).Count();
                    Session["cout_item_cart"] = sl_item_cart;
                    var user = (object)customer;
                    Session["customer"] = user;
                    return Json(trave, JsonRequestBehavior.AllowGet);
                }
               
            }
            catch
            {
                trave.Data = new
                {
                    status = "FALSE",
                    messeger = "Đăng Nhập Không Thành Công"
                };
                return Json(trave, JsonRequestBehavior.AllowGet);
            }
        }

       
    }
}