using PhuDD4_MorckProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PhuDD4_MorckProject.Areas.Authentication.Controllers
{
  
    public class RegisterController : Controller
    {
        MockProjectEntities1 DB = new MockProjectEntities1();
        DungChung dungchung = new DungChung();
        // GET: Authentication/Register
        public ActionResult Create()
        {
            
            if ( Session["customer"] == null)
            {
               
                return View();
            }
            else
            {

                return Redirect("/");
            }    
            
        }
        // GET: Authentication/Register/id
        public ActionResult Update()
        {
            customer customer = (customer)Session["customer"];
            if(customer == null)
            {
                return Redirect("/Authentication/login");
            }
            else
            {
                return View(customer);
            }
            
        }

        // POST: Authentication/Register/create
        [HttpPost]
        public ActionResult Create(FormCollection data)
        {
            JsonResult trave = new JsonResult();
            try
            {
                string username = data["username"];
                string password = data["password"];
                string first_name = data["first_name"];
                string last_name = data["last_name"];
                string address = data["address"];
                DateTime dayofbirth = Convert.ToDateTime(data["dayofbirth"]);
                int number_phone = int.Parse(data["number_phone"]);
                int permission = 1;
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password)
                    || string.IsNullOrEmpty(first_name) || string.IsNullOrEmpty(last_name)
                    || string.IsNullOrEmpty(address) || dayofbirth == null || number_phone == null)
                {
                    trave.Data = new
                    {
                        status = "FALSE",
                        messeger = "Không được Bỏ Trống Các Trường"
                    };
                    return Json(trave, JsonRequestBehavior.AllowGet);
                }
                else if (dungchung.tim_customer(username)!=null)
                {
                    trave.Data = new
                    {
                        status = "FALSE",
                        messeger = "Người Dùng Đã Tồn Tại"
                    };
                    return Json(trave, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    customer new_customer = new customer();
                    new_customer.username = username;
                    new_customer.password = password;
                    new_customer.first_name = first_name;
                    new_customer.last_name = last_name;
                    new_customer.address = address;
                    new_customer.dayofbirth = dayofbirth;
                    new_customer.number_phone = number_phone;
                    new_customer.permission = permission;

                    dungchung.Create(new_customer);
                    int kq = dungchung.save();
                    if (kq > 0)
                    {
                        trave.Data = new
                        {
                            status = "OK",
                            messeger = "Tạo Thành Công Tài Khoản "+username
                        };
                        return Json(trave, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        trave.Data = new
                        {
                            status = "FALSE",
                            messeger = "Tạo Tài Khoản Không Thành Công"
                        };
                        return Json(trave, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            catch
            {
                trave.Data = new
                {
                    status = "FALSE",
                    messeger = "Đăng Kí Không Thành Công. Sai Kiểu Dữ Liệu"
                };
                return Json(trave, JsonRequestBehavior.AllowGet);
            }
            
        }

        [HttpPost]
        public ActionResult Update(FormCollection data)
        {
            JsonResult trave = new JsonResult();
            try
            {
                string username = data["username"];
                string password = data["password"];
                string first_name = data["first_name"];
                string last_name = data["last_name"];
                string address = data["address"];
                DateTime dayofbirth = Convert.ToDateTime(data["dayofbirth"]);
                int number_phone = int.Parse(data["number_phone"]);
                int permission = 1;
                customer new_customer = dungchung.tim_customer(username);
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password)
                    || string.IsNullOrEmpty(first_name) || string.IsNullOrEmpty(last_name)
                    || string.IsNullOrEmpty(address) || dayofbirth == null || number_phone == null)
                {
                    trave.Data = new
                    {
                        status = "FALSE",
                        messeger = "Không được Bỏ Trống Các Trường"
                    };
                    return Json(trave, JsonRequestBehavior.AllowGet);
                }
                else if (new_customer == null)
                {
                    trave.Data = new
                    {
                        status = "FALSE",
                        messeger = "Không Tìm Thấy Tài Khoản"
                    };
                    return Json(trave, JsonRequestBehavior.AllowGet);
                }
                else
                { 
                    new_customer.username = username;
                    new_customer.password = password;
                    new_customer.first_name = first_name;
                    new_customer.last_name = last_name;
                    new_customer.address = address;
                    new_customer.dayofbirth = dayofbirth;
                    new_customer.number_phone = number_phone;
                    new_customer.permission = permission;

                    
                    int kq = dungchung.save();
                    if (kq > 0)
                    {
                        Session.Remove("customer");
                        Session["customer"] = new_customer;
                        trave.Data = new
                        {
                            status = "OK",
                            messeger = "Câp Nhật Thành Công Tài Khoản " + username
                        };
                        return Json(trave, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        trave.Data = new
                        {
                            status = "FALSE",
                            messeger = "Cập Nhật Tài Khoản Không Thành Công"
                        };
                        return Json(trave, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            catch
            {
                trave.Data = new
                {
                    status = "FALSE",
                    messeger = "Đăng Kí Không Thành Công"
                };
                return Json(trave, JsonRequestBehavior.AllowGet);
            }

        }
        //------------------------------------------------------------------------------------------------

    }
}