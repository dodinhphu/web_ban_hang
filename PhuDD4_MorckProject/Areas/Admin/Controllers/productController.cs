using PhuDD4_MorckProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhuDD4_MorckProject.Areas.Admin.Controllers
{
    public class productController : BaseController
    {
        MockProjectEntities1 DB = new MockProjectEntities1();
        DungChung dungchung = new DungChung();
        // GET: Admin/product/listProduct
        public ActionResult listProduct()
        {
            try
            {
                List<product> product = (from p in DB.products
                                         orderby p.product_id descending
                                         select p
                                       ).ToList();
                //List<product> product = DB.products.ToList();
                List<category> list_category = DB.categories.ToList();
                ViewBag.list_category = list_category;
                return View(product);
            }
            catch
            {
                return Redirect("~/");
            }
        }

        // GET: Admin/product/createProduct
        public ActionResult createProduct()
        {
            try
            {
                List<category> list_category = DB.categories.ToList();
                return View(list_category);
            }
            catch
            {
                return Redirect("~/");
            }
        }

        // GET: Admin/product/UpdateProduct
        public ActionResult UpdateProduct(string id)
        {
            try
            {
                int produc_id = int.Parse(id);
                product product = dungchung.Find_product(produc_id);
                // lấy tất cã  danh mục
                List<category> list_category = DB.categories.ToList();
                // lấy id danh mục cũ
                int id_dm = dungchung.Find((int)product.category_id).category_id;
                ViewBag.list_category = list_category;
                ViewBag.id_dm_cu = id_dm;
                return View(product);
            }
            catch
            {
                return Redirect("~/");
            }
        }



        // POST: Admin/product/CreateProduct
        [HttpPost]
        public ActionResult CreateProduct(FormCollection formdata, HttpPostedFileBase anh)
        {
            JsonResult trave = new JsonResult();
            product product = new product();
            try
            {
                product.product_name = formdata["product_name"];
                product.product_short_description = formdata["product_short_description"];
                product.product_description = formdata["product_description"];
                product.origin = formdata["product_xuatxu"];
                product.trademark = formdata["product_thuonghieu"];

                // ------------------ 

                product.category_id = int.Parse(formdata["category_id"]);
                product.product_price = int.Parse(formdata["product_price"]);
                product.number = int.Parse(formdata["product_number"]);
                if (product.product_price<0 || product.number<=0)
                {
                    trave.Data = new
                    {
                        status = "FALSE",
                        messeger = "Thêm Sản Phẩm Không Thành Công"
                    };
                    return Json(trave, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    product.CREATE_date = Convert.ToDateTime(formdata["product_ngaytao"]);
                    if (product.product_name == null || product.category_id == null
                   || product.product_price == null || product.CREATE_date == null
                   || product.product_short_description == null || product.product_description == null
                   || product.number == null || product.origin == null
                   || product.trademark == null)
                    {
                        trave.Data = new
                        {
                            status = "FALSE",
                            messeger = "Thêm Sản Phẩm Không Thành Công"
                        };
                        return Json(trave, JsonRequestBehavior.AllowGet);
                    }


                    //------------ thêm vào db
                    string ten_anh = "SanPham" + product.category_id.ToString().Trim() + "_" + product.product_price.ToString().Trim() + anh.FileName;
                    product.product_img = ten_anh;
                    dungchung.Create(product);
                    int kq = dungchung.save();
                    if (kq > 0)
                    {
                        //---thêm anh
                        string _path = Path.Combine(Server.MapPath("~/Public/img/img_product"), ten_anh);
                        anh.SaveAs(_path);
                        //----------------
                        product.product_img = ten_anh;
                        trave.Data = new
                        {
                            status = "OK",
                            messeger = "Thêm Thành Công Sản Phẩm " + formdata["product_name"],
                        };
                        return Json(trave, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        trave.Data = new
                        {
                            status = "FALSE",
                            messeger = "Thêm Không Thành Công",
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
                    messeger = "Sai Định Dạng"
                };
                return Json(trave, JsonRequestBehavior.AllowGet);
            }
        }



        // POST: Admin/product/UpdateProduct
        [HttpPost]
        public ActionResult UpdateProduct(FormCollection formdata, HttpPostedFileBase anh)
        {
            JsonResult trave = new JsonResult();
            try
            {
                int product_id = int.Parse(formdata["product_id"]);
                product product = dungchung.Find_product(product_id);

                product.product_name = formdata["product_name"];
                product.product_short_description = formdata["product_short_description"];
                product.product_description = formdata["product_description"];
                product.origin = formdata["product_xuatxu"];
                product.trademark = formdata["product_thuonghieu"];
                product.category_id = int.Parse(formdata["category_id"]);
                product.product_price = int.Parse(formdata["product_price"]);
                product.number = int.Parse(formdata["product_number"]);
                if (product.product_price < 0 || product.number <= 0)
                {
                    trave.Data = new
                    {
                        status = "FALSE",
                        messeger = "Cập Nhật Sản Phẩm Không Thành Công"
                    };
                    return Json(trave, JsonRequestBehavior.AllowGet);
                }
                    product.CREATE_date = Convert.ToDateTime(formdata["product_ngaytao"]);

                // --------------------------------
                if (product.product_name == null || product.category_id == null
                    || product.product_price == null || product.CREATE_date == null
                    || product.product_short_description == null || product.product_description == null
                    || product.number == null || product.origin == null
                    || product.trademark == null)
                {
                    trave.Data = new
                    {
                        status = "FALSE",
                        messeger = "Cập Nhật Sản Phẩm Không Thành Công"
                    };
                    return Json(trave, JsonRequestBehavior.AllowGet);
                }
                // xóa ảnh cũ
                string fullpath = Request.MapPath("~/Public/img/img_product/" + product.product_img);
                if (System.IO.File.Exists(fullpath))
                {
                    System.IO.File.Delete(fullpath);
                }

                //------------ thêm vào db
                string ten_anh = "SanPham" + product.category_id.ToString().Trim() + "_" + product.product_price.ToString().Trim() + anh.FileName;
                product.product_img = ten_anh;
                int kq = dungchung.save();
                if (kq > 0)
                {
                    //---thêm anh
                    string _path = Path.Combine(Server.MapPath("~/Public/img/img_product"), ten_anh);
                    anh.SaveAs(_path);
                    //----------------
                    product.product_img = ten_anh;
                    trave.Data = new
                    {
                        status = "OK",
                        messeger = "Cập Nhật Thành Công Sản Phẩm " + formdata["product_name"]
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
                    messeger = "Sai Định Dạng"
                };
                return Json(trave, JsonRequestBehavior.AllowGet);
            }

        }


        // POST: Admin/Category/DeleteProduct
        [HttpPost]
        public ActionResult DeleteProduct(FormCollection data)
        {
            JsonResult trave = new JsonResult();
            product product = dungchung.Find_product(int.Parse(data["product_id"]));
            if (product == null)
            {
                trave.Data = new
                {
                    status = "FALSE",
                    messeger = "Không Tìm Thấy Sản Phẩm Cần Xóa"
                };
                return Json(trave, JsonRequestBehavior.AllowGet);
            }
            else
            {
                dungchung.Delete(product);
                List<cart> listcart = dungchung.tim_sp_giohang(product.product_id);
                for (int i = 0; i < listcart.Count; i++)
                {
                    dungchung.Delete(listcart[i]);
                }
                int kt = dungchung.save();
                if (kt > 0)
                {
                    // xóa ảnh cũ
                    string fullpath = Request.MapPath("~/Public/img/img_product/" + product.product_img);
                    if (System.IO.File.Exists(fullpath))
                    {
                        System.IO.File.Delete(fullpath);
                    }
                    trave.Data = new
                    {
                        status = "OK",
                        messeger = "Đã Xóa Thành Công"
                    };
                    return Json(trave, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    trave.Data = new
                    {
                        status = "FALSE",
                        messeger = "Xóa Không Thành Công"
                    };
                    return Json(trave, JsonRequestBehavior.AllowGet);
                }
            }

        }
    }
}