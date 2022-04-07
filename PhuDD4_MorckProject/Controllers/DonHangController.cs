using PhuDD4_MorckProject.Areas.Admin.Controllers;
using PhuDD4_MorckProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhuDD4_MorckProject.Controllers
{
    public class DonHangController : Controller
    {
        // GET: DonHang
        public ActionResult Index()
        {
            if (Session["customer"] != null)
            {
                MockProjectEntities1 DB = new MockProjectEntities1();
                List<don_dat_hang> listDonHang = new List<don_dat_hang>();
                customer customer = (customer)Session["customer"];
                listDonHang = DB.don_dat_hang.Where(c => c.customer_id == customer.username).ToList();
                return View(listDonHang);
            }
            else
            {
                return Redirect("~/authentication/login");
            }
        }
        // GET: detailsorder/id
        public ActionResult DetailsOrder(string id)
        {
            try
            {
                if (Session["customer"] != null)
                {
                    int id_order = int.Parse(id);
                    MockProjectEntities1 DB = new MockProjectEntities1();
                    List<don_hang_chitiet> listDonHangChitiet = new List<don_hang_chitiet>();
                    listDonHangChitiet = DB.don_hang_chitiet.Where(c => c.order_id == id_order).ToList();
                    return View(listDonHangChitiet);
                }
                else
                {
                    return Redirect("~/authentication/login");
                }
            }
            catch
            {
                return Redirect("~/");
            }
        }

        /*
                // POST: DonHang/create
                [HttpPost]
                public ActionResult create(FormCollection data)
                {
                    JsonResult trave = new JsonResult();
                    if (Session["customer"] != null)
                    {
                        try
                        {
                            don_dat_hang donhang = new don_dat_hang();
                            donhang.customer_id = data["customer_id"];
                            donhang.customer_name = data["customer_name"];
                            donhang.customer_address = data["customer_address"];
                            donhang.customer_phone = data["customer_phone"];
                            donhang.date_order = DateTime.Now;
                            donhang.total_price = int.Parse(data["total_price"].ToString());
                            donhang.status = false;

                            MockProjectEntities1 DB = new MockProjectEntities1();
                            DB.Set(donhang.GetType()).Add(donhang);
                            int kq = DB.SaveChanges();
                            int id = donhang.order_id;
                            if (kq > 0)
                            {
                                trave.Data = new
                                {
                                    status = "OK",
                                    messeger = "Bạn Đã Đặt Hàng Thành Công !",
                                    id_donhang = id,
                                };
                                return Json(trave, JsonRequestBehavior.AllowGet);
                            }
                            else
                            {
                                trave.Data = new
                                {
                                    status = "FALSE",
                                    messeger = "Đặt Hàng Thất Bại !"
                                };
                                return Json(trave, JsonRequestBehavior.AllowGet);
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
                            messeger = "Chưa Đăng Nhập !"
                        };
                        return Json(trave, JsonRequestBehavior.AllowGet);
                    }
                }
                // POST: DonHang/CreateDetails
                public ActionResult CreateDetails(FormCollection data)
                {
                    JsonResult trave = new JsonResult();
                    if (Session["customer"] != null)
                    {
                        try
                        {
                            DungChung dungchung = new DungChung();
                            int id_order = int.Parse(data["id_donhang"].ToString());
                            // lấy tất cả các sản phẩm trog giỏ hàng của customer
                            List<cart> list_cart = dungchung.tim_sp_giohang3(data["customer_id"]);
                            List<don_hang_chitiet> list_donhang_chitiet = new List<don_hang_chitiet>();
                            for (int i = 0; i < list_cart.Count; i++)
                            {
                                don_hang_chitiet donhang_chitiet = new don_hang_chitiet();
                                product product = dungchung.Find_product(list_cart[i].product_id);
                                donhang_chitiet.order_id = id_order;
                                donhang_chitiet.product_id = list_cart[i].product_id;
                                donhang_chitiet.product_name = product.product_name;
                                donhang_chitiet.product_number = list_cart[i].product_number;
                                donhang_chitiet.product_dongia = product.product_price;
                                list_donhang_chitiet.Add(donhang_chitiet);
                            }
                            dungchung.Creates(list_donhang_chitiet);
                            int kt = dungchung.save();
                            if (kt > 0)
                            {
                                trave.Data = new
                                {
                                    status = "OK",
                                    messeger = "Đặt Hàng Thành Công !"
                                };
                                return Json(trave, JsonRequestBehavior.AllowGet);
                            }
                            else
                            {
                                trave.Data = new
                                {
                                    status = "FALSE",
                                    messeger = "Đặt Hàng Thất Bại !"
                                };
                                return Json(trave, JsonRequestBehavior.AllowGet);
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
                            messeger = "Chưa Đăng Nhập !"
                        };
                        return Json(trave, JsonRequestBehavior.AllowGet);
                    }
                }

        */

        // POST: DonHang/MuaHang
        public ActionResult MuaHang(FormCollection data)
        {
            JsonResult trave = new JsonResult();
            if (Session["customer"] != null)
            {
                try
                {
                    DungChung dungchung = new DungChung();
                    // tạo đơn hàng
                    don_dat_hang donhang = new don_dat_hang();
                    donhang.customer_id = data["customer_id"];
                    donhang.customer_name = data["customer_name"];
                    donhang.customer_address = data["customer_address"];
                    donhang.customer_phone = data["customer_phone"];
                    donhang.date_order = DateTime.Now;
                    donhang.total_price = int.Parse(data["total_price"].ToString());
                    donhang.status = false;

                    dungchung.Create(donhang);
                    int kq1 = dungchung.save();
                    if (kq1 > 0)
                    {
                        int id_order = donhang.order_id;
                        // thêm đơn hàng chi tiết 
                        // lấy tất cả các sản phẩm trog giỏ hàng của customer
                        List<cart> list_cart = dungchung.tim_sp_giohang3(data["customer_id"]);
                        List<don_hang_chitiet> list_donhang_chitiet = new List<don_hang_chitiet>();
                        for (int i = 0; i < list_cart.Count; i++)
                        {
                            don_hang_chitiet donhang_chitiet = new don_hang_chitiet();
                            product product = dungchung.Find_product(list_cart[i].product_id);
                            donhang_chitiet.order_id = id_order;
                            donhang_chitiet.product_id = list_cart[i].product_id;
                            donhang_chitiet.product_name = product.product_name;
                            donhang_chitiet.product_number = list_cart[i].product_number;
                            donhang_chitiet.product_dongia = product.product_price;
                            list_donhang_chitiet.Add(donhang_chitiet);
                        }
                        dungchung.Creates(list_donhang_chitiet);
                        int kq2 = dungchung.save();
                        if (kq2 > 0)
                        {
                            // xóa các sản phẩm trong giỏ hàng
                            string cart_id = data["customer_id"].ToString().Trim();
                            List<cart> cart = dungchung.tim_sp_giohang3(cart_id);
                            for (int i = 0; i < cart.Count; i++)
                            {
                                dungchung.Delete(cart[i]);
                            }
                            // lưu
                            int kq = dungchung.save();
                            if (kq > 0)
                            {

                                int sl_item_cart = dungchung.cout_item_cart(cart_id);
                                Session["cout_item_cart"] = sl_item_cart;
                                trave.Data = new
                                {
                                    status = "OK",
                                    messeger = "Bạn Đã Đặt Hàng Thành Công !",
                                    cout_cart = sl_item_cart,
                                };
                                return Json(trave, JsonRequestBehavior.AllowGet);
                            }
                            else
                            {
                                trave.Data = new
                                {
                                    status = "FALSE",
                                    messeger = "Đặt Hàng Thất Bại !"
                                };
                                return Json(trave, JsonRequestBehavior.AllowGet);
                            }
                        }
                        else
                        {
                            trave.Data = new
                            {
                                status = "FALSE",
                                messeger = "Đặt Hàng Thất Bại !"
                            };
                            return Json(trave, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        trave.Data = new
                        {
                            status = "FALSE",
                            messeger = "Đặt Hàng Thất Bại !"
                        };
                        return Json(trave, JsonRequestBehavior.AllowGet);
                    }

                }
                catch
                {
                    trave.Data = new
                    {
                        status = "FALSE",
                        messeger = "Đặt Hàng Không Thành Công !"
                    };
                    return Json(trave, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                trave.Data = new
                {
                    status = "FALSE",
                    messeger = "Chưa Đăng Nhập !"
                };
                return Json(trave, JsonRequestBehavior.AllowGet);
            }
        }
    }
}