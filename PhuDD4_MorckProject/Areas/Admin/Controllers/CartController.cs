using PhuDD4_MorckProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhuDD4_MorckProject.Areas.Admin.Controllers
{
    public class CartController : BaseController
    {
        MockProjectEntities1 DB = new MockProjectEntities1();
        // GET: Admin/Cart
        public ActionResult ListCart()
        {
            try
            {

                List<don_dat_hang> list_donhang = DB.don_dat_hang.ToList();
                return View(list_donhang);
            }
            catch
            {
                return Redirect("~/");
            }
        }

        // GET: Admin/details/id
        public ActionResult detailsCart(string id)
        {
            try
            {
                int id_order = int.Parse(id);
                List<don_hang_chitiet> list_donhang_chitiet = DB.don_hang_chitiet.Where(c => c.order_id == id_order).ToList();
                return View(list_donhang_chitiet);
            }
            catch
            {
                return Redirect("~/");
            }
        }


        // POST: Admin/UpdateStatus
        [HttpPost]
        public ActionResult updateStatus(FormCollection data)
        {
            JsonResult trave = new JsonResult();
            try
            {
                DungChung dungchung = new DungChung();
                int order_id = int.Parse(data["order_id"]);
                string customer_id = data["customer_id"];
                don_dat_hang donhang = dungchung.tim_don_hang(order_id, customer_id);
                donhang.status = !donhang.status;
                int kq = dungchung.save();
                if (kq > 0)
                {
                    trave.Data = new
                    {
                        status = "OK",
                        messeger = "Cập Nhật Thành Công",
                        status_new = donhang.status
                    };
                    return Json(trave, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    trave.Data = new
                    {
                        status = "FALSE",
                        messeger = "Cập Nhật Không Thành Công",
                    };
                    return Json(trave, JsonRequestBehavior.AllowGet);
                }
            }
            catch
            {
                trave.Data = new
                {
                    status = "FALSE",
                    messeger = "Lỗi Thao Tác"
                };
                return Json(trave, JsonRequestBehavior.AllowGet);
            }

        }
    }
}