using PhuDD4_MorckProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhuDD4_MorckProject.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        MockProjectEntities1 DB = new MockProjectEntities1();
        DungChung dungchung = new DungChung();

        // GET: Admin/Category/List
        public ActionResult ListCategory()
        {
            try
            {
                List<category> category = DB.categories.ToList();
                return View(category);
            }
            catch
            {
                return Redirect("~/");
            }
        }

        // GET: Admin/Category/Create
        public ActionResult CreateCategory()
        {
            return View();
        }
        // GET: Admin/Category/update
        public ActionResult UpdateCategory(string id)
        {
            try
            {
                int category_id = int.Parse(id);
                category category = dungchung.Find(category_id);
                return View(category);
            }
            catch
            {
                return Redirect("~/");
            }
        }

        // POST: Admin/Category/CreateCategory
        [HttpPost]
        public ActionResult CreateCategory(FormCollection data)
        {
            category category = new category();
            JsonResult trave = new JsonResult();
            category.category_name = data["category_name"];
            if (category.category_name == null)
            {
                trave.Data = new
                {
                    status = "FALSE",
                    messeger = "Thêm Không Thành Công"
                };
                return Json(trave, JsonRequestBehavior.AllowGet);
            }
            try
            {
                category.CREATE_date = Convert.ToDateTime(data["CREATE_date"]);
            }
            catch
            {
                trave.Data = new
                {
                    status = "FALSE",
                    messeger = "Sai Định Dạng Ngày Giờ"
                };
                return Json(trave, JsonRequestBehavior.AllowGet);
            }
            dungchung.Create(category);
            int kq = dungchung.save();
            if (kq > 0)
            {
                trave.Data = new
                {
                    status = "OK",
                    messeger = "Thêm Thành Công Danh Mục " + data["category_name"]
                };
                return Json(trave, JsonRequestBehavior.AllowGet);
            }
            else
            {
                trave.Data = new
                {
                    status = "FALSE",
                    messeger = "Thêm Không Thành Công"
                };
                return Json(trave, JsonRequestBehavior.AllowGet);
            }

        }





        // POST: Admin/Category/UpdateCategory
        [HttpPost]
        public ActionResult UpdateCategory(FormCollection data)
        {
            JsonResult trave = new JsonResult();
            try
            {
                int category_id = int.Parse(data["category_id"]);
                // Tìm Category Trong DB
                category category = dungchung.Find(category_id);
                if (category == null)
                {
                    trave.Data = new
                    {
                        status = "FALSE",
                        messeger = "Không Tìm Thấy Danh Mục Cần Chỉnh Sửa"
                    };
                    return Json(trave, JsonRequestBehavior.AllowGet);
                }

                string category_name_new = data["category_name_new"];
                DateTime category_date_new;
                category_date_new = Convert.ToDateTime(data["CREATE_date_new"]);
                if (category_name_new == null || category_date_new == null)
                {
                    trave.Data = new
                    {
                        status = "FALSE",
                        messeger = "Không Được Để Giá Trị Trống"
                    };
                    return Json(trave, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    category.category_name = category_name_new;
                    category.CREATE_date = category_date_new;
                    int kq = dungchung.save();
                    if (kq > 0)
                    {
                        trave.Data = new
                        {
                            status = "OK",
                            messeger = "Sửa Danh Mục Thành Công Danh Muc " + data["category_id"]
                        };
                        return Json(trave, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        trave.Data = new
                        {
                            status = "FALSE",
                            messeger = "Sửa Danh Mục Không Thành Công"
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
                    messeger = "Sai Định Dạng Ngày Giờ"
                };
                return Json(trave, JsonRequestBehavior.AllowGet);
            }

        }



        // POST: Admin/Category/DeleteCategory
        [HttpPost]
        public ActionResult DeleteCategory(FormCollection data)
        {
            JsonResult trave = new JsonResult();
            try
            {
                category category = dungchung.Find(int.Parse(data["category_id"]));
                if (category == null)
                {
                    trave.Data = new
                    {
                        status = "FALSE",
                        messeger = "Không Tìm Thấy Danh Mục Cần Xóa"
                    };
                    return Json(trave, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    dungchung.Delete(category);
                    int kt = dungchung.save();
                    if (kt > 0)
                    {
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
            catch
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