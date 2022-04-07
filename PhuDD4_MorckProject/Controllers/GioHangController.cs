using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhuDD4_MorckProject.Models;
using System.Web.Mvc;
using System.Data;
using PhuDD4_MorckProject.Areas.Admin.Controllers;

namespace PhuDD4_MorckProject.Controllers
{
    public class GioHangController : BaseController
    {
        DungChung dungchung = new DungChung();
        MockProjectEntities1 DB = new MockProjectEntities1();
        // GET: GioHang/index
        public ActionResult Index()
        {
            if (Session["customer"] != null)
            {
                var customer = (customer)Session["customer"];
                MockProjectEntities1 DB = new MockProjectEntities1();
                var cart = (from c in DB.carts
                            join p in DB.products
                on c.product_id equals (p.product_id)
                            where c.cart_id == customer.username
                            select new CartProduct()
                            {
                                cart_id = c.cart_id,
                                Product_id = c.product_id,
                                Product_img = p.product_img,
                                Product_name = p.product_name,
                                Product_price = p.product_price,
                                Product_number = c.product_number
                            }
                ).ToList();
                ViewBag.tongslsp = cart.Count;
                return View(cart);
            }
            else
            {
                return Redirect("/authentication/login");
            }
        }

        // POST: GioHang/add
        [HttpPost]
        public ActionResult Add_cart(FormCollection data)
        {
            JsonResult trave = new JsonResult();
            if (Session["customer"] != null)
            {
                try
                {
                    customer customer = (customer)Session["customer"];
                    string cart_id = customer.username.ToString().Trim();
                    int product_id = int.Parse(data["product_id"].ToString());
                    int product_number = int.Parse(data["product_number"].ToString());
                    // Kiễm tra
                    MockProjectEntities1 DB = new MockProjectEntities1();
                    cart cart = DB.carts.Where(c => c.cart_id == cart_id && c.product_id == product_id).FirstOrDefault();

                    // Nếu sản phẩm chưa có trong giỏ hàng của khách hàng thì thêm vào giỏ hàng
                    if (cart == null)
                    {
                        cart new_cart = new cart();
                        new_cart.cart_id = cart_id;
                        new_cart.product_id = product_id;
                        new_cart.product_number = product_number;
                        DB.Set(new_cart.GetType()).Add(new_cart);
                        int kq = DB.SaveChanges();
                        if (kq > 0)
                        {
                            int sl_item_cart = DB.carts.Where(c => c.cart_id == cart_id).Count();
                            Session["cout_item_cart"] = sl_item_cart;
                            trave.Data = new
                            {
                                status = "OK",
                                messeger = "Bạn Đã Thêm Sản Phẩm Vào Giỏ Hàng Thành Công",
                                cout_cart = sl_item_cart,
                            };
                          
                            return Json(trave, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            trave.Data = new
                            {
                                status = "FALSE",
                                messeger = "Thêm Sản Phẩm Vào Giỏ Hàng Không Thành Công !"
                            };
                            return Json(trave, JsonRequestBehavior.AllowGet);
                        }
                    }
                    // Nếu như sản phẩm đã tồn tại trong giỏ hàng của khách hàng
                    else
                    {
                        int soluongcu = (int)cart.product_number;
                        cart.product_number = soluongcu + product_number;
                        int kq = DB.SaveChanges();
                        if (kq > 0)
                        {
                            trave.Data = new
                            {
                                status = "OK",
                                messeger = "Bạn Đã Thêm Sản Phẩm Vào Giỏ Hàng Thành Công"
                            };
                            return Json(trave, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            trave.Data = new
                            {
                                status = "FALSE",
                                messeger = "Thêm Sản Phẩm Vào Giỏ Hàng Không Thành Công !"
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
                        messeger = "Thêm Sản Phẩm Vào Giỏ Hàng Không Thành Công !"
                    };
                    return Json(trave, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                trave.Data = new
                {
                    status = "FALSE",
                    messeger = "Thêm Sản Phẩm Vào Giỏ Hàng Không Thành Công !"
                };
                return Json(trave, JsonRequestBehavior.AllowGet);
            }
        }

        // POST: GioHang/remove
        [HttpPost]
        public ActionResult Remove(FormCollection data)
        {
            JsonResult trave = new JsonResult();
           try
            {
                string cart_id = data["cart_id"].ToString().Trim();
                int product_id = int.Parse(data["product_id"]);
                cart cart = dungchung.tim_sp_giohang2(cart_id, product_id);
                string product_number = cart.product_number.ToString();
                dungchung.Delete(cart);
                int kt = dungchung.save();
                if(kt >0)   
                {
                    int sl_item_cart = DB.carts.Where(c => c.cart_id == cart_id).Count();
                    Session["cout_item_cart"] = sl_item_cart;
                    trave.Data = new
                    {
                        status = "OK",
                        messeger = "Xóa Sản Phẩm Khỏi Giỏ Hàng Thành Công !",
                        cout_cart = sl_item_cart,
                    };
                    return Json(trave, JsonRequestBehavior.AllowGet);
                }
                else
                {

                    trave.Data = new
                    {
                        status = "FALSE",
                        messeger = "Xóa Sản Phẩm Khỏi Giỏ Hàng Không Thành Công !"
                    };
                    return Json(trave, JsonRequestBehavior.AllowGet);
                }
            }
            catch
            {
                trave.Data = new
                {
                    status = "FALSE",
                    messeger = "Xóa Sản Phẩm Khỏi Giỏ Hàng Không Thành Công !"
                };
                return Json(trave, JsonRequestBehavior.AllowGet);
            }
        }


    }
}